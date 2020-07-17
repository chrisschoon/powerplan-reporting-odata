using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxConvention : IGenericODataModel
    {
        [Key]
        public long ConventionId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public long? RetireDeprId { get; set; }
        public long? RetireBalId { get; set; }
        public long? RetireReserveId { get; set; }
        public long? GainLossId { get; set; }
        public long? SalvageId { get; set; }
        public long? EstSalvageId { get; set; }
        public long? CapGainId { get; set; }
        public long? CostOfRemovalId { get; set; }
        public byte? TaxConventionLock { get; set; }
    }
}
