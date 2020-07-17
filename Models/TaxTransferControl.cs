using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxTransferControl : IGenericODataModel
    {
        [Key]
        public long TaxTransferId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public decimal TaxYear { get; set; }
        public long FromTrid { get; set; }
        public long ToTrid { get; set; }
        public decimal? BookAmount { get; set; }
        public decimal? StatusId { get; set; }
        public string StatusComment { get; set; }
        public long? ToTridOffset { get; set; }
        public string TransferType { get; set; }
        public long? PackageId { get; set; }
        public long? ToTridDefGain { get; set; }
        public decimal? Proceeds { get; set; }
        public long? CreateToTrid { get; set; }
        public long? VersionId { get; set; }
        public decimal? SequenceNumber { get; set; }
        public long? CalcDeferredGain { get; set; }
        public decimal? DeferredGainAmount { get; set; }
        public long? CompanyId { get; set; }
        public long? TaxClassId { get; set; }
        public long? TaxDeprSchemaIdFrom { get; set; }
        public long? TaxDeprSchemaIdTo { get; set; }
        public long? DefGainFromTaxClass { get; set; }
        public long? DefGainToTaxClass { get; set; }
        public long? DeferredTaxSchemaId { get; set; }
        public string Notes { get; set; }
        public long? DefGainVintageId { get; set; }
        public long? TaxLayerId { get; set; }
        public long? AssetId { get; set; }
        public DateTime? InServiceMonth { get; set; }
        public DateTime? TransferMonth { get; set; }
    }
}
