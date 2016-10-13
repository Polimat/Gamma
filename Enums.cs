﻿using System.ComponentModel;

namespace Gamma
{
    /// <summary>
    /// Виды номенклатуры (1,2,3 соответствует 1С, не рекомендуется использовать в программе, 
    /// лучше передавать SQL в качестве параметра)
    /// </summary>
    public enum NomenclatureKinds
    {
        Any, HalfStuff, Material, Product
    }
    /// <summary>
    /// Типы материалов, применяемых в производстве. Прямая привязка к БД.
    /// </summary>
    public enum MaterialTypes
    {
        [Description("Материалы СГБ")]
        MaterialsSGB,
        [Description("Материалы СГИ")]
        MaterialsSGI
    }
    public enum ProcessModels 
    { 
        [Description("БДМ")]
        PM, 
        [Description("БДМ=>ПРС")]
        PMRw, 
        [Description("БДМ=>Упаковка")]
        PMWr,
        [Description("БДМ=>ПРС=>Упаковка")]
        PMRwWr,
        [Description("ПРС")]
        Rw,
        [Description("ПРС=>Упаковка")]
        RwWr
        
    }
    public enum BatchKinds { SGB, SGI }
    public enum ProductKinds 
    { 
        [Description("Тамбура")]
        ProductSpool, 
        [Description("Паллеты")]
        ProductPallet,
        [Description("Групповые упаковки")]
        ProductGroupPack
    }
    /// <summary>
    /// Группы переделов. Привязаны к таблице в базе, менять только вместе!
    /// </summary>
    public enum PlaceGroups { PM, Rw, Convertings, Wr, Other, Warehouses }
    /// <summary>
    /// Качество продукта
    /// </summary>
    public enum ProductState
    {
        [Description("Годная")]
        Good,
        [Description("Требует решения")]
        NeedsDecision,
        [Description("На утилизацию")]
        Broke,
        [Description("Ограниченная партия")]
        Limited,
        [Description("Хоз. нужды")]
        InternalUsage,
        [Description("На переделку")]
        Repack
    }

    public enum ToughnessKinds
    {
        [Description("↑")]
        Higher,
        [Description("Цель")]
        Target,
        [Description("↓")]
        Lower
    }
    /// <summary>
    /// Фильтр качества для поиска
    /// </summary>
    public enum ProductStatesFilter 
    {
        [Description("Годная")]
        Good,
        [Description("Требует решения")]
        NeedsDecision,
        [Description("На утилизацию")]
        Broke,
        [Description("Ограниченная партия")]
        Limited,
        [Description("Не подтвержден")]
        NotConfirmed
    }
    /// <summary>
    /// Как переработан тамбур
    /// </summary>
    public enum SpoolChangeState { FullyConverted, WithBroke, WithRemainder} 
    
    public enum DocProductKinds
    {
        DocProductSpool,
        DocProductUnload,
        DocProductPallet,
        DocProductGroupPack
    }
    public enum DocTypes
    {
        DocProduction,
        DocWithdrawal,
        DocMovement,
        DocCloseShift,
        DocChangeState,
        DocShipment,
        DocUnpack,
        DocBroke,
        DocMovementOrder
    }
    public enum PermissionMark
    {
        [Description("Нет доступа")]
        NoAccess,
        [Description("Чтение")]
        Read,
        [Description("Чтение и запись")]
        ReadAndWrite
    }
    /// <summary>
    /// Состояние задания на производство
    /// </summary>
    public enum ProductionTaskStates
    {
        [Description("На рассмотрении")]
        NeedsDecision,
        [Description("В производстве")]
        InProduction,
        [Description("Выполнено")]
        Completed
    }

    public enum PersonTypes
    {
        Loader = 1
    }
}
