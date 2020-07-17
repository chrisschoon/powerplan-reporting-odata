using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class Jurisdiction : IGenericODataModel
    {
        [Key]
        public long JurisdictionId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public long? TaxBookId { get; set; }
        public long? BookBookId { get; set; }
        public long? IncludeRwip { get; set; }
        public long? CompanyId { get; set; }
        public decimal? BookDeprAllocInd { get; set; }
        public long? StatutoryTransfer { get; set; }
    }
}
