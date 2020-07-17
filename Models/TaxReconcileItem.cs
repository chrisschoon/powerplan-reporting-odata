using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxReconcileItem : IGenericODataModel
    {
        [Key]
        public long ReconcileItemId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public byte? InputRetireInd { get; set; }
        public long? DefaultTaxIncludeId { get; set; }
        public long? TaxTypeOfPropertyId { get; set; }
        public long? NetBasisRpt { get; set; }
        public long? Calced { get; set; }
        public long? DeprDeduction { get; set; }
        public long K1ExportGenInclude { get; set; }
    }
}
