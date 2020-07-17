using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlan.OData.Models
{
    //"TAX_TRANSFER_ID", "TAX_BOOK_ID", "TAX_RECORD_ID"
    public partial class TaxDepreciationTransfer : IGenericODataModel
    {

        [Key, Column(Order = 0)]
        public long TaxTransferId { get; set; }
        [Key, Column(Order = 1)]
        public long TaxBookId { get; set; }
        public decimal TaxYear { get; set; }
        [Key, Column(Order = 2)]
        public long TaxRecordId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public decimal? BookBalance { get; set; }
        public decimal? TaxBalance { get; set; }
        public decimal? AccumReserve { get; set; }
        public decimal? SlReserve { get; set; }
        public decimal? FixedDepreciableBase { get; set; }
        public decimal? EstimatedSalvage { get; set; }
        public decimal? AccumSalvage { get; set; }
        public decimal? AccumOrdinaryRetires { get; set; }
        public decimal? ReserveAtSwitch { get; set; }
        public long? Quantity { get; set; }
        public decimal? Additions { get; set; }
        public decimal? CalcDepreciation { get; set; }
    }
}
