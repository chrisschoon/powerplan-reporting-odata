using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxRecordControl : IGenericODataModel
    {
        [Key]
        public long TaxRecordId { get; set; }
        public long? CompanyId { get; set; }
        public long? TaxClassId { get; set; }
        public long VersionId { get; set; }
        public long VintageId { get; set; }
        public DateTime? InServiceMonth { get; set; }
        public DateTime? TimeStamp { get; set; }
        public long? TaxLocationId { get; set; }
        public string UserId { get; set; }
        public long? SubTaxClassId { get; set; }
        public long AssetId { get; set; }
        public long? K1ExportId { get; set; }
    }
}
