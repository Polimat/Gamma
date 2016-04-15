﻿using DevExpress.Mvvm;
using System;
using System.Linq;
using Gamma.Interfaces;
using Gamma.Models;
using System.Collections.ObjectModel;

// ReSharper disable MemberCanBePrivate.Global

namespace Gamma.ViewModels
{
    class DocCloseShiftViewModel : SaveImplementedViewModel
    {
        public DocCloseShiftViewModel(OpenDocCloseShiftMessage msg)
        {
            if (msg.DocID == null)
            {
                Date = (DateTime)msg.CloseDate;
                IsConfirmed = false;
                PlaceID = (int)msg.PlaceID;
                IsNewDoc = true;
                Title = "Закрытие смены";
            }
            else
            {
                Doc = (from d in DB.GammaBase.Docs.Include("Places") where d.DocID == msg.DocID select d).FirstOrDefault();
                DB.GammaBase.Entry<Docs>(Doc).Reload();
                Date = Doc.Date;
                Number = Doc.Number;
                IsConfirmed = Doc.IsConfirmed;
                PlaceID = (int)Doc.PlaceID;
                IsNewDoc = false;
                Title = "Закрытие смены №" + Doc.Number;
            }
            var placeGroupID = DB.GammaBase.Places.Where(p => p.PlaceID == PlaceID).Select(p => p.PlaceGroupID).FirstOrDefault();
            switch (placeGroupID)
            {
                case (short)PlaceGroups.PM:
                    CurrentViewModelGrid = new DocCloseShiftPMGridViewModel(msg);
                    CurrentViewModelRemainder = msg.DocID == null ? new DocCloseShiftPMRemainderViewModel() : new DocCloseShiftPMRemainderViewModel((Guid)msg.DocID);
                    break;
                case (short)PlaceGroups.Wr:
                    CurrentViewModelGrid = new DocCloseShiftWrGridViewModel(msg);
                    break;
                case (short)PlaceGroups.Rw:
                    CurrentViewModelRemainder = msg.DocID == null ? new DocCloseShiftRwRemainderViewModel(PlaceID) : new DocCloseShiftRwRemainderViewModel((Guid)msg.DocID);
                    break;
                default:
                    break;
            }
            if (CurrentViewModelGrid is IFillClearGrid)
            {
                FillGridCommand = new DelegateCommand(((IFillClearGrid) CurrentViewModelGrid).FillGrid, () => !IsConfirmed);
                ClearGridCommand = new DelegateCommand(((IFillClearGrid) CurrentViewModelGrid).ClearGrid,
                    () => !IsConfirmed);
            }
            Messenger.Default.Register<PrintReportMessage>(this, PrintReport);
        }
        private void PrintReport(PrintReportMessage msg)
        {
            if (msg.VMID != (CurrentViewModelGrid as IBarImplemented)?.VMID) return;
            if (!IsValid) return;
            if (CanSaveExecute())
                SaveToModel();
            else if (IsNewDoc) return;
            ReportManager.PrintReport(msg.ReportID, Doc.DocID);
        }
        private Docs Doc { get; set; }
        private bool IsNewDoc { get; set; }
        private int PlaceID { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public bool IsConfirmed { get; set; }
        private SaveImplementedViewModel _currentViewModelGrid;
        public SaveImplementedViewModel CurrentViewModelGrid 
        {
            get
            {
                return _currentViewModelGrid;
            }
            set
            {
                _currentViewModelGrid = value;
                Bars = (_currentViewModelGrid as IBarImplemented).Bars;
            }
        }
        public SaveImplementedViewModel CurrentViewModelRemainder { get; set; }
        public DelegateCommand FillGridCommand { get; set; }
        public DelegateCommand ClearGridCommand { get; set; }
        public override void SaveToModel()
        {
            if (!CanSaveExecute()) return;
            base.SaveToModel();
            if (IsNewDoc)
            {
                Doc = new Docs()
                {
                    DocID = SqlGuidUtil.NewSequentialid(),
                    DocTypeID = (byte)DocTypes.DocCloseShift,
                    Date = Date,
                    UserID = WorkSession.UserID,
                    PlaceID = WorkSession.PlaceID,
                    ShiftID = WorkSession.ShiftID,
                    IsConfirmed = IsConfirmed,
                    PrintName = WorkSession.PrintName
                };
                DB.GammaBase.Docs.Add(Doc);
            }
            Doc.IsConfirmed = IsConfirmed;
            DB.GammaBase.SaveChanges();
            IsNewDoc = false;
            CurrentViewModelGrid?.SaveToModel(Doc.DocID);
            CurrentViewModelRemainder?.SaveToModel(Doc.DocID);
        }
        private ObservableCollection<BarViewModel> _bars;
        public ObservableCollection<BarViewModel> Bars
        {
            get
            {
                return _bars;
            }
            set
            {
                _bars = value;
                RaisePropertyChanged("Bars");
            }
        }
        public string Title { get; set; }
        public override bool CanSaveExecute()
        {
            return base.CanSaveExecute() && DB.HaveWriteAccess("DocCloseShiftDocs");
        }
    }
}
