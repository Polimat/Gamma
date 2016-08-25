﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Gamma.Models;
using Gamma.Common;
using Gamma.Interfaces;
using System.Windows;
using DevExpress.Mvvm;
using Gamma.Attributes;

namespace Gamma.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ProductionTaskPMViewModel : DbEditItemWithNomenclatureViewModel, IProductionTask, ICheckedAccess
    {
        /// <summary>
        /// Initializes a new instance of the ProductionTaskPMViewModel class.
        /// </summary>        
        public ProductionTaskPMViewModel() : base(DB.GammaDb)
        {
            Places = new ObservableCollection<Place>(DB.GammaDb.Places.Where(p => p.PlaceGroupID == (short)PlaceGroups.PM).
                Select(p => new Place()
                {
                    PlaceID = p.PlaceID,
                    PlaceName = p.Name
                }));
            if (Places.Count > 0)
                PlaceID = Places[0].PlaceID;
        }

        public ProductionTaskPMViewModel(Guid productionTaskBatchID, bool isForRw) : this()
        {
            ProductionTaskBatchID = productionTaskBatchID;
            IsForRw = isForRw;
            var productionTask = DB.GammaDb.GetProductionTaskByBatchID(productionTaskBatchID, (short)PlaceGroups.PM).FirstOrDefault();
            if (productionTask != null)
            {
                DateBegin = productionTask.DateBegin;
                DateEnd = productionTask.DateEnd;
                TaskQuantity = productionTask.Quantity;
                NomenclatureID = productionTask.C1CNomenclatureID;
                CharacteristicID = (Guid)productionTask.C1CCharacteristicID;
                IsConfirmed = productionTask.IsActual;
                ProductionTaskSGBViewModel = new ProductionTaskSGBViewModel(productionTask.ProductionTaskID);
                PlaceID = productionTask.PlaceID ?? PlaceID;
            }
            else
            {
                ProductionTaskSGBViewModel = new ProductionTaskSGBViewModel();
            }
            if (isForRw)
            {
                var productionTaskRw = DB.GammaDb.GetProductionTaskByBatchID(productionTaskBatchID, (short)PlaceGroups.Rw).FirstOrDefault();
                if (productionTaskRw != null)
                {
                    var nomenclatureIds =
                        GammaBase.ProductionTaskRWCutting.Where(
                            pt => pt.ProductionTaskID == productionTaskRw.ProductionTaskID).Select(pt => pt.C1CNomenclatureID).Distinct().ToList();
                    SpecificationNomenclature = new ObservableCollection<Nomenclature1C>();
                    foreach (var nomenclatureId in nomenclatureIds)
                    {
                        var inputNomenclature = new ObservableCollection<Nomenclature1C>(
                        GammaBase.GetInputNomenclature(nomenclatureId, (byte)PlaceGroups.PM).Select(n => new Nomenclature1C()
                        {
                            Name = n.Name,
                            NomenclatureID = (Guid)n.C1CNomenclatureID
                        }));
                        SpecificationNomenclature = SpecificationNomenclature.Count == 0 ? 
                            inputNomenclature : new ObservableCollection<Nomenclature1C>(SpecificationNomenclature.Intersect(inputNomenclature));
                    }
                }
            }
        }
        protected override bool CanChooseNomenclature()
        {
            return base.CanChooseNomenclature() && !IsReadOnly;
        }
        private DateTime? _dateBegin;
        [Required(ErrorMessage=@"Необходимо указать дату начала")]
        [UIAuth(UIAuthLevel.ReadOnly)]
        public DateTime? DateBegin
        {
            get
            {
                return _dateBegin;
            }
            set
            {
            	_dateBegin = value;
                RaisePropertyChanged("DateBegin");
            }
        }
        private DateTime? _dateEnd;
        [Required(ErrorMessage = @"Необходимо указать дату окончания")]
        [UIAuth(UIAuthLevel.ReadOnly)]
        public DateTime? DateEnd
        {
            get
            {
                return _dateEnd;
            }
            set
            {
            	_dateEnd = value;
                RaisePropertyChanged("DateEnd");
            }
        }
        [UIAuth(UIAuthLevel.ReadOnly)]
        [Required(ErrorMessage = @"Необходимо выбрать характеристику")]
        public override Guid? CharacteristicID
        {
            get { return base.CharacteristicID; }
            set
            {
                base.CharacteristicID = value;
            }
        }
        private bool IsConfirmed { get; set; }
        private void ProductionTaskRwChanged(ProductionTaskRwMessage msg)
        {
            if (msg.ProductionTaskBatchID != ProductionTaskBatchID) return;
            if (msg.Nomenclatures?.Count > 0)
            {
                SpecificationNomenclature = new ObservableCollection<Nomenclature1C>();
                foreach (var nomenclature in msg.Nomenclatures)
                {
                    Color = "";
                    if (nomenclature != null)
                    {
                        var specificationNomenclature = new ObservableCollection<Nomenclature1C>(
                            DB.GammaDb.GetInputNomenclature(nomenclature.NomenclatureID, (byte)PlaceGroups.PM)
                                .Select(n => new Nomenclature1C()
                                {
                                    Name = n.Name,
                                    NomenclatureID = (Guid)n.C1CNomenclatureID
                                }));
                        SpecificationNomenclature = SpecificationNomenclature.Count == 0 ? specificationNomenclature 
                            : new ObservableCollection<Nomenclature1C>(SpecificationNomenclature.Intersect(specificationNomenclature));
                    }
                    var charProperties = GammaBase.vCharacteristicSGBProperties.FirstOrDefault(
                        p => p.C1CCharacteristicID == nomenclature.CharacteristicID);
                    if (charProperties == null) continue;
                    Color = charProperties.Color;
                    Buyer = charProperties.Buyer;
                }
                if (SpecificationNomenclature.Count == 1)
                {
                    NomenclatureID = SpecificationNomenclature[0].NomenclatureID;
                }
                else if ((NomenclatureID != null && !SpecificationNomenclature.Select(s => s.NomenclatureID).Contains((Guid)NomenclatureID)) 
                    || SpecificationNomenclature.Count == 0)
                {
                    NomenclatureID = null;
                }                   
            }
            if (msg.DateBegin != null)
            {
                DateBegin = msg.DateBegin;
                DateEnd = msg.DateBegin;
            }
        }

        [UIAuth(UIAuthLevel.ReadOnly)]
        [Required(ErrorMessage = @"Необходимо выбрать номенклатуру")]
        public override Guid? NomenclatureID
        {
            get { return base.NomenclatureID; }
            set
            {
                base.NomenclatureID = value;
                SetCharacteristics();
            }
        }

        private void SetCharacteristics()
        {
            if (NomenclatureID == null) return;
            Characteristics = new ObservableCollection<Characteristic>(GammaBase.GetCharacteristicsForProdTaskPM(NomenclatureID, Color??"",Buyer??"", PlaceID)
                .Select(c => new Characteristic()
                {
                    CharacteristicID = c.C1CCharacteristicID,
                    CharacteristicName = c.CharacteristicName
                }));
        }

        /// <summary>
        /// Цвет для фильтрации характеристик
        /// </summary>
        private string Color { get; set; }

        /// <summary>
        /// Контрагент для фильтрации характеристик
        /// </summary>
        private string Buyer { get; set; }

        /*
        public override ObservableCollection<Characteristic> Characteristics
        {
            get { return base.Characteristics; }
            set
            {
                var tempChars = new ObservableCollection<Characteristic>();
                foreach (var characteristic in from characteristic in value let charProperties = GammaBase.vCharacteristicSGBProperties.Where(
                    p => p.C1CCharacteristicID == characteristic.CharacteristicID)
                    .Select(p => new
                    {
                        p.CoreDiameterNumeric,
                        p.LayerNumberNumeric,
                        p.FormatNumeric,
                        p.Color
                    }).FirstOrDefault() where charProperties != null where !(charProperties.LayerNumberNumeric > 1) && !(charProperties.CoreDiameterNumeric < 280) && !(charProperties.FormatNumeric < 2500) where AvailableColors.Count <= 0 || AvailableColors.Contains(charProperties.Color) select characteristic)
                {
                    tempChars.Add(characteristic);
                }
                base.Characteristics = tempChars;
                
                RaisePropertiesChanged("Characteristics");
            }
        }
        */


        public Guid ProductionTaskID { get; set; }
        public ProductionTaskSGBViewModel ProductionTaskSGBViewModel { get; private set; }

        private ObservableCollection<Nomenclature1C> _specificationNomenclature;
        public ObservableCollection<Nomenclature1C> SpecificationNomenclature
        {
            get
            {
                return _specificationNomenclature;
            }
            set
            {
            	_specificationNomenclature = value;
                RaisePropertyChanged("SpecificationNomenclature");
            }
        }
        
        private bool _isForRw;
        public bool IsForRw
        {
            get
            {
                return _isForRw;
            }
            set
            {
                if (_isForRw == value) return;
            	_isForRw = value;
                if (IsForRw)
                {
                    Messenger.Default.Register<ProductionTaskRwMessage>(this, ProductionTaskRwChanged);
                }
                else
                {
                    Messenger.Default.Unregister<ProductionTaskRwMessage>(this);
                }
                RaisePropertyChanged("IsForRw");
            }
        }
        private int _placeID;
        [UIAuth(UIAuthLevel.ReadOnly)]
        public int PlaceID
        {
            get
            {
                return _placeID;
            }
            set
            {
            	_placeID = value;
                SetCharacteristics();
                RaisePropertyChanged("Places");
            }
        }
        private ObservableCollection<Place> _places;
        public ObservableCollection<Place> Places
        {
            get
            {
                return _places;
            }
            set
            {
            	_places = value;
                RaisePropertyChanged("Places");
            }
        }
        private Guid ProductionTaskBatchID { get; set; }
/*        private Characteristic _selectedCharacteristic;
        [Required(ErrorMessage="Необходимо выбрать характеристику")]
        public Characteristic SelectedCharacteristic
        {
            get { return _selectedCharacteristic; }
            set 
            {
                _selectedCharacteristic = value;
                RaisePropertyChanged("SelectedCharacteristic");
            }
        }
 * */
        public override bool SaveToModel(Guid itemId, GammaEntities gammaBase = null) // itemID = ProductionTaskBatchID
        {
            if (!DB.HaveWriteAccess("ProductionTaskSGB")) return true;
            gammaBase = gammaBase ?? DB.GammaDb;
            var productionTaskBatch =
                    gammaBase.ProductionTaskBatches.FirstOrDefault(p => p.ProductionTaskBatchID == itemId);
                ProductionTasks productionTask;
                if (productionTaskBatch == null)
                {
                    MessageBox.Show("Что-то пошло не так при сохранении.", "Ошибка сохранения", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return true;
                }
                var productionTaskTemp =
                    gammaBase.GetProductionTaskByBatchID(itemId, (short) PlaceGroups.PM).FirstOrDefault();
                if (productionTaskTemp == null)
                {
                    ProductionTaskID = SqlGuidUtil.NewSequentialid();
                    productionTask = new ProductionTasks()
                    {
                        ProductionTaskID = ProductionTaskID,
                        PlaceGroupID = (short) PlaceGroups.PM
                    };
                    productionTaskBatch.ProductionTasks.Add(productionTask);
                }
                else
                {
                    ProductionTaskID = productionTaskTemp.ProductionTaskID;
                    productionTask = gammaBase.ProductionTasks.Find(ProductionTaskID);
                }
                productionTask.PlaceID = PlaceID;
                productionTask.C1CNomenclatureID = (Guid) NomenclatureID;
                productionTask.C1CCharacteristicID = CharacteristicID;
                productionTask.Quantity = TaskQuantity;
                productionTask.DateBegin = DateBegin;
                productionTask.DateEnd = DateEnd;
                gammaBase.SaveChanges();
                ProductionTaskSGBViewModel.SaveToModel(productionTask.ProductionTaskID);
            return true;
        }
        [Range(1, 1000000, ErrorMessage = @"Значение должно быть больше 0")]
        [UIAuth(UIAuthLevel.ReadOnly)]
        public decimal TaskQuantity { get; set; }
        public bool IsReadOnly
        {
            get 
            {
                return IsConfirmed || !DB.HaveWriteAccess("ProductionTasks");
            }
        }
    }
}