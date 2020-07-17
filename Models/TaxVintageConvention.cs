using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxVintageConvention : IGenericODataModel
    {
        [Key]
        public long VintageConventionId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
    }
}
