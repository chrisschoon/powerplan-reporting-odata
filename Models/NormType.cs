using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class NormType : IGenericODataModel
    {
        [Key]
        public long NormTypeId { get; set; }
        public string Description { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
    }
}
