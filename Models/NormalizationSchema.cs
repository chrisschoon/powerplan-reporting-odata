using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class NormalizationSchema : IGenericODataModel
    {
        [Key]
        public long NormalizationId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public long JurisdictionId { get; set; }
        public long? NormFromTax { get; set; }
        public long? NormToTax { get; set; }
        public long? DefaultGlBalanceAcct { get; set; }
        public long? DefaultGlExpenseAcct { get; set; }
        public long? DefIncomeTaxRateId { get; set; }
        public long? AmortizationTypeId { get; set; }
        public long? ReconcileItemId { get; set; }
        public byte? BookDeprAllocInd { get; set; }
        public decimal? CostOfRemovalFt { get; set; }
        public long? GlAccountId { get; set; }
        public byte? BasisDiffRetireReversal { get; set; }
        public byte? CapDeprInd { get; set; }
        public long? NoZeroCheck { get; set; }
        public long? NormTypeId { get; set; }
        public long? MidFrom { get; set; }
        public long? MidTo { get; set; }
        public long? MidDefTax { get; set; }
        public long? MidDefTaxOther { get; set; }
        public long? MidNormId { get; set; }
        public long? BasisDiffActivitySplit { get; set; }
    }
}
