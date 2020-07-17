using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlan.OData.Models
{
    //"USERS", "COMPANY_ID"
    public partial class PpCompanySecurity : IGenericODataModel
    {
        [Key, Column(Order = 0)]
        public string Users { get; set; }
        [Key, Column(Order = 1)]
        public long CompanyId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
    }
}
