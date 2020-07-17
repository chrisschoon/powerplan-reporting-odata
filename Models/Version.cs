using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class Version : IGenericODataModel
    {
        [Key]
        public long VersionId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public long? PriorVersionId { get; set; }
        public string LongDescription { get; set; }
        public long Official { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? LastYear { get; set; }
        public long? Status { get; set; }
        public long VersionTypeId { get; set; }
        public decimal? ActualsMonth { get; set; }
    }
}
