using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class PwrhouseTaxYear : IGenericODataModel
    {
        [Key]
        public decimal? TaxYear { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
    }
}
