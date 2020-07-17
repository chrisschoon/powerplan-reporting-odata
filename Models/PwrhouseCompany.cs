using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class PwrhouseCompany : IGenericODataModel
    {
        [Key]
        public long? CompanyId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
    }
}
