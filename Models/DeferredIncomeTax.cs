using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlan.OData.Models
{
    //"TAX_RECORD_ID", "TAX_YEAR", "TAX_MONTH", "NORMALIZATION_ID"
    public partial class DeferredIncomeTax : IGenericODataModel
    {
        [Key, Column(Order = 0)]
        public long TaxRecordId { get; set; }
        [Key, Column(Order = 1)]
        public decimal TaxYear { get; set; }
        [Key, Column(Order = 2)]
        public long? TaxMonth { get; set; }
        [Key, Column(Order = 3)]
        public long NormalizationId { get; set; }
        public long? TimeSliceId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public decimal? DefIncomeTaxBalanceBeg { get; set; }
        public decimal? DefIncomeTaxBalanceEnd { get; set; }
        public decimal? NormDiffBalanceBeg { get; set; }
        public decimal? NormDiffBalanceEnd { get; set; }
        public decimal? DefIncomeTaxProvision { get; set; }
        public decimal? DefIncomeTaxReversal { get; set; }
        public decimal? AramRate { get; set; }
        public decimal? AramRateEnd { get; set; }
        public decimal? Life { get; set; }
        public decimal? DefIncomeTaxRetire { get; set; }
        public decimal? DefIncomeTaxAdjust { get; set; }
        public decimal? DefIncomeTaxGainLoss { get; set; }
        public decimal? GainLossDefTaxBalance { get; set; }
        public decimal? GainLossDefTaxBalanceEnd { get; set; }
        public decimal? BasisDiffAddRet { get; set; }
        public decimal? InputAmortization { get; set; }
        public decimal? BasisDiffRetireReversal { get; set; }
    }
}
