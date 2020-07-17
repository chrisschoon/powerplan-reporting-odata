using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxLimit : IGenericODataModel
    {
        [Key]
        public long TaxLimitId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public decimal? TaxCreditPercent { get; set; }
        public decimal? BasisReductionPercent { get; set; }
        public long? ReconcileItemId { get; set; }
        public long? TaxIncludeId { get; set; }
        public long? CalcFutureYears { get; set; }
        public long? CompareRate { get; set; }
    }
}
