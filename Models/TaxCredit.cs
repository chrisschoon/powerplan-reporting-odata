using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxCredit : IGenericODataModel
    {
        [Key]
        public long? TaxCreditId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string ExtTaxCredit { get; set; }
    }
}
