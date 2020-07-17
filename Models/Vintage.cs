using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class Vintage : IGenericODataModel
    {
        [Key]
        public long VintageId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public long? Year { get; set; }
        public byte? StartMonth { get; set; }
        public byte? EndMonth { get; set; }
        public string ExtClassCodeValue { get; set; }
        public long? BonusStartMonth { get; set; }
        public long? BonusEndMonth { get; set; }
        public long? VintageConventionId { get; set; }
    }
}
