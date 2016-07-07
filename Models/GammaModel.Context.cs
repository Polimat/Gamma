﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gamma.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GammaEntities : DbContext
    {
        public GammaEntities()
            : base("name=GammaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C1CCharacteristicProperties> C1CCharacteristicProperties { get; set; }
        public virtual DbSet<C1CEnumGroupTypes> C1CEnumGroupTypes { get; set; }
        public virtual DbSet<C1CMeasureUnitQualifiers> C1CMeasureUnitQualifiers { get; set; }
        public virtual DbSet<C1CMeasureUnits> C1CMeasureUnits { get; set; }
        public virtual DbSet<C1CNomenclatureGroups> C1CNomenclatureGroups { get; set; }
        public virtual DbSet<C1CNomenclatureProperties> C1CNomenclatureProperties { get; set; }
        public virtual DbSet<C1CProperties> C1CProperties { get; set; }
        public virtual DbSet<C1CPropertyValueGammaPropertyValue> C1CPropertyValueGammaPropertyValue { get; set; }
        public virtual DbSet<C1CPropertyValues> C1CPropertyValues { get; set; }
        public virtual DbSet<C1CQuality> C1CQuality { get; set; }
        public virtual DbSet<C1CRejectionReasons> C1CRejectionReasons { get; set; }
        public virtual DbSet<C1CSpecificationInputNomenclature> C1CSpecificationInputNomenclature { get; set; }
        public virtual DbSet<C1CSpecificationOutputNomenclature> C1CSpecificationOutputNomenclature { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<DocChangeStateProducts> DocChangeStateProducts { get; set; }
        public virtual DbSet<DocCloseShiftRemainders> DocCloseShiftRemainders { get; set; }
        public virtual DbSet<DocMovement> DocMovement { get; set; }
        public virtual DbSet<DocProduction> DocProduction { get; set; }
        public virtual DbSet<DocProducts> DocProducts { get; set; }
        public virtual DbSet<Docs> Docs { get; set; }
        public virtual DbSet<DocTypes> DocTypes { get; set; }
        public virtual DbSet<DocWithdrawal> DocWithdrawal { get; set; }
        public virtual DbSet<Enterprises> Enterprises { get; set; }
        public virtual DbSet<GammaProperties> GammaProperties { get; set; }
        public virtual DbSet<Permits> Permits { get; set; }
        public virtual DbSet<PermitTables> PermitTables { get; set; }
        public virtual DbSet<PlaceGroups> PlaceGroups { get; set; }
        public virtual DbSet<ProcessModels> ProcessModels { get; set; }
        public virtual DbSet<ProductGroupPacks> ProductGroupPacks { get; set; }
        public virtual DbSet<ProductionTaskStates> ProductionTaskStates { get; set; }
        public virtual DbSet<ProductionTaskWR> ProductionTaskWR { get; set; }
        public virtual DbSet<ProductKinds> ProductKinds { get; set; }
        public virtual DbSet<ProductPallets> ProductPallets { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductStates> ProductStates { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Rests> Rests { get; set; }
        public virtual DbSet<RolePermits> RolePermits { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SourceSpools> SourceSpools { get; set; }
        public virtual DbSet<SpoolInstallLog> SpoolInstallLog { get; set; }
        public virtual DbSet<Templates> Templates { get; set; }
        public virtual DbSet<UserPrintNames> UserPrintNames { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<vProductionTaskBatches> vProductionTaskBatches { get; set; }
        public virtual DbSet<vProductionTaskProducts> vProductionTaskProducts { get; set; }
        public virtual DbSet<C1CCharacteristics> C1CCharacteristics { get; set; }
        public virtual DbSet<C1CNomenclature> C1CNomenclature { get; set; }
        public virtual DbSet<C1CSpecifications> C1CSpecifications { get; set; }
        public virtual DbSet<C1CNomenclatureAnalogs> C1CNomenclatureAnalogs { get; set; }
        public virtual DbSet<C1CPlaces> C1CPlaces { get; set; }
        public virtual DbSet<DocWithdrawalMaterials> DocWithdrawalMaterials { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<ProductionTaskRWCutting> ProductionTaskRWCutting { get; set; }
        public virtual DbSet<ProductionTasks> ProductionTasks { get; set; }
        public virtual DbSet<ProductSpools> ProductSpools { get; set; }
        public virtual DbSet<vCharacteristicSGBProperties> vCharacteristicSGBProperties { get; set; }
        public virtual DbSet<C1CContractors> C1CContractors { get; set; }
        public virtual DbSet<C1CDocShipmentOrder> C1CDocShipmentOrder { get; set; }
        public virtual DbSet<C1CDocShipmentOrderGoods> C1CDocShipmentOrderGoods { get; set; }
        public virtual DbSet<C1CWarehouses> C1CWarehouses { get; set; }
        public virtual DbSet<PostTypes> PostTypes { get; set; }
        public virtual DbSet<vDocShipmentOrders> vDocShipmentOrders { get; set; }
        public virtual DbSet<ProductionTaskSGB> ProductionTaskSGB { get; set; }
        public virtual DbSet<DocShipmentOrderInfo> DocShipmentOrderInfo { get; set; }
        public virtual DbSet<vProductsInfo> vProductsInfo { get; set; }
        public virtual DbSet<ProductionTaskBatches> ProductionTaskBatches { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<DocCloseShiftSamples> DocCloseShiftSamples { get; set; }
        public virtual DbSet<DocShipments> DocShipments { get; set; }
        public virtual DbSet<ProductPalletItems> ProductPalletItems { get; set; }
        public virtual DbSet<C1CMainSpecifications> C1CMainSpecifications { get; set; }
        public virtual DbSet<MaterialTypes> MaterialTypes { get; set; }
    
        public virtual int CreateDocChangeStateForProduct(Nullable<System.Guid> docID, Nullable<System.Guid> productID, Nullable<decimal> quantity, Nullable<short> stateID, Nullable<System.Guid> rejectionReasonID, string printName)
        {
            var docIDParameter = docID.HasValue ?
                new ObjectParameter("DocID", docID) :
                new ObjectParameter("DocID", typeof(System.Guid));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(System.Guid));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(decimal));
    
            var stateIDParameter = stateID.HasValue ?
                new ObjectParameter("StateID", stateID) :
                new ObjectParameter("StateID", typeof(short));
    
            var rejectionReasonIDParameter = rejectionReasonID.HasValue ?
                new ObjectParameter("RejectionReasonID", rejectionReasonID) :
                new ObjectParameter("RejectionReasonID", typeof(System.Guid));
    
            var printNameParameter = printName != null ?
                new ObjectParameter("PrintName", printName) :
                new ObjectParameter("PrintName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateDocChangeStateForProduct", docIDParameter, productIDParameter, quantityParameter, stateIDParameter, rejectionReasonIDParameter, printNameParameter);
        }
    
        public virtual int CreateRemainderSpool(Nullable<System.Guid> docID, Nullable<System.Guid> productID, Nullable<System.Guid> parentProductID, Nullable<int> quantity, string printName)
        {
            var docIDParameter = docID.HasValue ?
                new ObjectParameter("DocID", docID) :
                new ObjectParameter("DocID", typeof(System.Guid));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(System.Guid));
    
            var parentProductIDParameter = parentProductID.HasValue ?
                new ObjectParameter("ParentProductID", parentProductID) :
                new ObjectParameter("ParentProductID", typeof(System.Guid));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(int));
    
            var printNameParameter = printName != null ?
                new ObjectParameter("PrintName", printName) :
                new ObjectParameter("PrintName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateRemainderSpool", docIDParameter, productIDParameter, parentProductIDParameter, quantityParameter, printNameParameter);
        }
    
        public virtual ObjectResult<CreateUnloadSpools_Result> CreateUnloadSpools(Nullable<System.Guid> docID, Nullable<System.Guid> productionTaskID, Nullable<int> diameter, Nullable<int> breakNumber)
        {
            var docIDParameter = docID.HasValue ?
                new ObjectParameter("DocID", docID) :
                new ObjectParameter("DocID", typeof(System.Guid));
    
            var productionTaskIDParameter = productionTaskID.HasValue ?
                new ObjectParameter("ProductionTaskID", productionTaskID) :
                new ObjectParameter("ProductionTaskID", typeof(System.Guid));
    
            var diameterParameter = diameter.HasValue ?
                new ObjectParameter("Diameter", diameter) :
                new ObjectParameter("Diameter", typeof(int));
    
            var breakNumberParameter = breakNumber.HasValue ?
                new ObjectParameter("BreakNumber", breakNumber) :
                new ObjectParameter("BreakNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CreateUnloadSpools_Result>("CreateUnloadSpools", docIDParameter, productionTaskIDParameter, diameterParameter, breakNumberParameter);
        }
    
        public virtual ObjectResult<string> DeleteGroupPack(Nullable<System.Guid> productID)
        {
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("DeleteGroupPack", productIDParameter);
        }
    
        public virtual ObjectResult<string> DeleteProductionTaskBatch(Nullable<System.Guid> productionTaskBatchID)
        {
            var productionTaskBatchIDParameter = productionTaskBatchID.HasValue ?
                new ObjectParameter("ProductionTaskBatchID", productionTaskBatchID) :
                new ObjectParameter("ProductionTaskBatchID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("DeleteProductionTaskBatch", productionTaskBatchIDParameter);
        }
    
        public virtual ObjectResult<string> DeleteSpool(Nullable<System.Guid> productID)
        {
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("DeleteSpool", productIDParameter);
        }
    
        public virtual ObjectResult<string> DeleteUnload(Nullable<System.Guid> docID)
        {
            var docIDParameter = docID.HasValue ?
                new ObjectParameter("DocID", docID) :
                new ObjectParameter("DocID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("DeleteUnload", docIDParameter);
        }
    
        public virtual ObjectResult<DocRelations_Result> DocRelations(Nullable<System.Guid> docID)
        {
            var docIDParameter = docID.HasValue ?
                new ObjectParameter("DocID", docID) :
                new ObjectParameter("DocID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DocRelations_Result>("DocRelations", docIDParameter);
        }
    
        public virtual ObjectResult<FindProductionTasks_Result> FindProductionTasks(Nullable<int> batchKindID, Nullable<byte> productionTaskStateID, Nullable<System.DateTime> dateBegin, Nullable<System.DateTime> dateEnd, string number)
        {
            var batchKindIDParameter = batchKindID.HasValue ?
                new ObjectParameter("BatchKindID", batchKindID) :
                new ObjectParameter("BatchKindID", typeof(int));
    
            var productionTaskStateIDParameter = productionTaskStateID.HasValue ?
                new ObjectParameter("ProductionTaskStateID", productionTaskStateID) :
                new ObjectParameter("ProductionTaskStateID", typeof(byte));
    
            var dateBeginParameter = dateBegin.HasValue ?
                new ObjectParameter("DateBegin", dateBegin) :
                new ObjectParameter("DateBegin", typeof(System.DateTime));
    
            var dateEndParameter = dateEnd.HasValue ?
                new ObjectParameter("DateEnd", dateEnd) :
                new ObjectParameter("DateEnd", typeof(System.DateTime));
    
            var numberParameter = number != null ?
                new ObjectParameter("Number", number) :
                new ObjectParameter("Number", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FindProductionTasks_Result>("FindProductionTasks", batchKindIDParameter, productionTaskStateIDParameter, dateBeginParameter, dateEndParameter, numberParameter);
        }
    
        public virtual int GenerateNewNumbersForDoc(Nullable<System.Guid> docID)
        {
            var docIDParameter = docID.HasValue ?
                new ObjectParameter("DocID", docID) :
                new ObjectParameter("DocID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GenerateNewNumbersForDoc", docIDParameter);
        }
    
        public virtual int Get1CNomenclature()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Get1CNomenclature");
        }
    
        public virtual ObjectResult<Nullable<System.Guid>> GetActiveSourceSpools(Nullable<int> placeID)
        {
            var placeIDParameter = placeID.HasValue ?
                new ObjectParameter("PlaceID", placeID) :
                new ObjectParameter("PlaceID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.Guid>>("GetActiveSourceSpools", placeIDParameter);
        }
    
        public virtual ObjectResult<GetCharPropsDescriptions_Result> GetCharPropsDescriptions(Nullable<System.Guid> characteristicID)
        {
            var characteristicIDParameter = characteristicID.HasValue ?
                new ObjectParameter("CharacteristicID", characteristicID) :
                new ObjectParameter("CharacteristicID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCharPropsDescriptions_Result>("GetCharPropsDescriptions", characteristicIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GetCharSpoolLayerNumber(Nullable<System.Guid> characteristicID)
        {
            var characteristicIDParameter = characteristicID.HasValue ?
                new ObjectParameter("CharacteristicID", characteristicID) :
                new ObjectParameter("CharacteristicID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetCharSpoolLayerNumber", characteristicIDParameter);
        }
    
        public virtual ObjectResult<GetDocCloseShiftPMSpools_Result> GetDocCloseShiftPMSpools(Nullable<System.Guid> docID)
        {
            var docIDParameter = docID.HasValue ?
                new ObjectParameter("DocID", docID) :
                new ObjectParameter("DocID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDocCloseShiftPMSpools_Result>("GetDocCloseShiftPMSpools", docIDParameter);
        }
    
        public virtual ObjectResult<GetDocCloseShiftWRGroupPacks_Result> GetDocCloseShiftWRGroupPacks(Nullable<System.Guid> docID)
        {
            var docIDParameter = docID.HasValue ?
                new ObjectParameter("DocID", docID) :
                new ObjectParameter("DocID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDocCloseShiftWRGroupPacks_Result>("GetDocCloseShiftWRGroupPacks", docIDParameter);
        }
    
        public virtual ObjectResult<GetGroupPackSpools_Result> GetGroupPackSpools(Nullable<System.Guid> docID)
        {
            var docIDParameter = docID.HasValue ?
                new ObjectParameter("DocID", docID) :
                new ObjectParameter("DocID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetGroupPackSpools_Result>("GetGroupPackSpools", docIDParameter);
        }
    
        public virtual ObjectResult<GetInputNomenclature_Result> GetInputNomenclature(Nullable<System.Guid> nomenclatureID, Nullable<int> placeGroupID)
        {
            var nomenclatureIDParameter = nomenclatureID.HasValue ?
                new ObjectParameter("NomenclatureID", nomenclatureID) :
                new ObjectParameter("NomenclatureID", typeof(System.Guid));
    
            var placeGroupIDParameter = placeGroupID.HasValue ?
                new ObjectParameter("PlaceGroupID", placeGroupID) :
                new ObjectParameter("PlaceGroupID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetInputNomenclature_Result>("GetInputNomenclature", nomenclatureIDParameter, placeGroupIDParameter);
        }
    
        public virtual ObjectResult<GetNomenclatureFolders_Result> GetNomenclatureFolders(Nullable<int> placeGroupID)
        {
            var placeGroupIDParameter = placeGroupID.HasValue ?
                new ObjectParameter("PlaceGroupID", placeGroupID) :
                new ObjectParameter("PlaceGroupID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetNomenclatureFolders_Result>("GetNomenclatureFolders", placeGroupIDParameter);
        }
    
        public virtual ObjectResult<GetProductionTaskBatchSGBCuttings_Result> GetProductionTaskBatchSGBCuttings(Nullable<System.Guid> productionTaskBatchID)
        {
            var productionTaskBatchIDParameter = productionTaskBatchID.HasValue ?
                new ObjectParameter("ProductionTaskBatchID", productionTaskBatchID) :
                new ObjectParameter("ProductionTaskBatchID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductionTaskBatchSGBCuttings_Result>("GetProductionTaskBatchSGBCuttings", productionTaskBatchIDParameter);
        }
    
        public virtual ObjectResult<GetProductionTaskBatchSGBProperties_Result> GetProductionTaskBatchSGBProperties(Nullable<System.Guid> productionTaskBatchID)
        {
            var productionTaskBatchIDParameter = productionTaskBatchID.HasValue ?
                new ObjectParameter("ProductionTaskBatchID", productionTaskBatchID) :
                new ObjectParameter("ProductionTaskBatchID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductionTaskBatchSGBProperties_Result>("GetProductionTaskBatchSGBProperties", productionTaskBatchIDParameter);
        }
    
        public virtual ObjectResult<GetProductionTaskBatchWRProperties_Result> GetProductionTaskBatchWRProperties(Nullable<System.Guid> productionTaskBatchID)
        {
            var productionTaskBatchIDParameter = productionTaskBatchID.HasValue ?
                new ObjectParameter("ProductionTaskBatchID", productionTaskBatchID) :
                new ObjectParameter("ProductionTaskBatchID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductionTaskBatchWRProperties_Result>("GetProductionTaskBatchWRProperties", productionTaskBatchIDParameter);
        }
    
        public virtual ObjectResult<GetProductionTaskByBatchID_Result> GetProductionTaskByBatchID(Nullable<System.Guid> productionTaskBatchID, Nullable<short> placeGroupID)
        {
            var productionTaskBatchIDParameter = productionTaskBatchID.HasValue ?
                new ObjectParameter("ProductionTaskBatchID", productionTaskBatchID) :
                new ObjectParameter("ProductionTaskBatchID", typeof(System.Guid));
    
            var placeGroupIDParameter = placeGroupID.HasValue ?
                new ObjectParameter("PlaceGroupID", placeGroupID) :
                new ObjectParameter("PlaceGroupID", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductionTaskByBatchID_Result>("GetProductionTaskByBatchID", productionTaskBatchIDParameter, placeGroupIDParameter);
        }
    
        public virtual ObjectResult<GetProductionTaskProducts_Result> GetProductionTaskProducts(Nullable<System.Guid> productionTaskID)
        {
            var productionTaskIDParameter = productionTaskID.HasValue ?
                new ObjectParameter("ProductionTaskID", productionTaskID) :
                new ObjectParameter("ProductionTaskID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductionTaskProducts_Result>("GetProductionTaskProducts", productionTaskIDParameter);
        }
    
        public virtual ObjectResult<GetProductionTasks_Result> GetProductionTasks(Nullable<int> batchKindID)
        {
            var batchKindIDParameter = batchKindID.HasValue ?
                new ObjectParameter("BatchKindID", batchKindID) :
                new ObjectParameter("BatchKindID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductionTasks_Result>("GetProductionTasks", batchKindIDParameter);
        }
    
        public virtual ObjectResult<GetProductRelations_Result> GetProductRelations(Nullable<System.Guid> docID)
        {
            var docIDParameter = docID.HasValue ?
                new ObjectParameter("DocID", docID) :
                new ObjectParameter("DocID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductRelations_Result>("GetProductRelations", docIDParameter);
        }
    
        public virtual ObjectResult<GetSpoolRejectionReasons_Result> GetSpoolRejectionReasons()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSpoolRejectionReasons_Result>("GetSpoolRejectionReasons");
        }
    
        public virtual ObjectResult<Nullable<byte>> UserPermit(string tableName)
        {
            var tableNameParameter = tableName != null ?
                new ObjectParameter("TableName", tableName) :
                new ObjectParameter("TableName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<byte>>("UserPermit", tableNameParameter);
        }
    
        public virtual int mxp_RecreateRolePermits(Nullable<System.Guid> roleID)
        {
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("mxp_RecreateRolePermits", roleIDParameter);
        }
    
        public virtual ObjectResult<ProductRelations_Result> ProductRelations(Nullable<System.Guid> productID)
        {
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductRelations_Result>("ProductRelations", productIDParameter);
        }
    
        public virtual int RecreateUser(Nullable<System.Guid> userID, string password)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(System.Guid));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RecreateUser", userIDParameter, passwordParameter);
        }
    
        public virtual int WriteSpoolInstallLog(Nullable<System.Guid> productID, Nullable<int> placeID, Nullable<int> shiftID, Nullable<byte> unwinderID)
        {
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(System.Guid));
    
            var placeIDParameter = placeID.HasValue ?
                new ObjectParameter("PlaceID", placeID) :
                new ObjectParameter("PlaceID", typeof(int));
    
            var shiftIDParameter = shiftID.HasValue ?
                new ObjectParameter("ShiftID", shiftID) :
                new ObjectParameter("ShiftID", typeof(int));
    
            var unwinderIDParameter = unwinderID.HasValue ?
                new ObjectParameter("UnwinderID", unwinderID) :
                new ObjectParameter("UnwinderID", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WriteSpoolInstallLog", productIDParameter, placeIDParameter, shiftIDParameter, unwinderIDParameter);
        }
    
        public virtual ObjectResult<GetDocCloseShiftConvertingPallets_Result> GetDocCloseShiftConvertingPallets(Nullable<System.Guid> docID)
        {
            var docIDParameter = docID.HasValue ?
                new ObjectParameter("DocID", docID) :
                new ObjectParameter("DocID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDocCloseShiftConvertingPallets_Result>("GetDocCloseShiftConvertingPallets", docIDParameter);
        }
    
        public virtual ObjectResult<FillDocCloseShiftConvertingPallets_Result> FillDocCloseShiftConvertingPallets(Nullable<int> placeID, Nullable<int> shiftID, Nullable<System.DateTime> closeDate)
        {
            var placeIDParameter = placeID.HasValue ?
                new ObjectParameter("PlaceID", placeID) :
                new ObjectParameter("PlaceID", typeof(int));
    
            var shiftIDParameter = shiftID.HasValue ?
                new ObjectParameter("ShiftID", shiftID) :
                new ObjectParameter("ShiftID", typeof(int));
    
            var closeDateParameter = closeDate.HasValue ?
                new ObjectParameter("CloseDate", closeDate) :
                new ObjectParameter("CloseDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FillDocCloseShiftConvertingPallets_Result>("FillDocCloseShiftConvertingPallets", placeIDParameter, shiftIDParameter, closeDateParameter);
        }
    
        public virtual ObjectResult<FillDocCloseShiftConvertingMaterials_Result> FillDocCloseShiftConvertingMaterials(Nullable<int> placeID, Nullable<int> shiftID, Nullable<System.DateTime> closeDate)
        {
            var placeIDParameter = placeID.HasValue ?
                new ObjectParameter("PlaceID", placeID) :
                new ObjectParameter("PlaceID", typeof(int));
    
            var shiftIDParameter = shiftID.HasValue ?
                new ObjectParameter("ShiftID", shiftID) :
                new ObjectParameter("ShiftID", typeof(int));
    
            var closeDateParameter = closeDate.HasValue ?
                new ObjectParameter("CloseDate", closeDate) :
                new ObjectParameter("CloseDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FillDocCloseShiftConvertingMaterials_Result>("FillDocCloseShiftConvertingMaterials", placeIDParameter, shiftIDParameter, closeDateParameter);
        }
    
        public virtual ObjectResult<GetMaterialNomenclatureFolders_Result> GetMaterialNomenclatureFolders(Nullable<int> materialTypeID)
        {
            var materialTypeIDParameter = materialTypeID.HasValue ?
                new ObjectParameter("MaterialTypeID", materialTypeID) :
                new ObjectParameter("MaterialTypeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetMaterialNomenclatureFolders_Result>("GetMaterialNomenclatureFolders", materialTypeIDParameter);
        }
    
        public virtual ObjectResult<FindNomenclatureByStringWithFilter_Result> FindNomenclatureByStringWithFilter(string @string, Nullable<int> iD, Nullable<bool> filterByPlaceGroup)
        {
            var stringParameter = @string != null ?
                new ObjectParameter("String", @string) :
                new ObjectParameter("String", typeof(string));
    
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var filterByPlaceGroupParameter = filterByPlaceGroup.HasValue ?
                new ObjectParameter("FilterByPlaceGroup", filterByPlaceGroup) :
                new ObjectParameter("FilterByPlaceGroup", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FindNomenclatureByStringWithFilter_Result>("FindNomenclatureByStringWithFilter", stringParameter, iDParameter, filterByPlaceGroupParameter);
        }
    
        public virtual ObjectResult<GetBatchProducts_Result> GetBatchProducts(Nullable<System.Guid> productionTaskBatchID)
        {
            var productionTaskBatchIDParameter = productionTaskBatchID.HasValue ?
                new ObjectParameter("ProductionTaskBatchID", productionTaskBatchID) :
                new ObjectParameter("ProductionTaskBatchID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBatchProducts_Result>("GetBatchProducts", productionTaskBatchIDParameter);
        }
    
        public virtual ObjectResult<CheckProductionTaskSourceSpools_Result> CheckProductionTaskSourceSpools(Nullable<int> placeID, Nullable<System.Guid> productionTaskID)
        {
            var placeIDParameter = placeID.HasValue ?
                new ObjectParameter("PlaceID", placeID) :
                new ObjectParameter("PlaceID", typeof(int));
    
            var productionTaskIDParameter = productionTaskID.HasValue ?
                new ObjectParameter("ProductionTaskID", productionTaskID) :
                new ObjectParameter("ProductionTaskID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CheckProductionTaskSourceSpools_Result>("CheckProductionTaskSourceSpools", placeIDParameter, productionTaskIDParameter);
        }
    
        public virtual ObjectResult<GetCharacteristicsForProdTaskPM_Result> GetCharacteristicsForProdTaskPM(Nullable<System.Guid> nomenclatureID, string color, string buyer, Nullable<int> placeID)
        {
            var nomenclatureIDParameter = nomenclatureID.HasValue ?
                new ObjectParameter("NomenclatureID", nomenclatureID) :
                new ObjectParameter("NomenclatureID", typeof(System.Guid));
    
            var colorParameter = color != null ?
                new ObjectParameter("Color", color) :
                new ObjectParameter("Color", typeof(string));
    
            var buyerParameter = buyer != null ?
                new ObjectParameter("Buyer", buyer) :
                new ObjectParameter("Buyer", typeof(string));
    
            var placeIDParameter = placeID.HasValue ?
                new ObjectParameter("PlaceID", placeID) :
                new ObjectParameter("PlaceID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCharacteristicsForProdTaskPM_Result>("GetCharacteristicsForProdTaskPM", nomenclatureIDParameter, colorParameter, buyerParameter, placeIDParameter);
        }
    
        public virtual int UploadDocCloseShiftReportTo1C(Nullable<System.Guid> docID)
        {
            var docIDParameter = docID.HasValue ?
                new ObjectParameter("DocID", docID) :
                new ObjectParameter("DocID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UploadDocCloseShiftReportTo1C", docIDParameter);
        }
    
        public virtual ObjectResult<GetOldProductInfo_Result> GetOldProductInfo(string number, Nullable<int> productKindId)
        {
            var numberParameter = number != null ?
                new ObjectParameter("Number", number) :
                new ObjectParameter("Number", typeof(string));
    
            var productKindIdParameter = productKindId.HasValue ?
                new ObjectParameter("ProductKindId", productKindId) :
                new ObjectParameter("ProductKindId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOldProductInfo_Result>("GetOldProductInfo", numberParameter, productKindIdParameter);
        }
    
        public virtual int SaveOldProductToNewBase(Nullable<long> id, Nullable<int> productKindId, Nullable<System.Guid> nomenclatureID, Nullable<System.Guid> characteristicID)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(long));
    
            var productKindIdParameter = productKindId.HasValue ?
                new ObjectParameter("ProductKindId", productKindId) :
                new ObjectParameter("ProductKindId", typeof(int));
    
            var nomenclatureIDParameter = nomenclatureID.HasValue ?
                new ObjectParameter("NomenclatureID", nomenclatureID) :
                new ObjectParameter("NomenclatureID", typeof(System.Guid));
    
            var characteristicIDParameter = characteristicID.HasValue ?
                new ObjectParameter("CharacteristicID", characteristicID) :
                new ObjectParameter("CharacteristicID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveOldProductToNewBase", idParameter, productKindIdParameter, nomenclatureIDParameter, characteristicIDParameter);
        }
    
        public virtual ObjectResult<Nullable<System.Guid>> CreateGroupPackWithSpool(Nullable<System.Guid> spoolID, string printName)
        {
            var spoolIDParameter = spoolID.HasValue ?
                new ObjectParameter("SpoolID", spoolID) :
                new ObjectParameter("SpoolID", typeof(System.Guid));
    
            var printNameParameter = printName != null ?
                new ObjectParameter("PrintName", printName) :
                new ObjectParameter("PrintName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.Guid>>("CreateGroupPackWithSpool", spoolIDParameter, printNameParameter);
        }
    }
}
