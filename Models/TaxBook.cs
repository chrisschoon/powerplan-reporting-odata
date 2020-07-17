using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxBook : IGenericODataModel
    {
        [Key]
        public long TaxBookId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public byte? BookDeprAllocInd { get; set; }
        public int? ReportIndicator { get; set; }
        public int? Fin48Indicator { get; set; }

        public virtual ICollection<MvTaxDepreciation> MvTaxDepreciations { get; set; }
    }
}
