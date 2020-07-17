using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerPlan.OData.Models
{
    // ? "TAX_RECORD_ID", "TAX_YEAR", "TAX_MONTH", "NORMALIZATION_ID"

    public partial class MvDeferredIncomeTaxDetails : IGenericODataModel
    {
        [Key, Column(Order = 0)]
        public long TaxRecordId { get; set; }
        public string CompanyDescription { get; set; }
        public long CompanyId { get; set; }
        public string TaxClassDescription { get; set; }
        public long TaxClassId { get; set; }
        public string VintageDescription { get; set; }
        public long? VintageYear { get; set; }
        public long VintageId { get; set; }
        public string TaxLocationDescription { get; set; }
        public long? TaxLocationId { get; set; }
        public long VersionId { get; set; }
        public string VersionDescription { get; set; }
        public string BookAllocGroupDescription { get; set; }
        public long? BookAllocGroupId { get; set; }
        public string NormalizationSchemaDesc { get; set; }
        public string JurisdictionDescription { get; set; }
        public string FromBookDescription { get; set; }
        public int? FromReportIndicator { get; set; }
        public string ToBookDescription { get; set; }
        public int? ToReportIndicator { get; set; }
        public string DeferredTaxRateDescription { get; set; }
        public string AmortizationTypeDescription { get; set; }
        public string TaxReconcileItemDescription { get; set; }
        public string NormTypeDescription { get; set; }
        public string AllocateBookDepreciation { get; set; }
        public string IncludeCapitalizedDepr { get; set; }
        public string AllowOverReversal { get; set; }
        public string BasisDiffRetirementReversal { get; set; }
        public string NetBasisDifferenceActivity { get; set; }
        public string JurisdictionTaxBookDesc { get; set; }
        public long JurisdictionTaxBookId { get; set; }
        [Key, Column(Order = 3)]
        public long NormalizationId { get; set; }
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
        [Key, Column(Order = 1)]
        public decimal TaxYear { get; set; }
        [Key, Column(Order = 2)]
        public long? TaxMonth { get; set; }
        public long? TimeSliceId { get; set; }
        public decimal? BeginningDifference { get; set; }
        public decimal? CurrentDifference { get; set; }
        public decimal? EndingDifference { get; set; }
        public decimal? Apb11BegDefTaxBalance { get; set; }
        public decimal? Apb11CurrentDefTaxBalance { get; set; }
        public decimal? Apb11EndDefTaxBalance { get; set; }
        public decimal? Fas109BegDefTaxBalance { get; set; }
        public decimal? Fas109EndDefTaxBalance { get; set; }
        public decimal? RegulatoryAsset { get; set; }
        public decimal? RegulatoryLiability { get; set; }
        public decimal? RegulatoryAssetGrossup { get; set; }
        public decimal? RegulatoryLiabilityGrossup { get; set; }
        public decimal? DefIncomeTaxProvision { get; set; }
        public decimal? DefIncomeTaxReversal { get; set; }
        public decimal? AramRate { get; set; }
        public decimal? AramRateEnd { get; set; }
        public decimal? Life { get; set; }
        public decimal? DefIncomeTaxRetire { get; set; }
        public decimal? DefIncomeTaxAdjust { get; set; }
        public decimal? DefIncomeTaxGainLoss { get; set; }
        public decimal? GainLossDefTaxBalance { get; set; }
        public decimal? GainLossDefTaxBalanceEnd { get; set; }
        public decimal? BasisDiffAddRet { get; set; }
        public decimal? InputAmortization { get; set; }
        public decimal? DitBasisDiffRetireReversal { get; set; }
        public decimal? StatutoryRate { get; set; }
        public decimal? GrossupRate { get; set; }
        public decimal? ComplianceTaxBeg { get; set; }
        public decimal? ComplianceTaxReserveBeg { get; set; }
        public decimal? GrossTaxBeg { get; set; }
        public decimal? TaxReserveBeg { get; set; }
        public decimal? NetTaxBeg { get; set; }
        public decimal? FinancialBookBasisBeg { get; set; }
        public decimal? FinancialBookReserveBeg { get; set; }
        public decimal? GrossBookBeg { get; set; }
        public decimal? BookReserveBeg { get; set; }
        public decimal? NetBookBeg { get; set; }
        public decimal? CalcedTimingDiffBeg { get; set; }
        public decimal? ActualTimingDiffBeg { get; set; }
        public decimal? ComplianceTaxEnd { get; set; }
        public decimal? ComplianceTaxReserveEnd { get; set; }
        public decimal? GrossTaxEnd { get; set; }
        public decimal? TaxReserveEnd { get; set; }
        public decimal? NetTaxEnd { get; set; }
        public decimal? FinancialBookBasisEnd { get; set; }
        public decimal? FinancialBookReserveEnd { get; set; }
        public decimal? GrossBookEnd { get; set; }
        public decimal? BookReserveEnd { get; set; }
        public decimal? NetBookEnd { get; set; }
        public decimal? CalcedTimingDiffEnd { get; set; }
        public decimal? ActualTimingDiffEnd { get; set; }
        public decimal? TaxDeprActivity { get; set; }
        public decimal? TaxGainLossActivity { get; set; }
        public decimal? BookDeprActivity { get; set; }
        public decimal? BookGainLossActivity { get; set; }
        public decimal? BasisDifferenceActivity { get; set; }
        public decimal? CurrentDiffDepreciation { get; set; }
        public decimal? CurrentDiffGainLoss { get; set; }
        public decimal? CurrentDitLossGain { get; set; }
    }
}
