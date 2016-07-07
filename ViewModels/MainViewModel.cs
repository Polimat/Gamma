using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using System.Linq;
using Gamma.Interfaces;
using Gamma.Common;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Gamma.Dialogs;
using Gamma.Models;

namespace Gamma.ViewModels
{
    /// <summary>
    /// ViewModel ��� �������� ���� ����������
    /// </summary>
    public class MainViewModel : RootViewModel
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(GammaEntities gammaBase = null): base(gammaBase)
        {
            Messenger.Default.Register<CloseMessage>(this, msg => CloseSignal = true);
            Messenger.Default.Register<OpenProductionTaskBatchMessage>(this, OpenProductionTaskBatch);
            ViewsManager.Initialize();
            var settings = GammaSettings.Get();
            if (WorkSession.PlaceID > 0) // ���� �� �������������
            {
                var dialog = new ChoosePrintNameDialog();
                dialog.ShowDialog();
                if (dialog.DialogResult == true)
                {
                    WorkSession.PrintName = dialog.PrintName;
                }
            }
            StatusText = string.Format("������: {0}, ��: {1}, ������: {4}, ������������: {2}, ��� ��� ������: {3}", settings.HostName, settings.DbName, 
                settings.User, WorkSession.PrintName, settings.UseScanner ? "���" : "����");
            if (IsInDesignMode)
            {
                ShowReportListCommand = new DelegateCommand(MessageManager.OpenReportList);
//                ShowProductionTasksPMCommand = new DelegateCommand(() => CurrentView = ViewModelLocator.ProductionTasksPM);
                ShowProductionTasksSGBCommand = new DelegateCommand(() => CurrentView = new ProductionTasksSGBViewModel(DB.GammaDb));
                ShowProductionTasksSGICommand = new DelegateCommand(() => CurrentView = new ProductionTasksSGIViewModel(DB.GammaDb));
                FindProductCommand = new DelegateCommand(MessageManager.OpenFindProduct);
                ManageUsersCommand = new DelegateCommand(MessageManager.OpenManageUsers);
            }
            else
            {
                ShowReportListCommand = new DelegateCommand(MessageManager.OpenReportList,
                () => WorkSession.DBAdmin || DB.HaveWriteAccess("Reports"));
//                ShowProductionTasksPMCommand = new DelegateCommand(() => CurrentView = ViewModelLocator.ProductionTasksPM, () => DB.HaveReadAccess("ProductionTasks"));
                ShowProductionTasksSGBCommand = new DelegateCommand(() => CurrentView = new ProductionTasksSGBViewModel(DB.GammaDb),
                    () => DB.HaveReadAccess("ProductionTasks"));
                ShowProductionTasksSGICommand = new DelegateCommand(() => CurrentView = new ProductionTasksSGIViewModel(DB.GammaDb),
                    DB.HaveReadAccess("ProductionTasks"));
                FindProductCommand = new DelegateCommand(MessageManager.OpenFindProduct);
                ManageUsersCommand = new DelegateCommand(MessageManager.OpenManageUsers, () => WorkSession.DBAdmin);
                CloseShiftCommand = new DelegateCommand(CloseShift);
                BackCommand = new DelegateCommand(() =>
                {
                    CurrentView = PreviousView;
                    PreviousView = null;
                }, () => PreviousView != null);
                OpenDocCloseShiftsCommand = new DelegateCommand<PlaceGroups>(MessageManager.OpenDocCloseShifts);
                ConfigureComPortCommand = new DelegateCommand(MessageManager.ConfigureComPort, () => WorkSession.DBAdmin || WorkSession.ProgramAdmin);
                FindProductionTaskCommand = new DelegateCommand(FindProductionTask, () => DB.HaveWriteAccess("ProductionTasks"));
                OpenPlaceProductsCommand = new DelegateCommand<int>(OpenPlaceProducts);
                PrintReportCommand = new DelegateCommand<Guid>(PrintReport);
                OpenDocShipmentOrdersCommand = new DelegateCommand(OpenDocShipmentOrders, DB.HaveReadAccess("DocShipments"));
                OpenPlaceGroupsNomenclatureCommand = new DelegateCommand(MessageManager.OpenPlaceGroupsNomenclature
                    , () => DB.HaveWriteAccess("PlaceGroup1CNomenclature"));
                OpenMaterialTypesNomenclatureCommand = new DelegateCommand(MessageManager.OpenMaterialTypesNomenclature,
                    () => DB.HaveWriteAccess("MaterialType1CNomenclature"));
                OpenWarehousePersonsCommand = new DelegateCommand(MessageManager.OpenWarehousePersons, () => DB.HaveReadAccess("Persons"));
                OpenImportOldProductsCommand = new DelegateCommand(MessageManager.OpenImportOldProducts, () => DB.HaveWriteAccess("Products"));
            }
            switch (WorkSession.PlaceGroup)
            {
                case PlaceGroups.PM:
                case PlaceGroups.Rw:
                    CurrentView = new ProductionTasksSGBViewModel(DB.GammaDb);
                    break;
                case PlaceGroups.Wr:
                    OpenPlaceProducts(WorkSession.PlaceID);
                    break;
                case PlaceGroups.Convertings:
                    CurrentView = new ProductionTasksSGIViewModel(DB.GammaDb);
                    break;
            }
            var places = GammaBase.Places.Where(p => p.IsProductionPlace == true).Select(p => p);
            PlaceProducts = new ObservableCollection<PlaceProduct>();
            foreach (var place in places)
            {
                PlaceProducts.Add(
                    new PlaceProduct
                    {
                        Place = place.Name,
                        PlaceID = place.PlaceID,
                        Command = OpenPlaceProductsCommand
                    }
                    );
            }
            Reports = new List<ReportItem>(
                                           (from rep in GammaBase.Reports
                                           join parrep in GammaBase.Reports on rep.ParentID equals parrep.ReportID
                                           where parrep.Name == "Reports"
                                           orderby rep.Name
                                           select rep).ToList().Select(p => new ReportItem
                                           {
                                               ReportId = p.ReportID,
                                               ReportName = p.Name,
                                               Command = PrintReportCommand
                                           }));
        }

