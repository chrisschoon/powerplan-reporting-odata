using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlan.OData.Models
{
    //"TAX_TRANSFER_ID", "TAX_RECORD_ID", "TAX_MONTH", "NORMALIZATION_ID"
    public partial class DeferredIncomeTaxTransfer : IGenericODataModel
    {
        [Key, Column(Order = 0)]
        public long TaxTransferId { get; set; }
        [Key, Column(Order = 1)]
        public long TaxRecordId { get; set; }
        public decimal TaxYear { get; set; }
        [Key, Column(Order = 2)]
        public long TaxMonth { get; set; }
        [Key, Column(Order = 3)]
        public long NormalizationId { get; set; }
        public long? TimeSliceId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public decimal? DefIncomeTaxBalanceBeg { get; set; }
        public decimal? NormDiffBalanceBeg { get; set; }
        public decimal? Life { get; set; }
    }
}
