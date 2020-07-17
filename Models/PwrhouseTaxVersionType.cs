using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class PwrhouseTaxVersionType : IGenericODataModel
    {
        [Key]
        public decimal? VersionTypeId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
    }
}
