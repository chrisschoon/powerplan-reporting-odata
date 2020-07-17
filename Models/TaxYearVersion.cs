using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxYearVersion : IGenericODataModel
    {
        [Key]
        public long TaxYearVersionId { get; set; }
        public long? VersionId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public decimal? TaxYear { get; set; }
        public long TaxYearLock { get; set; }
        public decimal? Months { get; set; }
    }
}
