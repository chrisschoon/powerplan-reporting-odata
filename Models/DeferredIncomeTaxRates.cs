using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlan.OData.Models
{
    //"DEF_INCOME_TAX_RATE_ID", "EFFECTIVE_DATE"
    public partial class DeferredIncomeTaxRates : IGenericODataModel
    {
        [Key, Column(Order = 0)]
        public long DefIncomeTaxRateId { get; set; }
        [Key, Column(Order = 1)]
        public DateTime EffectiveDate { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public decimal? MonthlyRate { get; set; }
        public decimal? AnnualRate { get; set; }
        public decimal? StatutoryRate { get; set; }
        public decimal? GrossupRate { get; set; }
        public decimal? AllocationFactor { get; set; }
        public decimal? BaseRate1 { get; set; }
        public decimal? BaseRate2 { get; set; }
        public decimal? BaseRate3 { get; set; }
        public decimal? BaseRate4 { get; set; }
        public decimal? BaseRate5 { get; set; }
        public decimal? BaseRate6 { get; set; }
        public decimal? BaseRate7 { get; set; }
        public decimal? BaseRate8 { get; set; }
        public decimal? BaseRate9 { get; set; }
        public decimal? BaseRate10 { get; set; }
    }
}
