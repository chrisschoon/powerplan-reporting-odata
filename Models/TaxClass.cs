﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PowerPlan.OData.Models
{
    public partial class TaxClass : IGenericODataModel
    {
        [Key]
        public long TaxClassId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public long? SummaryTaxClassId { get; set; }
        public long? TaxGroupId { get; set; }
        public long? TaxFcstSumId { get; set; }
        public long? TaxServiceId { get; set; }
        public int? OperInd { get; set; }
    }
}
