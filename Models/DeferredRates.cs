using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class DeferredRates : IGenericODataModel
    {
        [Key]
        public long DefIncomeTaxRateId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public long? NormalizationPctId { get; set; }
        public long? JurAlloId { get; set; }
    }
}
