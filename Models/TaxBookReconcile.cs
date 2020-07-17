using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlan.OData.Models
{
    //"TAX_INCLUDE_ID", "TAX_YEAR", "TAX_RECORD_ID", "RECONCILE_ITEM_ID"
    public partial class TaxBookReconcile : IGenericODataModel
    {
        [Key, Column(Order = 0)]
        public long TaxIncludeId { get; set; }
        [Key, Column(Order = 1)]
        public decimal TaxYear { get; set; }
        [Key, Column(Order = 2)]
        public long TaxRecordId { get; set; }
        [Key, Column(Order = 3)]
        public long ReconcileItemId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public decimal? BasisAmountBeg { get; set; }
        public decimal? BasisAmountEnd { get; set; }
        public decimal? BasisAmountActivity { get; set; }
        public decimal? BasisAmountInputRetire { get; set; }
        public decimal? BasisAmountTransfer { get; set; }
    }
}
