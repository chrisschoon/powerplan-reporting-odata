using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlan.OData.Models
{
    //"TAX_TRANSFER_ID", "TAX_INCLUDE_ID", "TAX_RECORD_ID", "RECONCILE_ITEM_ID"
    public partial class TaxBookReconcileTransfer : IGenericODataModel
    {
        [Key, Column(Order = 0)]
        public long TaxTransferId { get; set; }
        [Key, Column(Order = 1)]
        public long TaxIncludeId { get; set; }
        public decimal TaxYear { get; set; }
        [Key, Column(Order = 2)]
        public long TaxRecordId { get; set; }
        [Key, Column(Order = 3)]
        public long ReconcileItemId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public decimal? BasisAmountBeg { get; set; }
        public decimal? Additions { get; set; }
    }
}
