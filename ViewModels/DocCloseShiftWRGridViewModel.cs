﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gamma.Interfaces;
using System.Collections.ObjectModel;
using Gamma.Models;
using GalaSoft.MvvmLight.Command;
using System.Data.Entity;

namespace Gamma.ViewModels
{
    class DocCloseShiftWRGridViewModel : SaveImplementedViewModel, IFillClearGrid, IBarImplemented
    {
        public DocCloseShiftWRGridViewModel(OpenDocCloseShiftMessage msg)
        {
            Bars.Add(ReportManager.GetReportBar("DocCloseShiftWR", VMID));
            if (msg.DocID == null)
            {
                PlaceID = (int)msg.PlaceID;
                CloseDate = (DateTime)msg.CloseDate;
                ShiftID = (byte)msg.ShiftID;
                DocCloseShiftDocs = new ObservableCollection<Docs>();
                GroupPacks = new ObservableCollection<PaperBase>();
            }
            else
            {
                GroupPacks = new ObservableCollection<PaperBase>(
                    from sp in DB.GammaBase.GetDocCloseShiftWRGroupPacks(msg.DocID)
                    select new PaperBase
                    {
                        CharacteristicID = (Guid)sp.CharacteristicID,
                        Date = sp.Date,
                        NomenclatureID = (Guid)sp.NomenclatureID,
                        Nomenclature = sp.Nomenclature,
                        Number = sp.Number,
                        ProductID = sp.ProductID,
                        Weight = Convert.ToInt32(sp.Weight)
                    }
                    );
                var docCloseShift = DB.GammaBase.Docs.Include("DocCloseShiftDocs").Where(d => d.DocID == msg.DocID).FirstOrDefault();
                DocCloseShiftDocs = new ObservableCollection<Docs>(docCloseShift.DocCloseShiftDocs);
                CloseDate = docCloseShift.Date;
                ShiftID = (byte)docCloseShift.ShiftID;
                PlaceID = (byte)docCloseShift.PlaceID;
            }
            ShowGroupPackCommand = new RelayCommand(() =>
                MessageManager.OpenDocProduct(DocProductKinds.DocProductGroupPack, SelectedGroupPack.DocID),
                () => SelectedGroupPack != null);
        }
        public void FillGrid()
        {
            ClearGrid();
            DocCloseShiftDocs = new ObservableCollection<Docs>(DB.GammaBase.Docs.
                Where(d => d.PlaceID == PlaceID && d.ShiftID == ShiftID &&
                    d.Date >= DB.GetShiftBeginTime(CloseDate) && d.Date <= DB.GetShiftEndTime(CloseDate) &&
                    (d.DocTypeID == (int)DocTypes.DocProduction || d.DocTypeID == (int)DocTypes.DocWithdrawal)
                    && d.DocProducts.Count > 0).Select(d => d));
            foreach (var doc in DocCloseShiftDocs)
            {
                if (doc.DocTypeID == (byte)DocTypes.DocProduction)
                {

                    GroupPacks.Add(
                        (from d in DB.GammaBase.DocProducts
                         join ps in DB.GammaBase.ProductGroupPacks on d.ProductID equals ps.ProductID
                         where d.DocID == doc.DocID
                         select new PaperBase
                         {
                             CharacteristicID = (Guid)ps.C1CCharacteristicID,
                             Date = doc.Date,
                             DocID = doc.DocID,
                             NomenclatureID = (Guid)ps.C1CNomenclatureID,
                             Nomenclature = string.Concat(ps.C1CNomenclature.Name, " ", ps.C1CCharacteristics.Name),
                             Number = d.Docs.Number,
                             ProductID = d.ProductID,
                             Weight = ps.Weight ?? 0
                         }).FirstOrDefault()
                    );
                }
            }
        }
        public void ClearGrid()
        {
            DocCloseShiftDocs.Clear();
            GroupPacks.Clear();
        }
        public override void SaveToModel(Guid itemID)
        {
            if (!DB.HaveWriteAccess("DocCloseShiftDocs")) return;
            base.SaveToModel(itemID);
            var doc = DB.GammaBase.Docs.Include(d => d.DocCloseShiftDocs).Where(d => d.DocID == itemID).First();
            if (doc.DocCloseShiftDocs == null)
            {
                doc.DocCloseShiftDocs = new ObservableCollection<Docs>();
            }
            doc.DocCloseShiftDocs.Clear();
            foreach (var docCloseShiftDoc in DocCloseShiftDocs)
                {
                    doc.DocCloseShiftDocs.Add(docCloseShiftDoc);
                }
            DB.GammaBase.SaveChanges();
        }
        private int PlaceID { get; set; }
        private byte ShiftID { get; set; }
        private ObservableCollection<Docs> DocCloseShiftDocs { get; set; }
        private DateTime CloseDate { get; set; }
        public RelayCommand ShowGroupPackCommand { get; private set; }
        public PaperBase SelectedGroupPack { get; set; }
        private ObservableCollection<PaperBase> _groupPacks;
        public ObservableCollection<PaperBase> GroupPacks
        {
            get
            {
                return _groupPacks;
            }
            set
            {
            	_groupPacks = value;
                RaisePropertyChanged("GroupPacks");
            }
        }
        private ObservableCollection<BarViewModel> _bars = new ObservableCollection<BarViewModel>();
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
 
        private Guid? _vmId = Guid.NewGuid();
        public Guid? VMID
        {
            get { return _vmId; }
        }
    }
    
}
