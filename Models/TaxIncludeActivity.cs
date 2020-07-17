using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlan.OData.Models
{
    //"TAX_INCLUDE_ID", "TAX_BOOK_ID"
    public partial class TaxIncludeActivity : IGenericODataModel
    {
        [Key, Column(Order = 0)]
        public long TaxIncludeId { get; set; }
        [Key, Column(Order = 1)]
        public long TaxBookId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
    }
}