        private void OpenProductionTaskBatch(OpenProductionTaskBatchMessage msg)
        {
            if (msg.Window) return;
            CurrentView = new ProductionTaskBatchViewModel(msg, DB.GammaDb);
            ActivatedCommand = ((ProductionTaskBatchViewModel) CurrentView).ActivatedCommand;
            DeactivatedCommand = ((ProductionTaskBatchViewModel) CurrentView).DeactivatedCommand;
        }

        private DelegateCommand _activatedCommand;
        private DelegateCommand _deactivatedCommand;

        public DelegateCommand ActivatedCommand 
        {
            get { return _activatedCommand; }
            set
            {
                _activatedCommand = value;
                RaisePropertyChanged("ActivatedCommand");
            }
        }

        public DelegateCommand DeactivatedCommand
        {
            get { return _deactivatedCommand; }
            set
            {
                _deactivatedCommand = value;
                RaisePropertyChanged("DeactivatedCommand");
            }
        }

        public DelegateCommand OpenDocShipmentOrdersCommand { get; private set; }

        private void OpenDocShipmentOrders()
        {
            UIServices.SetBusyState();
            CurrentView = new DocShipmentOrdersViewModel();
        }

        private void OpenPlaceProducts(int placeID)
        {
            UIServices.SetBusyState();
            CurrentView = new PlaceProductsViewModel(placeID);
            RefreshCommand = ((PlaceProductsViewModel) CurrentView).FindCommand;
            NewItemCommand = ((PlaceProductsViewModel) CurrentView).CreateNewProductCommand;
            EditItemCommand = ((PlaceProductsViewModel) CurrentView).OpenDocProductCommand;
            DeleteItemCommand = ((PlaceProductsViewModel) CurrentView).DeleteProductCommand;
        }

        private void PrintReport(Guid reportId)
        {
            ReportManager.PrintReport(reportId);
        }

        private void FindProductionTask()
        {
//            if (CurrentView is ProductionTasksPMViewModel)
//                MessageManager.FindProductionTaskBatch(BatchKinds.SGB);
            if (CurrentView is ProductionTasksSGBViewModel)
                MessageManager.FindProductionTaskBatch(BatchKinds.SGB);
            else if (CurrentView is ProductionTasksSGIViewModel)
                MessageManager.FindProductionTaskBatch(BatchKinds.SGI);
        }

        private void CloseShift()
        {
            if (WorkSession.ShiftID == 0) return;
            MessageManager.OpenDocCloseShift(WorkSession.PlaceID, DB.CurrentDateTime, WorkSession.ShiftID);
        }

