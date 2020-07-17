using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlan.OData.Models
{
    //"TAX_INCLUDE_ID", "TAX_RECORD_ID", "TAX_YEAR", "TAX_ACTIVITY_CODE_ID"
    public partial class BasisAmounts : IGenericODataModel
    {
        [Key, Column(Order = 0)]
        public long TaxIncludeId { get; set; }
        [Key, Column(Order = 1)]
        public long TaxRecordId { get; set; }
        [Key, Column(Order = 2)]
        public decimal TaxYear { get; set; }
        [Key, Column(Order = 3)]
        public long TaxActivityCodeId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public decimal? Amount { get; set; }
        public long? TaxSummaryId { get; set; }
    }
}
