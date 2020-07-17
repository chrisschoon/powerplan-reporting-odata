using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class BookAllocAssign : IGenericODataModel
    {
        [Key]
        public long BookAllocAssignId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public long? TaxClassId { get; set; }
        public long? CompanyId { get; set; }
        public long? BookAllocGroupId { get; set; }
    }
}