        private void CurrentViewChanged()
        {
            if ((CurrentView as IItemManager)!= null)
            {
                var itemManager = (IItemManager) CurrentView;
                NewItemCommand = itemManager.NewItemCommand;
                EditItemCommand = itemManager.EditItemCommand;
                DeleteItemCommand = itemManager.DeleteItemCommand;
                RefreshCommand = itemManager.RefreshCommand;
            }
            else
            {
                NewItemCommand = null;
                EditItemCommand = null;
                DeleteItemCommand = null;
                RefreshCommand = null;
            }
            if (CurrentView is ProductionTasksSGBViewModel || CurrentView is ProductionTasksSGIViewModel)
                ProductionTaskBarVisible = true;
            else ProductionTaskBarVisible = false;
        }
        private RootViewModel _currentView;
        public RootViewModel CurrentView
        {
            get { return _currentView; }
            private set
            {
                PreviousView = PreviousView == value ? PreviousView = null : PreviousView = _currentView;
                _currentView = value;
                RaisePropertyChanged("CurrentView");
                CurrentViewChanged();
            }
        }

        private RootViewModel PreviousView { get; set; }
        public string StatusText { get; set; }
        private DelegateCommand _newItemCommand;
        public DelegateCommand NewItemCommand 
        {
            get { return _newItemCommand; }
            private set 
            {
                _newItemCommand = value;
                RaisePropertyChanged("NewItemCommand");
            }
        }
        private DelegateCommand<object> _editItemCommand;
        public DelegateCommand<object> EditItemCommand 
        {
            get { return _editItemCommand; }
            private set
            {
                _editItemCommand = value;
                RaisePropertyChanged("EditItemCommand");
            }
        }
        private DelegateCommand _deleteItemCommand;
        public DelegateCommand DeleteItemCommand 
        {
            get { return _deleteItemCommand; }
            private set
            {
                _deleteItemCommand = value;
                RaisePropertyChanged("DeleteItemCommand");
            }
        }

        private DelegateCommand _backCommand;
        public DelegateCommand BackCommand
        {
            get { return _backCommand; }
            set
            {
                _backCommand = value;
                RaisePropertyChanged("BackCommand");
            }
        }
        private DelegateCommand _refreshCommand;
        public DelegateCommand RefreshCommand 
        {
            get { return _refreshCommand; }
            private set
            {
                _refreshCommand = value;
                RaisePropertyChanged("RefreshCommand");
            }
        }
        private bool _productionTaskBarVisible;
        public bool ProductionTaskBarVisible
        {
            get
            {
                return _productionTaskBarVisible;
            }
            set
            {
            	_productionTaskBarVisible = value;
                RaisePropertyChanged("ProductionTaskBarVisible");
            }
        }
        public DelegateCommand ShowReportListCommand { get; private set; }
        public DelegateCommand ShowProductionTasksSGICommand { get; private set; }
//        public DelegateCommand ShowProductionTasksPMCommand { get; private set; }
        public DelegateCommand ShowProductionTasksSGBCommand { get; private set; }
        public DelegateCommand FindProductCommand { get; private set; }
        public DelegateCommand ManageUsersCommand { get; set; }
        public DelegateCommand ConfigureComPortCommand { get; set; }
        public DelegateCommand CloseShiftCommand { get; set; }
        public DelegateCommand<PlaceGroups> OpenDocCloseShiftsCommand { get; private set; }
        public DelegateCommand FindProductionTaskCommand { get; private set; }
        public DelegateCommand<int> OpenPlaceProductsCommand { get; private set; }
        public DelegateCommand OpenPlaceGroupsNomenclatureCommand { get; private set; }
        public DelegateCommand OpenMaterialTypesNomenclatureCommand { get; private set; }
        public DelegateCommand OpenWarehousePersonsCommand { get; private set; }
        public DelegateCommand OpenImportOldProductsCommand { get; private set; }
        public DelegateCommand<Guid> PrintReportCommand { get; private set; }
        public ObservableCollection<PlaceProduct> PlaceProducts { get; set; }
        public List<ReportItem> Reports { get; set; }

        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
        public class PlaceProduct
        {
            public string Place { get; set; }
            public DelegateCommand<int> Command { get; set; }
            public int PlaceID { get; set; }
        }

        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
        public class ReportItem
        {
            public DelegateCommand<Guid> Command { get; set; }
            public Guid ReportId { get; set; }
            public string ReportName { get; set; }
        }

    }
}