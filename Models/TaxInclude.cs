using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxInclude : IGenericODataModel
    {
        [Key]
        public long TaxIncludeId { get; set; }
        public string Description { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
    }
}
