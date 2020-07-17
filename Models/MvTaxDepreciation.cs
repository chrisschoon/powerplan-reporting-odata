using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlan.OData.Models
{
    //"TAX_BOOK_ID", "TAX_YEAR", "TAX_RECORD_ID"
    public partial class MvTaxDepreciation : IGenericODataModel
    {
        [Key, Column(Order = 0)]
        public long TaxRecordId { get; set; }
        public string CompanyDescription { get; set; }
        public string VersionDescription { get; set; }
        public string TaxClassDescription { get; set; }
        public long? VintageYear { get; set; }
        public string VintageDescription { get; set; }
        public string BookAllocGroupDescription { get; set; }
        public string TaxBookDescription { get; set; }
        public string TaxConventionDescription { get; set; }
        public string ExtConventionDescription { get; set; }
        public string TaxRateDescription { get; set; }
        public string TaxLawDescription { get; set; }
        public string TaxLimitDescription { get; set; }
        public string Summary4562Description { get; set; }
        public string RecoveryPeriodDescription { get; set; }
        public string TypeOfPropertyDescription { get; set; }
        public string TaxCreditDescription { get; set; }
        public string DefTaxSchemaDescription { get; set; }
        [Key, Column(Order = 1)]
        public decimal TaxYear { get; set; }
        public string TaxReconcileItemDescription { get; set; }
        public decimal? BookBalance { get; set; }
        public decimal? BookBalanceEnd { get; set; }
        public decimal? TaxBalance { get; set; }
        public decimal? TaxBalanceEnd { get; set; }
        public decimal? TaxAdditions { get; set; }
        public decimal? TaxRetirements { get; set; }
        public decimal? ExtraordinaryRetires { get; set; }
        public decimal? RetireReserveImpact { get; set; }
        public decimal? DepreciableBase { get; set; }
        public decimal? Depreciation { get; set; }
        public decimal? AccumReserve { get; set; }
        public decimal? AccumReserveEnd { get; set; }
        public decimal? GainLoss { get; set; }
        public decimal? ActualSalvage { get; set; }
        public decimal? ExtraordinarySalvage { get; set; }
        public decimal? CostOfRemoval { get; set; }
        public decimal? CorReserveImpact { get; set; }
        public decimal? AccumOrdinaryRetires { get; set; }
        public decimal? AccumOrdinRetiresEnd { get; set; }
        public decimal? AccumReserveAdjust { get; set; }
        public decimal? CorExpense { get; set; }
        public decimal? BasisAmountActivity { get; set; }
        public decimal? CapitalizedDepr { get; set; }
        public decimal? Activity { get; set; }
        public decimal? Adjustments { get; set; }
        public decimal? BookAdditions { get; set; }
        public decimal? BookAdjustments { get; set; }
        public decimal? BookTransfersIn { get; set; }
        public decimal? BookTransfersOut { get; set; }
        public decimal? BookRetirements { get; set; }
        public decimal? BookExtRetirements { get; set; }
        public decimal? BookTestRetirements { get; set; }
        public decimal? SalvageSalePrice { get; set; }
        public decimal? DepreciationAllowed { get; set; }
        public decimal? TaxRetirementsWithCor { get; set; }
        public decimal? GainLossLessCor { get; set; }
        public decimal? CapitalGainLoss { get; set; }
        public decimal? RetirementsFromBasis { get; set; }
        public decimal? AdditionsTransfer { get; set; }
        public decimal? BookBalanceTransfer { get; set; }
        public decimal? TaxBalanceTransfer { get; set; }
        public decimal? AccumReserveTransfer { get; set; }
        public decimal? SlReserveTransfer { get; set; }
        public decimal? FixedDeprBaseTransfer { get; set; }
        public decimal? EstimatedSalvageTransfer { get; set; }
        public decimal? AccumSalvageTransfer { get; set; }
        public decimal? AccumOrdRetiresTransfer { get; set; }
        public decimal? ReserveAtSwitchTransfer { get; set; }
        public long? QuantityTransfer { get; set; }
        public decimal? CalcDepreciationTransfer { get; set; }
        [Key, Column(Order = 2)]
        public long TaxBookId { get; set; }
        public long ConventionId { get; set; }
        public long ExtConventionId { get; set; }
        public long TaxRateId { get; set; }
        public long? TaxLawId { get; set; }
        public long? TaxLimitId { get; set; }
        public long? Summary4562Id { get; set; }
        public long? RecoveryPeriodId { get; set; }
        public long? TypeOfPropertyId { get; set; }
        public long? TaxCreditId { get; set; }
        public long? DeferredTaxSchemaId { get; set; }
        public long VersionId { get; set; }
        public long VintageId { get; set; }
        public long TaxClassId { get; set; }
        public long CompanyId { get; set; }
        public long? ReconcileItemId { get; set; }

        public virtual TaxBook TaxBook { get; set; }
    }
}
