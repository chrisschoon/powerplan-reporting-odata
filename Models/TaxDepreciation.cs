using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlan.OData.Models
{
    //"TAX_BOOK_ID", "TAX_YEAR", "TAX_RECORD_ID"
    public partial class TaxDepreciation : IGenericODataModel
    {
        [Key, Column(Order = 0)]
        public long TaxBookId { get; set; }
        [Key, Column(Order = 1)]
        public decimal TaxYear { get; set; }
        [Key, Column(Order = 2)]
        public long TaxRecordId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public long? TypeOfPropertyId { get; set; }
        public long? TaxLawId { get; set; }
        public long ConventionId { get; set; }
        public long ExtraordinaryConvention { get; set; }
        public long TaxRateId { get; set; }
        public long? RemainingLifeIndicator { get; set; }
        public long? TaxLimitId { get; set; }
        public long? Summary4562Id { get; set; }
        public long? ListedPropertyInd { get; set; }
        public long? RecoveryPeriodId { get; set; }
        public long? TaxCreditId { get; set; }
        public long? DeferredTaxSchemaId { get; set; }
        public decimal? BookBalance { get; set; }
        public decimal? TaxBalance { get; set; }
        public decimal? RemainingLife { get; set; }
        public decimal? AccumReserve { get; set; }
        public decimal? SlReserve { get; set; }
        public decimal? DepreciableBase { get; set; }
        public decimal? FixedDepreciableBase { get; set; }
        public decimal? ActualSalvage { get; set; }
        public decimal? EstimatedSalvage { get; set; }
        public decimal? AccumSalvage { get; set; }
        public decimal? Additions { get; set; }
        public decimal? Transfers { get; set; }
        public decimal? Adjustments { get; set; }
        public decimal? Retirements { get; set; }
        public decimal? ExtraordinaryRetires { get; set; }
        public decimal? AccumOrdinaryRetires { get; set; }
        public decimal? Depreciation { get; set; }
        public decimal? CostOfRemoval { get; set; }
        public decimal? CorExpense { get; set; }
        public decimal? GainLoss { get; set; }
        public decimal? CapitalGainLoss { get; set; }
        public decimal? EstSalvagePct { get; set; }
        public decimal? BookBalanceEnd { get; set; }
        public decimal? TaxBalanceEnd { get; set; }
        public decimal? AccumReserveEnd { get; set; }
        public decimal? AccumSalvageEnd { get; set; }
        public decimal? AccumOrdinRetiresEnd { get; set; }
        public decimal? SlReserveEnd { get; set; }
        public decimal? RetireInvolConv { get; set; }
        public decimal? SalvageInvolConv { get; set; }
        public decimal? SalvageExtraord { get; set; }
        public decimal? CalcDepreciation { get; set; }
        public decimal? OverAdjDepreciation { get; set; }
        public decimal? RetireResImpact { get; set; }
        public decimal? TransferResImpact { get; set; }
        public decimal? SalvageResImpact { get; set; }
        public decimal? CorResImpact { get; set; }
        public decimal? AdjustedRetireBasis { get; set; }
        public decimal? ReserveAtSwitch { get; set; }
        public long? Quantity { get; set; }
        public decimal? CapitalizedDepr { get; set; }
        public decimal? ReserveAtSwitchEnd { get; set; }
        public decimal? NumberMonthsBeg { get; set; }
        public decimal? NumberMonthsEnd { get; set; }
        public decimal? ExRetireResImpact { get; set; }
        public decimal? ExGainLoss { get; set; }
        public decimal? QuantityEnd { get; set; }
        public decimal? EstimatedSalvageEnd { get; set; }
        public decimal? JobCreationAmount { get; set; }
        public decimal? BookBalanceAdjust { get; set; }
        public decimal? AccumReserveAdjust { get; set; }
        public decimal? DepreciableBaseAdjust { get; set; }
        public decimal? DepreciationAdjust { get; set; }
        public decimal? GainLossAdjust { get; set; }
        public decimal? CapGainLossAdjust { get; set; }
        public long? BookBalanceAdjustMethod { get; set; }
        public long? AccumReserveAdjustMethod { get; set; }
        public long? DepreciableBaseAdjustMethod { get; set; }
        public long? DepreciationAdjustMethod { get; set; }
        public long? TaxLayerId { get; set; }
        public decimal? TransferDepr { get; set; }
    }
}
