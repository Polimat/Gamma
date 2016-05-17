﻿using System.Collections.ObjectModel;
using Gamma.Interfaces;
using System;
using DevExpress.Mvvm;
using System.Linq;
using Gamma.Attributes;
using Gamma.Models;
using System.Collections.Generic;
using System.Windows;
using System.Data.Entity;
using Gamma.Common;
using System.ComponentModel.DataAnnotations;

namespace Gamma.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class DocProductUnloadViewModel : SaveImplementedViewModel, IBarImplemented, ICheckedAccess
    {
        /// <summary>
        /// Инициализирует новую viewmodel.
        /// Если новый, то id = ProductionTaskID иначе id = DocID
        /// </summary>
        public DocProductUnloadViewModel(Guid docID, bool newProduct, GammaEntities gammaBase = null) : base(gammaBase)
        {
            DocID = docID;
            ProductionTaskID =
                    (Guid)GammaBase.DocProduction.Where(d => d.DocID == docID).Select(d => d.ProductionTaskID).First();
            GetProductionTaskRwInfo(ProductionTaskID);
            CreateSpoolsCommand = new DelegateCommand(CreateSpools, CanCreateSpools);
            EditSpoolCommand = new DelegateCommand(EditSpool);
            Bars.Add(ReportManager.GetReportBar("Unload", VMID));
            if (newProduct)  // Если новый съем то получаем раскрой из задания DocProduction и инициализруем коллекцию тамбуров съема
            {
//              GetProductionTaskRWInfo(id);
                UnloadSpools = new ObservableCollection<PaperBase>();
                SourceSpools = GammaBase.GetActiveSourceSpools(WorkSession.PlaceID).Select(p => p).OfType<Guid>().ToList();
                if (!SourceSpools.Any())
                {
                    MessageBox.Show("Нет активных раскатов. Окно будет закрыто!", "Нет активных раскатов", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    CloseWindow();
                }
            }
            else // Получение данных по id документа
            {
                IsConfirmed = GammaBase.Docs.Where(d => d.DocID == docID).Select(d => d.IsConfirmed).FirstOrDefault();
                SourceSpools = GammaBase.DocProducts.Where(dp => dp.Docs.DocWithdrawal.DocProduction.
                    Any(dprod => dprod.DocID == docID)).Select(dp => dp.ProductID).ToList();             
                DocProducts = new ObservableCollection<DocProducts>
                (GammaBase.DocProducts.Include("Products").Include("Products.ProductSpools").Where(dp => dp.DocID == docID));
                Products = new ObservableCollection<Products>(DocProducts.Select(dp => dp.Products));
//                (from p in GammaBase.Products where DocProducts.Where(dp => dp.ProductID == p.ProductID).Any() select p);
                UnloadSpools = new ObservableCollection<PaperBase>(from dp in DocProducts
                                                         join ps in GammaBase.ProductSpools.Include(p => p.C1CNomenclature)
                                                                   .Include(p => p.C1CCharacteristics) on dp.ProductID equals ps.ProductID
                                                         select new PaperBase
                                                         {
                                                             BreakNumber = ps.BreakNumber,
                                                             ProductID = ps.ProductID,
                                                             Number = dp.Products.Number,
                                                             Nomenclature = ps.C1CNomenclature.Name + " " + ps.C1CCharacteristics.Name,
                                                             CharacteristicID = (Guid)ps.C1CCharacteristicID,
                                                             NomenclatureID = ps.C1CNomenclatureID,
                                                             Weight = ps.Weight,
                                                             Diameter = ps.Diameter
                                                         }
                                    );
                ProductSpools = new ObservableCollection<ProductSpools>
                (DocProducts.Select(dp => dp.Products.ProductSpools));
                if (UnloadSpools.Count > 0)
                {
                    Diameter = UnloadSpools[0].Diameter;
                    BreakNumber = UnloadSpools[0].BreakNumber;
/*                    NomenclatureID = UnloadSpools[0].NomenclatureID;
                    Cuttings = new ObservableCollection<Cutting>
                    (
                    from u in UnloadSpools
                    group u by u.CharacteristicID into grouped
                    select new Cutting
                    {
                        CharacteristicID = grouped.Key,
                        Quantity = grouped.Count()
                    }
                    );
                    */
                }

            }
        }

        private bool CanCreateSpools()
        {
            return !IsReadOnly && IsValid;
        }

        private List<Guid> SourceSpools { get; set; }
        private void GetProductionTaskRwInfo(Guid productionTaskID)
        {
            Diameter = GammaBase.ProductionTaskSGB.Where(p => p.ProductionTaskID == productionTaskID).Select(p => p.Diameter).FirstOrDefault() ?? 0;
            Cuttings = new ObservableCollection<Cutting>
            (
                GammaBase.ProductionTaskRWCutting.Where(
                    p => p.ProductionTaskID == productionTaskID).GroupBy(p => new { p.C1CNomenclatureID, p.C1CCharacteristicID })
                    .Select(g => new Cutting()
                    {
                        NomenclatureID = g.Key.C1CNomenclatureID,
                        CharacteristicID = g.Key.C1CCharacteristicID,
                        Quantity = g.Count()
                    })
            );
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
        public DelegateCommand CreateSpoolsCommand { get; private set; }
        
        private void CreateSpools()
        {
            UIServices.SetBusyState();
            UnloadSpools.Clear();
            UnloadSpools =
                new ObservableCollection<PaperBase>(from us in GammaBase.CreateUnloadSpools(DocID, ProductionTaskID, Diameter, BreakNumber)
                select  new PaperBase()
                {
                    DocID = (Guid)us.DocID,
                    ProductID = (Guid)us.ProductID,
                    Number = us.Number,
                    Nomenclature = us.NomenclatureName
                });
/*            if (UnloadSpools.Count > 0) 
            {
                UnloadSpools.Clear();
                GammaBase.DocProducts.RemoveRange(DocProducts);
                GammaBase.ProductSpools.RemoveRange(ProductSpools);
                GammaBase.Products.RemoveRange(Products);
                DocProducts = null;
                ProductSpools = null;
                Products = null;
            }
            foreach (var cutting in Cuttings)
            {
                for (int i = 0; i < cutting.Quantity; i++)
                {
                    UnloadSpools.Add(new PaperBase
                    {
                        CharacteristicID = cutting.CharacteristicID,
                        NomenclatureID = (Guid)NomenclatureID,
                        Nomenclature = NomenclatureName + " " +
                        Characteristics.Where(c => c.CharacteristicID == cutting.CharacteristicID).Select(c => c.CharacteristicName).First(),
                        ProductID = SQLGuidUtil.NewSequentialid()
                    });    
                }
            }
            UnloadSpoolsSaved = false;
            Messenger.Default.Send<ParentSaveMessage>(new ParentSaveMessage());
*/
        }
        private bool UnloadSpoolsSaved { get; set; }
        private ObservableCollection<PaperBase> _unloadSpools = new ObservableCollection<PaperBase>();
        public ObservableCollection<PaperBase> UnloadSpools
        {
            get
            {
                return _unloadSpools;
            }
            set
            {
                _unloadSpools = value;
                RaisePropertyChanged("UnloadSpools");
            }
        }
        public override void SaveToModel(Guid itemID, GammaEntities gammaBase = null)
        {
            if (IsReadOnly) return;
//            gammaBase = gammaBase ?? DB.GammaDb;
            base.SaveToModel(itemID, gammaBase);
            if (UnloadSpoolsSaved) return;
            var doc = GammaBase.DocProduction.Include(d => d.DocWithdrawal).FirstOrDefault(d => d.DocID == itemID);
            foreach (var spoolid in SourceSpools)
            {
                var docWithdrawal = GammaBase.Docs.FirstOrDefault(d => d.DocTypeID == (byte) DocTypes.DocWithdrawal &&
                                                                 d.DocProducts.Select(dp => dp.ProductID)
                                                                     .Contains(spoolid));
                if (docWithdrawal == null)
                {
                    var docID = SqlGuidUtil.NewSequentialid();
                    docWithdrawal = new Docs()
                    {
                        DocID = docID,
                        PlaceID = WorkSession.PlaceID,
                        ShiftID = WorkSession.ShiftID,
                        Date = DB.CurrentDateTime,
                        DocTypeID = (byte)DocTypes.DocWithdrawal,
                        IsConfirmed = true,
                        UserID = WorkSession.UserID,
                        DocProducts = new List<DocProducts>(new[] {new DocProducts()
                    {
                        DocID = docID,
                        ProductID = spoolid
                    }}),
                        DocWithdrawal = new DocWithdrawal()
                        {
                            DocID = docID,
                            OutPlaceID = WorkSession.PlaceID,
                        }
                    };
                    GammaBase.Docs.Add(docWithdrawal);
                }
                if (!doc.DocWithdrawal.Contains(docWithdrawal.DocWithdrawal)) doc.DocWithdrawal.Add(docWithdrawal.DocWithdrawal);
            }
            GammaBase.SaveChanges();
            UnloadSpoolsSaved = true;
        }
        private ObservableCollection<DocProducts> DocProducts { get; set; }
        private Guid ProductionTaskID { get; set; }
        private ObservableCollection<Products> Products { get; set; }
        private ObservableCollection<ProductSpools> ProductSpools { get; set; }
        private Guid? _vmid = Guid.NewGuid();
        public Guid? VMID
        {
            get
            {
                return _vmid;
            }
        }

        private byte? _breakNumber;
        [UIAuth(UIAuthLevel.ReadOnly)]
        public byte? BreakNumber
        {
            get
            {
                return _breakNumber;
            }
            set
            {
                _breakNumber = value;
                RaisePropertyChanged("BreakNumber");
            }
        }
        private int _diameter;
        [UIAuth(UIAuthLevel.ReadOnly)]
        [Range(1,10000,ErrorMessage="Необходимо указать диаметр")]
        public int Diameter
        {
            get
            {
                return _diameter;
            }
            set
            {
                _diameter = value;
                RaisePropertyChanged("Diameter");
            }
        }
        private Guid DocID { get; set; }

        public DelegateCommand EditSpoolCommand { get; set; }
        public PaperBase SelectedUnloadSpool 
        {
            get; set;
        }
        private void EditSpool()
        {
            Messenger.Default.Register<ProductChangedMessage>(this,ProductChanged);
            MessageManager.OpenDocProduct(DocProductKinds.DocProductSpool, SelectedUnloadSpool.ProductID);
        }
        private void ProductChanged(ProductChangedMessage msg)
        {
            Messenger.Default.Unregister(this);
            var unloadSpool = UnloadSpools.FirstOrDefault(u => u.ProductID == msg.ProductID);
            if (unloadSpool != null)
                unloadSpool.Weight =
                    (from ps in GammaBase.ProductSpools where ps.ProductID == msg.ProductID select ps.Weight).FirstOrDefault();
        }

        public ObservableCollection<Cutting> Cuttings { get; set; }
        /*
        public class Cutting
        {
            public Guid CharacteristicID { get; set; }
            public int Quantity { get; set; }
        }
        */
        private bool IsConfirmed { get; set; }
        public bool IsReadOnly => IsConfirmed || !DB.HaveWriteAccess("ProductSpools");
    }
}