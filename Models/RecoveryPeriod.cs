using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class RecoveryPeriod : IGenericODataModel
    {
        [Key]
        public long RecoveryPeriodId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public long? Period { get; set; }
        public string Description { get; set; }
    }
}
