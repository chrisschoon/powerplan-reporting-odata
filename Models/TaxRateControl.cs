using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxRateControl : IGenericODataModel
    {
        [Key]
        public long TaxRateId { get; set; }
        public long? StartMethod { get; set; }
        public long? SwitchToMethod { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string NetGross { get; set; }
        public long? SwitchYear { get; set; }
        public long? SwitchedYear { get; set; }
        public decimal? Life { get; set; }
        public long? HalfYearConvention { get; set; }
        public long? RoundingConvention { get; set; }
        public long? RemainingLifePlan { get; set; }
        public byte? TaxRateLock { get; set; }
        public string ExtTaxRate { get; set; }
    }
}
