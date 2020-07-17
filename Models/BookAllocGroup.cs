using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class BookAllocGroup : IGenericODataModel
    {
        [Key]
        public long BookAllocGroupId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public long CompanyId { get; set; }
        public long? MortalityCurveId { get; set; }
        public int? Life { get; set; }
        public decimal? AllocatedAmount { get; set; }
        public long? HwTableLineId { get; set; }
        public long? HwRegionId { get; set; }
        public long? SubledgerTypeId { get; set; }
    }
}
