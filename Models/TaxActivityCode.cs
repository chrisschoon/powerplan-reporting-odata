using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxActivityCode : IGenericODataModel
    {
        [Key]
        public long TaxActivityCodeId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public long? Sign { get; set; }
        public long? TaxActivityTypeId { get; set; }
    }
}
