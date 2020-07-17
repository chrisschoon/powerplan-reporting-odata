using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class CompanySetup : IGenericODataModel
    {
        [Key]
        public long CompanyId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string GlCompanyNo { get; set; }
        public long Owned { get; set; }
        public string Description { get; set; }
        public long StatusCodeId { get; set; }
        public string ShortDescription { get; set; }
        public long? CompanySummaryId { get; set; }
        public long? AutoLifeMonth { get; set; }
        public long? AutoCurveMonth { get; set; }
        public string AutoCloseWoNum { get; set; }
        public long? ParentCompanyId { get; set; }
        public string TaxReturnId { get; set; }
        public long? ClosingRollupId { get; set; }
        public string AutoLifeMonthMonthly { get; set; }
        public string CompanyType { get; set; }
        public string CompanyEin { get; set; }
        public string CwipAllocationMonths { get; set; }
        public long? PropTaxCompanyId { get; set; }
        public long? PowertaxCompanyId { get; set; }
        public byte? IsLeaseCompany { get; set; }
        public long? RegCompanyId { get; set; }
        public long? IsTaxRepairsCompany { get; set; }
    }
}
