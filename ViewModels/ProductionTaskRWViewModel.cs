﻿using GalaSoft.MvvmLight;
using System;
using Gamma.Models;
using System.Linq;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Gamma.Interfaces;
using Gamma.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace Gamma.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ProductionTaskRWViewModel : DBEditItemWithNomenclatureViewModel, ICheckedAccess, IProductionTask
    {
        /// <summary>
        /// Initializes a new instance of the ProductionTaskRWViewModel class.
        /// </summary>
        public ProductionTaskRWViewModel()
        {
            Initialize();
        }
        public ProductionTaskRWViewModel(Guid productionTaskBatchID) : this()
        {
            Initialize();
            ProductionTaskBatchID = productionTaskBatchID;
            var productionTask = DB.GammaBase.GetProductionTaskByBatchID(productionTaskBatchID, (short)PlaceGroups.RW).FirstOrDefault();
//            ProductionTask = DB.GammaBase.ProductionTasks.
//                Include("ProductionTaskRWCutting").Include("ProductionTaskBatches").Include("ProductionTaskSGB").
//                Where(pt => pt.ProductionTaskBatches.FirstOrDefault().ProductionTaskBatchID == productionTaskBatchID).FirstOrDefault();
//           IsConfirmed = ProductionTask.ProductionTaskStateID == (byte)ProductionTaskStates.InProduction;
            if (productionTask != null)
            {
                DateBegin = productionTask.DateBegin;
                DateEnd = productionTask.DateEnd;
                TaskQuantity = productionTask.Quantity;
                IsConfirmed = productionTask.IsActual;
                NomenclatureID = productionTask.C1CNomenclatureID;
                SetCharacteristicProperties();
                ProductionTaskSGBViewModel = new ProductionTaskSGBViewModel(productionTask.ProductionTaskID);
                var cuttings = DB.GammaBase.ProductionTaskRWCutting.Where(p => p.ProductionTaskID == productionTask.ProductionTaskID).ToList();
                if (cuttings.Count > 0)
                {
                    var charprops = CharacteristicProperties.Where(c => c.CharacteristicID == cuttings[0].C1CCharacteristicID).FirstOrDefault();
                    CoreDiameter = charprops.CoreDiameter;
                    LayerNumber = charprops.LayerNumber;
                    Color = charprops.Color;
                    Diameter = charprops.Diameter;
                    Destination = charprops.Destination;
                }
                int i = 0;
                foreach (var rwcutting in cuttings)
                {
                    CuttingFormats[0].Format[i] = DB.GammaBase.vCharacteristicSGBProperties.FirstOrDefault(p => p.C1CCharacteristicID == rwcutting.C1CCharacteristicID).FormatNumeric ?? 0;
                    i++;
                }
            }
            else
            {
                ProductionTaskSGBViewModel = new ProductionTaskSGBViewModel();
            }
        }
        private void Initialize()
        {
//            Messenger.Default.Register<Nomenclature1CMessage>(this, NomenclatureChanged);
            CuttingFormats = new ObservableCollection<Cutting>();
            CuttingFormats.Add(new Cutting());
            MainCutting = CuttingFormats[0];
            ClearFilterCommand = new RelayCommand(ClearFilter, () => !IsReadOnly);
        }

        private void ClearFilter()
        {
            ClearFormats();
            CoreDiameter = null;
            LayerNumber = null;
            Color = null;
            Diameter = null;
            Destination = null;
            CuttingsEnabled = false;
            FilterCharacteristics(Filters.All);
        }

        public Cutting MainCutting { get; set; }

        private Properties MandatoryProperties { get; set; }
        private ProductionTasks ProductionTask { get; set; }
        private Guid ProductionTaskBatchID { get; set; }
        public override void SaveToModel(Guid itemId) // itemID = ProductionTaskBatchID
        {
            base.SaveToModel(itemId);
            var productionTaskBatch = DB.GammaBase.ProductionTaskBatches.FirstOrDefault(p => p.ProductionTaskBatchID == itemId);
            if (productionTaskBatch == null)
            {
                MessageBox.Show("Что-то пошло не так при сохранении.", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var productionTaskTemp = DB.GammaBase.GetProductionTaskByBatchID(itemId, (short)PlaceGroups.RW).FirstOrDefault();
            if (productionTaskTemp == null)
            {
                ProductionTaskID = SQLGuidUtil.NewSequentialId();
                ProductionTask = new ProductionTasks()
                {
                    ProductionTaskID = ProductionTaskID,
                    PlaceGroupID = (short)PlaceGroups.RW,
                };
                productionTaskBatch.ProductionTasks.Add(ProductionTask);
            }
            else
            {
                ProductionTaskID = productionTaskTemp.ProductionTaskID;
                ProductionTask = DB.GammaBase.ProductionTasks
                    .Include("ProductionTaskRWCutting").First(p => p.ProductionTaskID == ProductionTaskID);
            }
            ProductionTask.C1CNomenclatureID = (Guid)NomenclatureID;
            ProductionTask.Quantity = TaskQuantity;
            ProductionTask.DateBegin = DateBegin;
            ProductionTask.DateEnd = DateEnd;
            // заполняем раскрой для базы
            var prodTaskCuttings = new ObservableCollection<ProductionTaskRWCutting>();
            for (int i = 0; i < CuttingFormats[0].Format.Count; i++)
            {
                var format = CuttingFormats[0].Format[i];
            	if (format == null) continue;
                var characteristicIds = (from cp in CharacteristicProperties
                                       where cp.Color == Color && cp.CoreDiameter == CoreDiameter
                                           && cp.Format == format &&
                                           cp.LayerNumber == LayerNumber
                                       select cp.CharacteristicID).ToList();
                if (characteristicIds.Count > 1)
                {
                    characteristicIds =
                        CharacteristicProperties.Where(
                            c => characteristicIds.Contains(c.CharacteristicID) && c.Destination == Destination)
                            .Select(c => c.CharacteristicID)
                            .ToList();
                    if (characteristicIds.Count > 1)
                    {
                        characteristicIds =
                        CharacteristicProperties.Where(
                            c => characteristicIds.Contains(c.CharacteristicID) && c.Diameter == Diameter)
                            .Select(c => c.CharacteristicID)
                            .ToList();
                    }
                }
                Guid? characteristicId;
                if (characteristicIds.Count == 1) characteristicId = characteristicIds[0];
                else
                {
                    MessageBox.Show("Некорректные параметры задания ПРС", "Параметры ПРС", MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }
                if (characteristicId != null)
                {
                    prodTaskCuttings.Add(new ProductionTaskRWCutting()
                    {
                        C1CCharacteristicID = (Guid)characteristicId,
                        CutIndex = (short)i,
                        ProductionTaskID = ProductionTaskID,
                        ProductionTaskRWCuttingID = SQLGuidUtil.NewSequentialId()
                    });
                }
            }
            DB.GammaBase.ProductionTaskRWCutting.RemoveRange(ProductionTask.ProductionTaskRWCutting);
            DB.GammaBase.ProductionTaskRWCutting.AddRange(prodTaskCuttings);
            DB.GammaBase.SaveChanges();
            ProductionTaskSGBViewModel.SaveToModel(ProductionTaskID);
        }
        [UIAuth(UIAuthLevel.ReadOnly)]
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (_color == value) return;
                _color = value;
                RaisePropertyChanged("Color");
                if (value != null)
                {
                    FilledProperties |= Properties.PropColor;
                    FilterCharacteristics(Filters.Color);
                }
                else FilledProperties &= ~Properties.PropColor;
            }
        }
        private Properties _filledProperties;
        private Properties FilledProperties 
        {
            get
            {
                return _filledProperties;
            }
            set
            {
            	_filledProperties = value;
                if (MandatoryProperties != Properties.None && (value & MandatoryProperties) == MandatoryProperties) CuttingsEnabled = true;
                else CuttingsEnabled = false;
            }
        }

        private void FilterCharacteristics(Filters filter)
        {
            if (CharacteristicProperties == null) return;
            var filteredProperties = CharacteristicProperties.Where(c =>
                (Color == null || c.Color == null || c.Color == Color) &&
                (LayerNumber == null || c.LayerNumber == null || c.LayerNumber == LayerNumber) &&
                (CoreDiameter == null || c.CoreDiameter == null || c.CoreDiameter == CoreDiameter)
//                    &&
//                    (Destination == null || c.Destination == null || c.Destination == Destination) &&
//                    (Diameter == null || c.Diameter == null || c.Diameter == Diameter)
                ).GroupBy(fc => new
                {
                    CoreDiameter = fc.CoreDiameter,
                    LayerNumber = fc.LayerNumber,
                    Color = fc.Color,
                    Diameter = fc.Diameter,
                    Format = fc.Format,
                    Destination = fc.Destination
                }, (g, r) =>
                    new
                    {
                        CoreDiameter = g.CoreDiameter,
                        LayerNumber = g.LayerNumber,
                        Color = g.Color,
                        Diameter = g.Diameter,
                        Format = g.Format,
                        Destination = g.Destination,
                        Count = r.Count()
                    }).Where(c => c.Count == 1 || c.Count > 1 && c.Destination == Destination)
                    .GroupBy(fc => new
                    {
                        CoreDiameter = fc.CoreDiameter,
                        LayerNumber = fc.LayerNumber,
                        Color = fc.Color,
                        Diameter = fc.Diameter,
                        Format = fc.Format,
                        Destination = fc.Destination
                    }, (g,r) => 
                    new {
                        CoreDiameter = g.CoreDiameter,
                        LayerNumber = g.LayerNumber,
                        Color = g.Color,
                        Diameter = g.Diameter,
                        Format = g.Format,
                        Destination = g.Destination,
                        Count = r.Count()
                    }).Where(c => c.Count == 1);
            if (filter != Filters.Color)
                Colors = new ObservableCollection<string>(filteredProperties.Select(c => c.Color).Distinct());
            if (filter != Filters.LayerNumber)
                LayerNumbers = new ObservableCollection<string>(filteredProperties.Select(c => c.LayerNumber).Distinct());
            if (filter != Filters.CoreDiameter)
                CoreDiameters = new ObservableCollection<string>(filteredProperties.Select(c => c.CoreDiameter).Distinct());
            if (filter != Filters.Destination)
                Destinations = new ObservableCollection<string>(filteredProperties.Select(c => c.Destination).Distinct());
            if (filter != Filters.Diameter)
                Diameters = new ObservableCollection<string>(filteredProperties.Select(c => c.Diameter).Distinct());
            Formats = new ObservableCollection<int>(filteredProperties.Select(c => c.Format).OrderBy(f => f).Distinct());
/*            var charsWithoutFormat = (from fc in filteredCharacteristics
                                      select new
                                      {
                                          Color = fc.Color,
                                          LayerNumber = fc.LayerNumber,
                                          CoreDiameter = fc.CoreDiameter,
                                          Destination = fc.Destination,
                                          Diameter = fc.Diameter
                                      }).Distinct().ToList();
            if (charsWithoutFormat.Count == 1) CuttingsEnabled = true; else CuttingsEnabled = false;
 * */
            if (Colors.Count == 1) Color = Colors[0];
            if (LayerNumbers.Count == 1) LayerNumber = LayerNumbers[0];
            if (CoreDiameters.Count == 1) CoreDiameter = CoreDiameters[0];
            if (Destinations.Count == 1) Destination = Destinations[0];
            if (Diameters.Count == 1) Diameter = Diameters[0];
        }
        public ObservableCollection<string> Colors
        {
            get
            {
                return _colors;
            }
            set
            {
                _colors = value;
                RaisePropertyChanged("Colors");
            }
        }
        [UIAuth(UIAuthLevel.ReadOnly)]
        public string CoreDiameter
        {
            get
            {
                return _coreDiameter;
            }
            set
            {
                if (_coreDiameter == value) return;
                _coreDiameter = value;
                RaisePropertyChanged("CoreDiameter");
                if (value != null)
                {
                    FilledProperties |= Properties.PropCoreDiameter;
                    FilterCharacteristics(Filters.CoreDiameter);
                }
                else FilledProperties &= ~Properties.PropCoreDiameter;
            }
        }
        public ObservableCollection<string> CoreDiameters
        {
            get
            {
                return _coreDiameters;
            }
            set
            {
                _coreDiameters = value;
                RaisePropertyChanged("CoreDiameters");
            }
        }
        public ObservableCollection<Cutting> CuttingFormats
        {
            get
            {
                return _cuttingFormats;
            }
            set
            {
                _cuttingFormats = value;
                RaisePropertyChanged("CuttingFormats");
            }
        }
        private DateTime? _dateBegin;
        [Required(ErrorMessage = "Необходимо указать дату начала")]
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
        [Required(ErrorMessage = "Необходимо указать дату окончания")]
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
        public string Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                if (_destination == value) return;
                _destination = value;
                RaisePropertyChanged("Destination");
                if (value != null)
                {
                    FilledProperties |= Properties.PropDestination;
                    FilterCharacteristics(Filters.Destination);
                }
                else FilledProperties &= ~Properties.PropDestination;
            }
        }
        public ObservableCollection<string> Destinations
        {
            get
            {
                return _destinations;
            }
            set
            {
                _destinations = value;
                if (Destinations.Count == 1) Destination = Destinations[0];
                RaisePropertyChanged("Destinations");
            }
        }
        public ObservableCollection<string> Diameters
        {
            get
            {
                return _diameters;
            }
            set
            {
                _diameters = value;
                RaisePropertyChanged("Diameters");
            }
        }
        [UIAuth(UIAuthLevel.ReadOnly)]
        public string Diameter
        {
            get
            {
                return _diameter;
            }
            set
            {
                if (_diameter == value) return;
                _diameter = value;
                RaisePropertyChanged("Diameter");
                if (value != null)
                {
                    FilledProperties |= Properties.PropDiameter;
                    FilterCharacteristics(Filters.Diameter);
                }
                else FilledProperties &= ~Properties.PropDiameter;
            }
        }
        public ObservableCollection<int> Formats
        {
            get
            {
                return _formats;
            }
            set
            {
                _formats = value;
                RaisePropertyChanged("Formats");
            }
        }
        [UIAuth(UIAuthLevel.ReadOnly)]
        public string LayerNumber
        {
            get
            {
                return _layerNumber;
            }
            set
            {
                if (_layerNumber == value) return;
                _layerNumber = value;
                RaisePropertyChanged("LayerNumber");
                if (value != null)
                {
                    FilledProperties |= Properties.PropLayerNumber;
                    FilterCharacteristics(Filters.LayerNumber);
                }
                else FilledProperties &= ~Properties.PropLayerNumber;
            }
        }
        public ObservableCollection<string> LayerNumbers
        {
            get
            {
                return _layerNumbers;
            }
            set
            {
                _layerNumbers = value;
                RaisePropertyChanged("LayerNumbers");
            }
        }

        protected override void NomenclatureChanged(Nomenclature1CMessage msg)
        {
            ClearFilter();
            NomenclatureID = msg.Nomenclature1CID;
            SetCharacteristicProperties();
            if (NomenclatureID != null)
            {
                MessageManager.ProductionTaskRWNomenclatureChanged(ProductionTaskBatchID, (Guid)NomenclatureID);
            }
        }

        private void SetCharacteristicProperties()
        {
            var tempCollection = new ObservableCollection<CharacteristicProperty>();
            foreach (var characteristic in Characteristics)
            {
                var charprops = DB.GammaBase.GetCharPropsDescriptions(characteristic.CharacteristicID).FirstOrDefault();
                tempCollection.Add
                    (new CharacteristicProperty()
                    {
                        CharacteristicID = charprops.C1CCharacteristicID,
                        Format = ((int)DB.GammaBase.vCharacteristicSGBProperties.
                            Where(p => p.C1CCharacteristicID == charprops.C1CCharacteristicID).FirstOrDefault().FormatNumeric),
                        Diameter = charprops.Diameter,
                        LayerNumber = charprops.LayerNumber,
                        Destination = charprops.Destination,
                        Color = charprops.Color,
                        CoreDiameter = charprops.CoreDiameter
                    });
            }
            MandatoryProperties = Properties.None;
            if (!tempCollection.Any(c => c.CoreDiameter == null))
            {
                MandatoryProperties |= Properties.PropCoreDiameter;
            }
            if (!tempCollection.Any(c => c.LayerNumber == null))
            {
                MandatoryProperties |= Properties.PropLayerNumber;
            }
            if (!tempCollection.Any(c => c.Color == null))
            {
                MandatoryProperties |= Properties.PropColor;
            }
            if (!tempCollection.Any(c => c.Diameter == null))
            {
                MandatoryProperties |= Properties.PropDiameter;
            }
            if (!tempCollection.Any(c => c.Destination == null))
            {
                MandatoryProperties |= Properties.PropDestination;
            }
            CharacteristicProperties = tempCollection;
        }
        private decimal _taskQuantity;
        [Range(1,1000000000,ErrorMessage="Задание должно быть больше 0")]
        [UIAuth(UIAuthLevel.ReadOnly)]
        public decimal TaskQuantity
        {
            get
            {
                return _taskQuantity;
            }
            set
            {
            	_taskQuantity = value;
                RaisePropertyChanged("TaskQuantity");
            }
        }
        private void ClearFormats()
        {
            for (int i = 0; i < CuttingFormats[0].Format.Count; i++)
            {
                CuttingFormats[0].Format[i] = null;
            }
        }
        private bool IsConfirmed { get; set; }
        private ObservableCollection<string> _coreDiameters;
        private ObservableCollection<string> _layerNumbers;
        private ObservableCollection<string> _colors;
        private ObservableCollection<string> _diameters;
        private ObservableCollection<string> _destinations;
        private ObservableCollection<int> _formats;
        private ObservableCollection<Cutting> _cuttingFormats;
        private string _coreDiameter;
        private string _layerNumber;
        private string _color;
        private string _diameter;
        private string _destination;
        
        private ObservableCollection<CharacteristicProperty> _characteristicProperties;
        private ObservableCollection<CharacteristicProperty> CharacteristicProperties 
        {
            get
            {
                return _characteristicProperties;
            }
            set
            {
            	_characteristicProperties = value;
                FilterCharacteristics(Filters.All);
            }
        }
        private class CharacteristicProperty
        {
            public Guid? CharacteristicID { get; set; }
            public string CoreDiameter { get; set; }
            public string LayerNumber { get; set; }
            public string Diameter { get; set; }
            public string Destination { get; set; }
            public int Format { get; set; }
            public string Color { get; set; }
        }
        public class Cutting : ViewModelBase
        {
            private ObservableCollection<int?> _format;
            public Cutting()
            {
                Format = new ObservableCollection<int?>(new int?[16]);
                Format.CollectionChanged += Format_CollectionChanged;
            }
            private void Format_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                TotalFormat = 0;
                foreach (var format in Format)
                {
                    TotalFormat += format ?? 0;
                }
            }                                                                                                     
            public ObservableCollection<int?> Format
            {
                get
                {
                    return _format;
                }
                set
                {
                	_format = value;
                    RaisePropertyChanged("Format");
                }
            }
            private int _totalFormat;
            public int TotalFormat
            {
                get
                {
                    return _totalFormat;
                }
                set
                {
                	_totalFormat = value;
                    RaisePropertyChanged("TotalFormat");
                }
            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid && CuttingsAreNotEmpty();
            }
        }
        private bool CuttingsAreNotEmpty()
        {
            var result = false;
            foreach (var format in CuttingFormats[0].Format)
            {
                if (format != null)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        private bool _cuttingsEnabled;
        public bool CuttingsEnabled
        {
            get
            {
                if (IsReadOnly) return false;
                return _cuttingsEnabled;
            }
            set
            {
            	_cuttingsEnabled = value;
                RaisePropertyChanged("CuttingsEnabled");
            }
        }
        public RelayCommand ClearFilterCommand { get; private set; }
        private enum Filters { All, Color, Diameter, CoreDiameter, LayerNumber, Destination }

        public bool IsReadOnly
        {
            get 
            {
                return IsConfirmed || !DB.HaveWriteAccess("ProductionTasks");
            }
        }

        public Guid ProductionTaskID
        {
            get;
            set;
        }
        public ProductionTaskSGBViewModel ProductionTaskSGBViewModel { get; private set; }
        private string _totalFormat;
        public string TotalFormat
        {
            get
            {
                return _totalFormat;
            }
            set
            {
            	_totalFormat = value;
                RaisePropertyChanged("TotalFormat");
            }
        }
        [Flags]
        private enum Properties
        {
            None = 0,
            PropCoreDiameter = 1,
            PropLayerNumber = 2,
            PropColor = 4,
            PropDiameter = 8,
            PropDestination = 16
        }
    }
}