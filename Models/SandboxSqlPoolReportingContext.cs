using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PowerPlan.OData.Models
{
    public partial class SandboxSqlPoolReportingContext : DbContext
    {
        private readonly string _connection;

        public SandboxSqlPoolReportingContext()
        {
        }

        public SandboxSqlPoolReportingContext(DbContextOptions<SandboxSqlPoolReportingContext> options, IConfiguration configuration)
            : base(options)
        {
            _connection = configuration.GetConnectionString("SandboxSqlPoolReporting");
        }

        public virtual DbSet<AmortizationType> AmortizationType { get; set; }
        public virtual DbSet<BasisAmounts> BasisAmounts { get; set; }
        public virtual DbSet<BookAllocAssign> BookAllocAssign { get; set; }
        public virtual DbSet<BookAllocGroup> BookAllocGroup { get; set; }
        public virtual DbSet<CompanySetup> CompanySetup { get; set; }
        public virtual DbSet<DeferredIncomeTax> DeferredIncomeTax { get; set; }
        public virtual DbSet<DeferredIncomeTaxRates> DeferredIncomeTaxRates { get; set; }
        public virtual DbSet<DeferredIncomeTaxTransfer> DeferredIncomeTaxTransfer { get; set; }
        public virtual DbSet<DeferredRates> DeferredRates { get; set; }
        public virtual DbSet<DeferredTaxSchema> DeferredTaxSchema { get; set; }
        public virtual DbSet<Jurisdiction> Jurisdiction { get; set; }
        public virtual DbSet<MvDeferredIncomeTaxDetails> MvDeferredIncomeTaxDetails { get; set; }
        public virtual DbSet<MvTaxDepreciation> MvTaxDepreciation { get; set; }
        public virtual DbSet<NormType> NormType { get; set; }
        public virtual DbSet<NormalizationSchema> NormalizationSchema { get; set; }
        public virtual DbSet<PpCompanySecurity> PpCompanySecurity { get; set; }
        public virtual DbSet<PwrhouseCompany> PwrhouseCompany { get; set; }
        public virtual DbSet<PwrhouseTaxVersionType> PwrhouseTaxVersionType { get; set; }
        public virtual DbSet<PwrhouseTaxYear> PwrhouseTaxYear { get; set; }
        public virtual DbSet<RecoveryPeriod> RecoveryPeriod { get; set; }
        public virtual DbSet<Summary4562> Summary4562 { get; set; }
        public virtual DbSet<TaxActivityCode> TaxActivityCode { get; set; }
        public virtual DbSet<TaxBook> TaxBook { get; set; }
        public virtual DbSet<TaxBookReconcile> TaxBookReconcile { get; set; }
        public virtual DbSet<TaxBookReconcileTransfer> TaxBookReconcileTransfer { get; set; }
        public virtual DbSet<TaxBookSchema> TaxBookSchema { get; set; }
        public virtual DbSet<TaxClass> TaxClass { get; set; }
        public virtual DbSet<TaxConvention> TaxConvention { get; set; }
        public virtual DbSet<TaxCredit> TaxCredit { get; set; }
        public virtual DbSet<TaxDepreciation> TaxDepreciation { get; set; }
        public virtual DbSet<TaxDepreciationTransfer> TaxDepreciationTransfer { get; set; }
        public virtual DbSet<TaxInclude> TaxInclude { get; set; }
        public virtual DbSet<TaxIncludeActivity> TaxIncludeActivity { get; set; }
        public virtual DbSet<TaxLaw> TaxLaw { get; set; }
        public virtual DbSet<TaxLimit> TaxLimit { get; set; }
        public virtual DbSet<TaxLocation> TaxLocation { get; set; }
        public virtual DbSet<TaxRateControl> TaxRateControl { get; set; }
        public virtual DbSet<TaxReconcileItem> TaxReconcileItem { get; set; }
        public virtual DbSet<TaxRecordControl> TaxRecordControl { get; set; }
        public virtual DbSet<TaxTransferControl> TaxTransferControl { get; set; }
        public virtual DbSet<TaxTypeOfProperty> TaxTypeOfProperty { get; set; }
        public virtual DbSet<TaxVintageConvention> TaxVintageConvention { get; set; }
        public virtual DbSet<TaxYearVersion> TaxYearVersion { get; set; }
        public virtual DbSet<Version> Version { get; set; }
        public virtual DbSet<VersionType> VersionType { get; set; }
        public virtual DbSet<Vintage> Vintage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connection, builder =>
                {
                    builder.UseRowNumberForPaging(true);
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmortizationType>(entity =>
            {
                entity.ToTable("AMORTIZATION_TYPE", "staging");

                entity.HasIndex(e => new { e.AmortizationTypeId, e.TimeStamp, e.UserId, e.Description })
                    .HasName("ClusteredIndex_1b995e9e5d924748b74cafe404c5e97a");

                entity.Property(e => e.AmortizationTypeId).HasColumnName("AMORTIZATION_TYPE_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<BasisAmounts>(entity =>
            {
                entity.HasKey(p => new { p.TaxIncludeId, p.TaxRecordId, p.TaxYear, p.TaxActivityCodeId });

                entity.ToTable("BASIS_AMOUNTS", "staging");

                entity.HasIndex(e => new { e.TaxIncludeId, e.TaxRecordId, e.TaxYear, e.TaxActivityCodeId, e.TimeStamp, e.UserId, e.Amount, e.TaxSummaryId })
                    .HasName("ClusteredIndex_a9f6b9305e884d2ea53aaf443e17f7ad");

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxActivityCodeId).HasColumnName("TAX_ACTIVITY_CODE_ID");

                entity.Property(e => e.TaxIncludeId).HasColumnName("TAX_INCLUDE_ID");

                entity.Property(e => e.TaxRecordId).HasColumnName("TAX_RECORD_ID");

                entity.Property(e => e.TaxSummaryId).HasColumnName("TAX_SUMMARY_ID");

                entity.Property(e => e.TaxYear)
                    .HasColumnName("TAX_YEAR")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<BookAllocAssign>(entity =>
            {
                entity.ToTable("BOOK_ALLOC_ASSIGN", "staging");

                entity.HasIndex(e => new { e.BookAllocAssignId, e.TimeStamp, e.UserId, e.TaxClassId, e.CompanyId, e.BookAllocGroupId })
                    .HasName("ClusteredIndex_225dacd82cd542b194593fcf2f2c65f8");

                entity.Property(e => e.BookAllocAssignId).HasColumnName("BOOK_ALLOC_ASSIGN_ID");

                entity.Property(e => e.BookAllocGroupId).HasColumnName("BOOK_ALLOC_GROUP_ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.TaxClassId).HasColumnName("TAX_CLASS_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<BookAllocGroup>(entity =>
            {
                entity.ToTable("BOOK_ALLOC_GROUP", "staging");

                entity.HasIndex(e => new { e.BookAllocGroupId, e.TimeStamp, e.UserId, e.Description, e.CompanyId, e.MortalityCurveId, e.Life, e.AllocatedAmount, e.HwTableLineId, e.HwRegionId, e.SubledgerTypeId })
                    .HasName("ClusteredIndex_fbd1a0feb64d49578eb8c3b2fa13a7e4");

                entity.Property(e => e.AllocatedAmount)
                    .HasColumnName("ALLOCATED_AMOUNT")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BookAllocGroupId).HasColumnName("BOOK_ALLOC_GROUP_ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.HwRegionId).HasColumnName("HW_REGION_ID");

                entity.Property(e => e.HwTableLineId).HasColumnName("HW_TABLE_LINE_ID");

                entity.Property(e => e.Life).HasColumnName("LIFE");

                entity.Property(e => e.MortalityCurveId).HasColumnName("MORTALITY_CURVE_ID");

                entity.Property(e => e.SubledgerTypeId).HasColumnName("SUBLEDGER_TYPE_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<CompanySetup>(entity =>
            {
                entity.ToTable("COMPANY_SETUP", "staging");

                entity.HasIndex(e => new { e.CompanyId, e.TimeStamp, e.UserId, e.GlCompanyNo, e.Owned, e.Description, e.StatusCodeId, e.ShortDescription, e.CompanySummaryId, e.AutoLifeMonth, e.AutoCurveMonth, e.AutoCloseWoNum, e.ParentCompanyId, e.TaxReturnId, e.ClosingRollupId, e.AutoLifeMonthMonthly, e.CompanyType, e.CompanyEin, e.CwipAllocationMonths, e.PropTaxCompanyId, e.PowertaxCompanyId, e.IsLeaseCompany, e.RegCompanyId, e.IsTaxRepairsCompany })
                    .HasName("ClusteredIndex_7d231739b08a4dc09cd3a2c5cdbbbc3a");

                entity.Property(e => e.AutoCloseWoNum)
                    .HasColumnName("AUTO_CLOSE_WO_NUM")
                    .HasMaxLength(35);

                entity.Property(e => e.AutoCurveMonth).HasColumnName("AUTO_CURVE_MONTH");

                entity.Property(e => e.AutoLifeMonth).HasColumnName("AUTO_LIFE_MONTH");

                entity.Property(e => e.AutoLifeMonthMonthly)
                    .HasColumnName("AUTO_LIFE_MONTH_MONTHLY")
                    .HasMaxLength(35);

                entity.Property(e => e.ClosingRollupId).HasColumnName("CLOSING_ROLLUP_ID");

                entity.Property(e => e.CompanyEin)
                    .HasColumnName("COMPANY_EIN")
                    .HasMaxLength(35);

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CompanySummaryId).HasColumnName("COMPANY_SUMMARY_ID");

                entity.Property(e => e.CompanyType)
                    .HasColumnName("COMPANY_TYPE")
                    .HasMaxLength(35);

                entity.Property(e => e.CwipAllocationMonths)
                    .HasColumnName("CWIP_ALLOCATION_MONTHS")
                    .HasMaxLength(35);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);

                entity.Property(e => e.GlCompanyNo)
                    .HasColumnName("GL_COMPANY_NO")
                    .HasMaxLength(35);

                entity.Property(e => e.IsLeaseCompany).HasColumnName("IS_LEASE_COMPANY");

                entity.Property(e => e.IsTaxRepairsCompany)
                    .HasColumnName("IS_TAX_REPAIRS_COMPANY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Owned).HasColumnName("OWNED");

                entity.Property(e => e.ParentCompanyId).HasColumnName("PARENT_COMPANY_ID");

                entity.Property(e => e.PowertaxCompanyId).HasColumnName("POWERTAX_COMPANY_ID");

                entity.Property(e => e.PropTaxCompanyId).HasColumnName("PROP_TAX_COMPANY_ID");

                entity.Property(e => e.RegCompanyId).HasColumnName("REG_COMPANY_ID");

                entity.Property(e => e.ShortDescription)
                    .HasColumnName("SHORT_DESCRIPTION")
                    .HasMaxLength(25);

                entity.Property(e => e.StatusCodeId).HasColumnName("STATUS_CODE_ID");

                entity.Property(e => e.TaxReturnId)
                    .HasColumnName("TAX_RETURN_ID")
                    .HasMaxLength(35);

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<DeferredIncomeTax>(entity =>
            {
                entity.HasKey(p => new { p.TaxRecordId, p.TaxYear, p.TaxMonth, p.NormalizationId });

                entity.ToTable("DEFERRED_INCOME_TAX", "staging");

                entity.HasIndex(e => new { e.TaxRecordId, e.TaxYear, e.TaxMonth, e.NormalizationId, e.TimeSliceId, e.TimeStamp, e.UserId, e.DefIncomeTaxBalanceBeg, e.DefIncomeTaxBalanceEnd, e.NormDiffBalanceBeg, e.NormDiffBalanceEnd, e.DefIncomeTaxProvision, e.DefIncomeTaxReversal, e.AramRate, e.AramRateEnd, e.Life, e.DefIncomeTaxRetire, e.DefIncomeTaxAdjust, e.DefIncomeTaxGainLoss, e.GainLossDefTaxBalance, e.GainLossDefTaxBalanceEnd, e.BasisDiffAddRet, e.InputAmortization, e.BasisDiffRetireReversal })
                    .HasName("ClusteredIndex_33d4de2e6a7f4147b2d6e772d8f367c3");

                entity.Property(e => e.AramRate)
                    .HasColumnName("ARAM_RATE")
                    .HasColumnType("decimal(22, 8)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AramRateEnd)
                    .HasColumnName("ARAM_RATE_END")
                    .HasColumnType("decimal(22, 8)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BasisDiffAddRet)
                    .HasColumnName("BASIS_DIFF_ADD_RET")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BasisDiffRetireReversal)
                    .HasColumnName("BASIS_DIFF_RETIRE_REVERSAL")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefIncomeTaxAdjust)
                    .HasColumnName("DEF_INCOME_TAX_ADJUST")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefIncomeTaxBalanceBeg)
                    .HasColumnName("DEF_INCOME_TAX_BALANCE_BEG")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefIncomeTaxBalanceEnd)
                    .HasColumnName("DEF_INCOME_TAX_BALANCE_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefIncomeTaxGainLoss)
                    .HasColumnName("DEF_INCOME_TAX_GAIN_LOSS")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefIncomeTaxProvision)
                    .HasColumnName("DEF_INCOME_TAX_PROVISION")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefIncomeTaxRetire)
                    .HasColumnName("DEF_INCOME_TAX_RETIRE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefIncomeTaxReversal)
                    .HasColumnName("DEF_INCOME_TAX_REVERSAL")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GainLossDefTaxBalance)
                    .HasColumnName("GAIN_LOSS_DEF_TAX_BALANCE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GainLossDefTaxBalanceEnd)
                    .HasColumnName("GAIN_LOSS_DEF_TAX_BALANCE_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InputAmortization)
                    .HasColumnName("INPUT_AMORTIZATION")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Life)
                    .HasColumnName("LIFE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NormDiffBalanceBeg)
                    .HasColumnName("NORM_DIFF_BALANCE_BEG")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NormDiffBalanceEnd)
                    .HasColumnName("NORM_DIFF_BALANCE_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NormalizationId).HasColumnName("NORMALIZATION_ID");

                entity.Property(e => e.TaxMonth)
                    .HasColumnName("TAX_MONTH")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxRecordId).HasColumnName("TAX_RECORD_ID");

                entity.Property(e => e.TaxYear)
                    .HasColumnName("TAX_YEAR")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TimeSliceId)
                    .HasColumnName("TIME_SLICE_ID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<DeferredIncomeTaxRates>(entity =>
            {
                entity.HasKey(p => new { p.DefIncomeTaxRateId, p.EffectiveDate });

                entity.ToTable("DEFERRED_INCOME_TAX_RATES", "staging");

                entity.HasIndex(e => new { e.DefIncomeTaxRateId, e.EffectiveDate, e.TimeStamp, e.UserId, e.MonthlyRate, e.AnnualRate, e.StatutoryRate, e.GrossupRate, e.AllocationFactor, e.BaseRate1, e.BaseRate2, e.BaseRate3, e.BaseRate4, e.BaseRate5, e.BaseRate6, e.BaseRate7, e.BaseRate8, e.BaseRate9, e.BaseRate10 })
                    .HasName("ClusteredIndex_bb1ee7173dea44468e9a4112cae31462");

                entity.Property(e => e.AllocationFactor)
                    .HasColumnName("ALLOCATION_FACTOR")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.AnnualRate)
                    .HasColumnName("ANNUAL_RATE")
                    .HasColumnType("decimal(22, 8)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BaseRate1)
                    .HasColumnName("BASE_RATE1")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.BaseRate10)
                    .HasColumnName("BASE_RATE10")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.BaseRate2)
                    .HasColumnName("BASE_RATE2")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.BaseRate3)
                    .HasColumnName("BASE_RATE3")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.BaseRate4)
                    .HasColumnName("BASE_RATE4")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.BaseRate5)
                    .HasColumnName("BASE_RATE5")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.BaseRate6)
                    .HasColumnName("BASE_RATE6")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.BaseRate7)
                    .HasColumnName("BASE_RATE7")
                    .HasColumnType("decimal(22, 8)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BaseRate8)
                    .HasColumnName("BASE_RATE8")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.BaseRate9)
                    .HasColumnName("BASE_RATE9")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.DefIncomeTaxRateId).HasColumnName("DEF_INCOME_TAX_RATE_ID");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnName("EFFECTIVE_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.GrossupRate)
                    .HasColumnName("GROSSUP_RATE")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.MonthlyRate)
                    .HasColumnName("MONTHLY_RATE")
                    .HasColumnType("decimal(22, 8)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StatutoryRate)
                    .HasColumnName("STATUTORY_RATE")
                    .HasColumnType("decimal(22, 8)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<DeferredIncomeTaxTransfer>(entity =>
            {
                entity.HasKey(p => new { p.TaxTransferId, p.TaxRecordId, p.TaxMonth, p.NormalizationId });

                entity.ToTable("DEFERRED_INCOME_TAX_TRANSFER", "staging");

                entity.HasIndex(e => new { e.TaxTransferId, e.TaxRecordId, e.TaxYear, e.TaxMonth, e.NormalizationId, e.TimeSliceId, e.TimeStamp, e.UserId, e.DefIncomeTaxBalanceBeg, e.NormDiffBalanceBeg, e.Life })
                    .HasName("ClusteredIndex_15f481bdbdb945739dc0ebb739ae54f4");

                entity.Property(e => e.DefIncomeTaxBalanceBeg)
                    .HasColumnName("DEF_INCOME_TAX_BALANCE_BEG")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Life)
                    .HasColumnName("LIFE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NormDiffBalanceBeg)
                    .HasColumnName("NORM_DIFF_BALANCE_BEG")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NormalizationId).HasColumnName("NORMALIZATION_ID");

                entity.Property(e => e.TaxMonth).HasColumnName("TAX_MONTH");

                entity.Property(e => e.TaxRecordId).HasColumnName("TAX_RECORD_ID");

                entity.Property(e => e.TaxTransferId).HasColumnName("TAX_TRANSFER_ID");

                entity.Property(e => e.TaxYear)
                    .HasColumnName("TAX_YEAR")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.TimeSliceId)
                    .HasColumnName("TIME_SLICE_ID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<DeferredRates>(entity =>
            {
                entity.ToTable("DEFERRED_RATES", "staging");

                entity.HasIndex(e => new { e.DefIncomeTaxRateId, e.TimeStamp, e.UserId, e.Description, e.LongDescription, e.NormalizationPctId, e.JurAlloId })
                    .HasName("ClusteredIndex_88ee20cd6b4340848b927478b153f5bf");

                entity.Property(e => e.DefIncomeTaxRateId).HasColumnName("DEF_INCOME_TAX_RATE_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.JurAlloId).HasColumnName("JUR_ALLO_ID");

                entity.Property(e => e.LongDescription)
                    .HasColumnName("LONG_DESCRIPTION")
                    .HasMaxLength(254);

                entity.Property(e => e.NormalizationPctId).HasColumnName("NORMALIZATION_PCT_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<DeferredTaxSchema>(entity =>
            {
                entity.ToTable("DEFERRED_TAX_SCHEMA", "staging");

                entity.HasIndex(e => new { e.DeferredTaxSchemaId, e.TimeStamp, e.UserId, e.Description })
                    .HasName("ClusteredIndex_1b9b7fd7f0a845b891a751b58a76abaa");

                entity.Property(e => e.DeferredTaxSchemaId).HasColumnName("DEFERRED_TAX_SCHEMA_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<Jurisdiction>(entity =>
            {
                entity.ToTable("JURISDICTION", "staging");

                entity.HasIndex(e => new { e.JurisdictionId, e.TimeStamp, e.UserId, e.Description, e.TaxBookId, e.BookBookId, e.IncludeRwip, e.CompanyId, e.BookDeprAllocInd, e.StatutoryTransfer })
                    .HasName("ClusteredIndex_c8f10a3e73d24585b3172174e76d2d0c");

                entity.Property(e => e.BookBookId).HasColumnName("BOOK_BOOK_ID");

                entity.Property(e => e.BookDeprAllocInd)
                    .HasColumnName("BOOK_DEPR_ALLOC_IND")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.IncludeRwip).HasColumnName("INCLUDE_RWIP");

                entity.Property(e => e.JurisdictionId).HasColumnName("JURISDICTION_ID");

                entity.Property(e => e.StatutoryTransfer).HasColumnName("STATUTORY_TRANSFER");

                entity.Property(e => e.TaxBookId)
                    .HasColumnName("TAX_BOOK_ID")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<MvDeferredIncomeTaxDetails>(entity =>
            {
                entity.HasKey(p => new { p.TaxRecordId, p.TaxYear, p.TaxMonth, p.NormalizationId });

                entity.ToTable("MV_DEFERRED_INCOME_TAX_DETAILS", "staging");

                entity.HasIndex(e => new { e.TaxRecordId, e.CompanyDescription, e.CompanyId, e.TaxClassDescription, e.TaxClassId, e.VintageDescription, e.VintageYear, e.VintageId, e.TaxLocationDescription, e.TaxLocationId, e.VersionId, e.VersionDescription, e.BookAllocGroupDescription, e.BookAllocGroupId, e.NormalizationSchemaDesc, e.JurisdictionDescription, e.FromBookDescription, e.FromReportIndicator, e.ToBookDescription, e.ToReportIndicator, e.DeferredTaxRateDescription, e.AmortizationTypeDescription, e.TaxReconcileItemDescription, e.NormTypeDescription, e.AllocateBookDepreciation, e.IncludeCapitalizedDepr, e.AllowOverReversal, e.BasisDiffRetirementReversal, e.NetBasisDifferenceActivity, e.JurisdictionTaxBookDesc, e.JurisdictionTaxBookId, e.NormalizationId, e.JurisdictionId, e.NormFromTax, e.NormToTax, e.DefaultGlBalanceAcct, e.DefaultGlExpenseAcct, e.DefIncomeTaxRateId, e.AmortizationTypeId, e.ReconcileItemId, e.BookDeprAllocInd, e.CostOfRemovalFt, e.GlAccountId, e.BasisDiffRetireReversal, e.CapDeprInd, e.NoZeroCheck, e.NormTypeId, e.MidFrom, e.MidTo, e.MidDefTax, e.MidDefTaxOther, e.MidNormId, e.BasisDiffActivitySplit, e.TaxYear, e.TaxMonth, e.TimeSliceId, e.BeginningDifference, e.CurrentDifference, e.EndingDifference, e.Apb11BegDefTaxBalance, e.Apb11CurrentDefTaxBalance, e.Apb11EndDefTaxBalance, e.Fas109BegDefTaxBalance, e.Fas109EndDefTaxBalance, e.RegulatoryAsset, e.RegulatoryLiability, e.RegulatoryAssetGrossup, e.RegulatoryLiabilityGrossup, e.DefIncomeTaxProvision, e.DefIncomeTaxReversal, e.AramRate, e.AramRateEnd, e.Life, e.DefIncomeTaxRetire, e.DefIncomeTaxAdjust, e.DefIncomeTaxGainLoss, e.GainLossDefTaxBalance, e.GainLossDefTaxBalanceEnd, e.BasisDiffAddRet, e.InputAmortization, e.DitBasisDiffRetireReversal, e.StatutoryRate, e.GrossupRate, e.ComplianceTaxBeg, e.ComplianceTaxReserveBeg, e.GrossTaxBeg, e.TaxReserveBeg, e.NetTaxBeg, e.FinancialBookBasisBeg, e.FinancialBookReserveBeg, e.GrossBookBeg, e.BookReserveBeg, e.NetBookBeg, e.CalcedTimingDiffBeg, e.ActualTimingDiffBeg, e.ComplianceTaxEnd, e.ComplianceTaxReserveEnd, e.GrossTaxEnd, e.TaxReserveEnd, e.NetTaxEnd, e.FinancialBookBasisEnd, e.FinancialBookReserveEnd, e.GrossBookEnd, e.BookReserveEnd, e.NetBookEnd, e.CalcedTimingDiffEnd, e.ActualTimingDiffEnd, e.TaxDeprActivity, e.TaxGainLossActivity, e.BookDeprActivity, e.BookGainLossActivity, e.BasisDifferenceActivity, e.CurrentDiffDepreciation, e.CurrentDiffGainLoss, e.CurrentDitLossGain })
                    .HasName("ClusteredIndex_5faeadb0de9c4530ba645b5a1f9179d4");

                entity.Property(e => e.ActualTimingDiffBeg)
                    .HasColumnName("actual_timing_diff_beg")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.ActualTimingDiffEnd)
                    .HasColumnName("actual_timing_diff_end")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.AllocateBookDepreciation)
                    .IsRequired()
                    .HasColumnName("allocate_book_depreciation")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.AllowOverReversal)
                    .IsRequired()
                    .HasColumnName("allow_over_reversal")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.AmortizationTypeDescription)
                    .HasColumnName("amortization_type_description")
                    .HasMaxLength(35);

                entity.Property(e => e.AmortizationTypeId).HasColumnName("amortization_type_id");

                entity.Property(e => e.Apb11BegDefTaxBalance)
                    .HasColumnName("apb11_beg_def_tax_balance")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.Apb11CurrentDefTaxBalance)
                    .HasColumnName("apb11_current_def_tax_balance")
                    .HasColumnType("decimal(23, 2)");

                entity.Property(e => e.Apb11EndDefTaxBalance)
                    .HasColumnName("apb11_end_def_tax_balance")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.AramRate)
                    .HasColumnName("aram_rate")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.AramRateEnd)
                    .HasColumnName("aram_rate_end")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.BasisDiffActivitySplit).HasColumnName("basis_diff_activity_split");

                entity.Property(e => e.BasisDiffAddRet)
                    .HasColumnName("basis_diff_add_ret")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.BasisDiffRetireReversal).HasColumnName("basis_diff_retire_reversal");

                entity.Property(e => e.BasisDiffRetirementReversal)
                    .IsRequired()
                    .HasColumnName("basis_diff_retirement_reversal")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.BasisDifferenceActivity)
                    .HasColumnName("basis_difference_activity")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BeginningDifference)
                    .HasColumnName("beginning_difference")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.BookAllocGroupDescription)
                    .HasColumnName("book_alloc_group_description")
                    .HasMaxLength(35);

                entity.Property(e => e.BookAllocGroupId).HasColumnName("book_alloc_group_id");

                entity.Property(e => e.BookDeprActivity)
                    .HasColumnName("book_depr_activity")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BookDeprAllocInd).HasColumnName("book_depr_alloc_ind");

                entity.Property(e => e.BookGainLossActivity)
                    .HasColumnName("book_gain_loss_activity")
                    .HasColumnType("decimal(23, 2)");

                entity.Property(e => e.BookReserveBeg)
                    .HasColumnName("book_reserve_beg")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BookReserveEnd)
                    .HasColumnName("book_reserve_end")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.CalcedTimingDiffBeg)
                    .HasColumnName("calced_timing_diff_beg")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.CalcedTimingDiffEnd)
                    .HasColumnName("calced_timing_diff_end")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.CapDeprInd).HasColumnName("cap_depr_ind");

                entity.Property(e => e.CompanyDescription)
                    .IsRequired()
                    .HasColumnName("company_description")
                    .HasMaxLength(100);

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.ComplianceTaxBeg)
                    .HasColumnName("compliance_tax_beg")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ComplianceTaxEnd)
                    .HasColumnName("compliance_tax_end")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ComplianceTaxReserveBeg)
                    .HasColumnName("compliance_tax_reserve_beg")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ComplianceTaxReserveEnd)
                    .HasColumnName("compliance_tax_reserve_end")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.CostOfRemovalFt)
                    .HasColumnName("cost_of_removal_ft")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.CurrentDiffDepreciation)
                    .HasColumnName("current_diff_depreciation")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.CurrentDiffGainLoss)
                    .HasColumnName("current_diff_gain_loss")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.CurrentDifference)
                    .HasColumnName("current_difference")
                    .HasColumnType("decimal(23, 2)");

                entity.Property(e => e.CurrentDitLossGain)
                    .HasColumnName("current_dit_loss_gain")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.DefIncomeTaxAdjust)
                    .HasColumnName("def_income_tax_adjust")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.DefIncomeTaxGainLoss)
                    .HasColumnName("def_income_tax_gain_loss")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.DefIncomeTaxProvision)
                    .HasColumnName("def_income_tax_provision")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.DefIncomeTaxRateId).HasColumnName("def_income_tax_rate_id");

                entity.Property(e => e.DefIncomeTaxRetire)
                    .HasColumnName("def_income_tax_retire")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.DefIncomeTaxReversal)
                    .HasColumnName("def_income_tax_reversal")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.DefaultGlBalanceAcct).HasColumnName("default_gl_balance_acct");

                entity.Property(e => e.DefaultGlExpenseAcct).HasColumnName("default_gl_expense_acct");

                entity.Property(e => e.DeferredTaxRateDescription)
                    .HasColumnName("deferred_tax_rate_description")
                    .HasMaxLength(35);

                entity.Property(e => e.DitBasisDiffRetireReversal)
                    .HasColumnName("dit_basis_diff_retire_reversal")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.EndingDifference)
                    .HasColumnName("ending_difference")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.Fas109BegDefTaxBalance)
                    .HasColumnName("fas109_beg_def_tax_balance")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Fas109EndDefTaxBalance)
                    .HasColumnName("fas109_end_def_tax_balance")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.FinancialBookBasisBeg)
                    .HasColumnName("financial_book_basis_beg")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.FinancialBookBasisEnd)
                    .HasColumnName("financial_book_basis_end")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.FinancialBookReserveBeg)
                    .HasColumnName("financial_book_reserve_beg")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.FinancialBookReserveEnd)
                    .HasColumnName("financial_book_reserve_end")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.FromBookDescription)
                    .HasColumnName("from_book_description")
                    .HasMaxLength(35);

                entity.Property(e => e.FromReportIndicator).HasColumnName("from_report_indicator");

                entity.Property(e => e.GainLossDefTaxBalance)
                    .HasColumnName("gain_loss_def_tax_balance")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.GainLossDefTaxBalanceEnd)
                    .HasColumnName("gain_loss_def_tax_balance_end")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.GlAccountId).HasColumnName("gl_account_id");

                entity.Property(e => e.GrossBookBeg)
                    .HasColumnName("gross_book_beg")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.GrossBookEnd)
                    .HasColumnName("gross_book_end")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.GrossTaxBeg)
                    .HasColumnName("gross_tax_beg")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.GrossTaxEnd)
                    .HasColumnName("gross_tax_end")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.GrossupRate)
                    .HasColumnName("grossup_rate")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.IncludeCapitalizedDepr)
                    .IsRequired()
                    .HasColumnName("include_capitalized_depr")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.InputAmortization)
                    .HasColumnName("input_amortization")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.JurisdictionDescription)
                    .IsRequired()
                    .HasColumnName("jurisdiction_description")
                    .HasMaxLength(35);

                entity.Property(e => e.JurisdictionId).HasColumnName("jurisdiction_id");

                entity.Property(e => e.JurisdictionTaxBookDesc)
                    .IsRequired()
                    .HasColumnName("jurisdiction_tax_book_desc")
                    .HasMaxLength(35);

                entity.Property(e => e.JurisdictionTaxBookId).HasColumnName("jurisdiction_tax_book_id");

                entity.Property(e => e.Life)
                    .HasColumnName("life")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.MidDefTax).HasColumnName("mid_def_tax");

                entity.Property(e => e.MidDefTaxOther).HasColumnName("mid_def_tax_other");

                entity.Property(e => e.MidFrom).HasColumnName("mid_from");

                entity.Property(e => e.MidNormId).HasColumnName("mid_norm_id");

                entity.Property(e => e.MidTo).HasColumnName("mid_to");

                entity.Property(e => e.NetBasisDifferenceActivity)
                    .IsRequired()
                    .HasColumnName("net_basis_difference_activity")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.NetBookBeg)
                    .HasColumnName("net_book_beg")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.NetBookEnd)
                    .HasColumnName("net_book_end")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.NetTaxBeg)
                    .HasColumnName("net_tax_beg")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.NetTaxEnd)
                    .HasColumnName("net_tax_end")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.NoZeroCheck).HasColumnName("no_zero_check");

                entity.Property(e => e.NormFromTax).HasColumnName("norm_from_tax");

                entity.Property(e => e.NormToTax).HasColumnName("norm_to_tax");

                entity.Property(e => e.NormTypeDescription)
                    .IsRequired()
                    .HasColumnName("norm_type_description")
                    .HasMaxLength(35);

                entity.Property(e => e.NormTypeId).HasColumnName("norm_type_id");

                entity.Property(e => e.NormalizationId).HasColumnName("normalization_id");

                entity.Property(e => e.NormalizationSchemaDesc)
                    .HasColumnName("normalization_schema_desc")
                    .HasMaxLength(35);

                entity.Property(e => e.ReconcileItemId).HasColumnName("reconcile_item_id");

                entity.Property(e => e.RegulatoryAsset)
                    .HasColumnName("regulatory_asset")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.RegulatoryAssetGrossup)
                    .HasColumnName("regulatory_asset_grossup")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.RegulatoryLiability)
                    .HasColumnName("regulatory_liability")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.RegulatoryLiabilityGrossup)
                    .HasColumnName("regulatory_liability_grossup")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.StatutoryRate)
                    .HasColumnName("statutory_rate")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.TaxClassDescription)
                    .HasColumnName("tax_class_description")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxClassId).HasColumnName("tax_class_id");

                entity.Property(e => e.TaxDeprActivity)
                    .HasColumnName("tax_depr_activity")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.TaxGainLossActivity)
                    .HasColumnName("tax_gain_loss_activity")
                    .HasColumnType("decimal(23, 2)");

                entity.Property(e => e.TaxLocationDescription)
                    .HasColumnName("tax_location_description")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxLocationId).HasColumnName("tax_location_id");

                entity.Property(e => e.TaxMonth).HasColumnName("tax_month");

                entity.Property(e => e.TaxReconcileItemDescription)
                    .HasColumnName("tax_reconcile_item_description")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxRecordId).HasColumnName("tax_record_id");

                entity.Property(e => e.TaxReserveBeg)
                    .HasColumnName("tax_reserve_beg")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.TaxReserveEnd)
                    .HasColumnName("tax_reserve_end")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.TaxYear)
                    .HasColumnName("tax_year")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TimeSliceId).HasColumnName("time_slice_id");

                entity.Property(e => e.ToBookDescription)
                    .HasColumnName("to_book_description")
                    .HasMaxLength(35);

                entity.Property(e => e.ToReportIndicator).HasColumnName("to_report_indicator");

                entity.Property(e => e.VersionDescription)
                    .IsRequired()
                    .HasColumnName("version_description")
                    .HasMaxLength(35);

                entity.Property(e => e.VersionId).HasColumnName("version_id");

                entity.Property(e => e.VintageDescription)
                    .IsRequired()
                    .HasColumnName("vintage_description")
                    .HasMaxLength(35);

                entity.Property(e => e.VintageId).HasColumnName("vintage_id");

                entity.Property(e => e.VintageYear).HasColumnName("vintage_year");
            });

            modelBuilder.Entity<MvTaxDepreciation>(entity =>
            {
                entity.HasKey(p => new { p.TaxBookId, p.TaxYear, p.TaxRecordId });

                entity.ToTable("MV_TAX_DEPRECIATION", "staging");

                entity.HasIndex(e => new { e.TaxRecordId, e.CompanyDescription, e.VersionDescription, e.TaxClassDescription, e.VintageYear, e.VintageDescription, e.BookAllocGroupDescription, e.TaxBookDescription, e.TaxConventionDescription, e.ExtConventionDescription, e.TaxRateDescription, e.TaxLawDescription, e.TaxLimitDescription, e.Summary4562Description, e.RecoveryPeriodDescription, e.TypeOfPropertyDescription, e.TaxCreditDescription, e.DefTaxSchemaDescription, e.TaxYear, e.TaxReconcileItemDescription, e.BookBalance, e.BookBalanceEnd, e.TaxBalance, e.TaxBalanceEnd, e.TaxAdditions, e.TaxRetirements, e.ExtraordinaryRetires, e.RetireReserveImpact, e.DepreciableBase, e.Depreciation, e.AccumReserve, e.AccumReserveEnd, e.GainLoss, e.ActualSalvage, e.ExtraordinarySalvage, e.CostOfRemoval, e.CorReserveImpact, e.AccumOrdinaryRetires, e.AccumOrdinRetiresEnd, e.AccumReserveAdjust, e.CorExpense, e.BasisAmountActivity, e.CapitalizedDepr, e.Activity, e.Adjustments, e.BookAdditions, e.BookAdjustments, e.BookTransfersIn, e.BookTransfersOut, e.BookRetirements, e.BookExtRetirements, e.BookTestRetirements, e.SalvageSalePrice, e.DepreciationAllowed, e.TaxRetirementsWithCor, e.GainLossLessCor, e.CapitalGainLoss, e.RetirementsFromBasis, e.AdditionsTransfer, e.BookBalanceTransfer, e.TaxBalanceTransfer, e.AccumReserveTransfer, e.SlReserveTransfer, e.FixedDeprBaseTransfer, e.EstimatedSalvageTransfer, e.AccumSalvageTransfer, e.AccumOrdRetiresTransfer, e.ReserveAtSwitchTransfer, e.QuantityTransfer, e.CalcDepreciationTransfer, e.TaxBookId, e.ConventionId, e.ExtConventionId, e.TaxRateId, e.TaxLawId, e.TaxLimitId, e.Summary4562Id, e.RecoveryPeriodId, e.TypeOfPropertyId, e.TaxCreditId, e.DeferredTaxSchemaId, e.VersionId, e.VintageId, e.TaxClassId, e.CompanyId, e.ReconcileItemId })
                    .HasName("ClusteredIndex_69e21a371b864c7c8989c6fac1f03033");

                entity.Property(e => e.AccumOrdRetiresTransfer)
                    .HasColumnName("accum_ord_retires_transfer")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.AccumOrdinRetiresEnd)
                    .HasColumnName("accum_ordin_retires_end")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.AccumOrdinaryRetires)
                    .HasColumnName("accum_ordinary_retires")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.AccumReserve)
                    .HasColumnName("accum_reserve")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.AccumReserveAdjust)
                    .HasColumnName("accum_reserve_adjust")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.AccumReserveEnd)
                    .HasColumnName("accum_reserve_end")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.AccumReserveTransfer)
                    .HasColumnName("accum_reserve_transfer")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.AccumSalvageTransfer)
                    .HasColumnName("accum_salvage_transfer")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.Activity)
                    .HasColumnName("activity")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ActualSalvage)
                    .HasColumnName("actual_salvage")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.AdditionsTransfer)
                    .HasColumnName("additions_transfer")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.Adjustments)
                    .HasColumnName("adjustments")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BasisAmountActivity)
                    .HasColumnName("basis_amount_activity")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BookAdditions)
                    .HasColumnName("book_additions")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BookAdjustments)
                    .HasColumnName("book_adjustments")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BookAllocGroupDescription)
                    .HasColumnName("book_alloc_group_description")
                    .HasMaxLength(35);

                entity.Property(e => e.BookBalance)
                    .HasColumnName("book_balance")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BookBalanceEnd)
                    .HasColumnName("book_balance_end")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BookBalanceTransfer)
                    .HasColumnName("book_balance_transfer")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BookExtRetirements)
                    .HasColumnName("book_ext_retirements")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BookRetirements)
                    .HasColumnName("book_retirements")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BookTestRetirements)
                    .HasColumnName("book_test_retirements")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BookTransfersIn)
                    .HasColumnName("book_transfers_in")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BookTransfersOut)
                    .HasColumnName("book_transfers_out")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.CalcDepreciationTransfer)
                    .HasColumnName("calc_depreciation_transfer")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.CapitalGainLoss)
                    .HasColumnName("capital_gain_loss")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.CapitalizedDepr)
                    .HasColumnName("capitalized_depr")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.CompanyDescription)
                    .IsRequired()
                    .HasColumnName("company_description")
                    .HasMaxLength(100);

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.ConventionId).HasColumnName("convention_id");

                entity.Property(e => e.CorExpense)
                    .HasColumnName("cor_expense")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.CorReserveImpact)
                    .HasColumnName("cor_reserve_impact")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.CostOfRemoval)
                    .HasColumnName("cost_of_removal")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.DefTaxSchemaDescription)
                    .HasColumnName("def_tax_schema_description")
                    .HasMaxLength(35);

                entity.Property(e => e.DeferredTaxSchemaId).HasColumnName("deferred_tax_schema_id");

                entity.Property(e => e.DepreciableBase)
                    .HasColumnName("depreciable_base")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.Depreciation)
                    .HasColumnName("depreciation")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.DepreciationAllowed)
                    .HasColumnName("depreciation_allowed")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.EstimatedSalvageTransfer)
                    .HasColumnName("estimated_salvage_transfer")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ExtConventionDescription)
                    .HasColumnName("ext_convention_description")
                    .HasMaxLength(35);

                entity.Property(e => e.ExtConventionId).HasColumnName("ext_convention_id");

                entity.Property(e => e.ExtraordinaryRetires)
                    .HasColumnName("extraordinary_retires")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.ExtraordinarySalvage)
                    .HasColumnName("extraordinary_salvage")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.FixedDeprBaseTransfer)
                    .HasColumnName("fixed_depr_base_transfer")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.GainLoss)
                    .HasColumnName("gain_loss")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.GainLossLessCor)
                    .HasColumnName("gain_loss_less_cor")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.QuantityTransfer).HasColumnName("quantity_transfer");

                entity.Property(e => e.ReconcileItemId).HasColumnName("reconcile_item_id");

                entity.Property(e => e.RecoveryPeriodDescription)
                    .HasColumnName("recovery_period_description")
                    .HasMaxLength(35);

                entity.Property(e => e.RecoveryPeriodId).HasColumnName("recovery_period_id");

                entity.Property(e => e.ReserveAtSwitchTransfer)
                    .HasColumnName("reserve_at_switch_transfer")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.RetireReserveImpact)
                    .HasColumnName("retire_reserve_impact")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.RetirementsFromBasis)
                    .HasColumnName("retirements_from_basis")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.SalvageSalePrice)
                    .HasColumnName("salvage_sale_price")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.SlReserveTransfer)
                    .HasColumnName("sl_reserve_transfer")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.Summary4562Description)
                    .HasColumnName("summary_4562_description")
                    .HasMaxLength(35);

                entity.Property(e => e.Summary4562Id).HasColumnName("summary_4562_id");

                entity.Property(e => e.TaxAdditions)
                    .HasColumnName("tax_additions")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.TaxBalance)
                    .HasColumnName("tax_balance")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.TaxBalanceEnd)
                    .HasColumnName("tax_balance_end")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.TaxBalanceTransfer)
                    .HasColumnName("tax_balance_transfer")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.TaxBookDescription)
                    .IsRequired()
                    .HasColumnName("tax_book_description")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxBookId).HasColumnName("tax_book_id");

                entity.Property(e => e.TaxClassDescription)
                    .HasColumnName("tax_class_description")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxClassId).HasColumnName("tax_class_id");

                entity.Property(e => e.TaxConventionDescription)
                    .HasColumnName("tax_convention_description")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxCreditDescription)
                    .HasColumnName("tax_credit_description")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxCreditId).HasColumnName("tax_credit_id");

                entity.Property(e => e.TaxLawDescription)
                    .HasColumnName("tax_law_description")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxLawId).HasColumnName("tax_law_id");

                entity.Property(e => e.TaxLimitDescription)
                    .HasColumnName("tax_limit_description")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxLimitId).HasColumnName("tax_limit_id");

                entity.Property(e => e.TaxRateDescription)
                    .HasColumnName("tax_rate_description")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxRateId).HasColumnName("tax_rate_id");

                entity.Property(e => e.TaxReconcileItemDescription)
                    .HasColumnName("tax_reconcile_item_description")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxRecordId).HasColumnName("tax_record_id");

                entity.Property(e => e.TaxRetirements)
                    .HasColumnName("tax_retirements")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.TaxRetirementsWithCor)
                    .HasColumnName("tax_retirements_with_cor")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.TaxYear)
                    .HasColumnName("tax_year")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TypeOfPropertyDescription)
                    .HasColumnName("type_of_property_description")
                    .HasMaxLength(35);

                entity.Property(e => e.TypeOfPropertyId).HasColumnName("type_of_property_id");

                entity.Property(e => e.VersionDescription)
                    .IsRequired()
                    .HasColumnName("version_description")
                    .HasMaxLength(35);

                entity.Property(e => e.VersionId).HasColumnName("version_id");

                entity.Property(e => e.VintageDescription)
                    .IsRequired()
                    .HasColumnName("vintage_description")
                    .HasMaxLength(35);

                entity.Property(e => e.VintageId).HasColumnName("vintage_id");

                entity.Property(e => e.VintageYear).HasColumnName("vintage_year");

                entity
                    .HasOne(mvtd => mvtd.TaxBook)
                    .WithMany(tb => tb.MvTaxDepreciations);
            });

            modelBuilder.Entity<NormType>(entity =>
            {
                entity.ToTable("NORM_TYPE", "staging");

                entity.HasIndex(e => new { e.NormTypeId, e.Description, e.TimeStamp, e.UserId })
                    .HasName("ClusteredIndex_6933732a6ac6472289e640ec42e866f7");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.NormTypeId).HasColumnName("NORM_TYPE_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<NormalizationSchema>(entity =>
            {
                entity.ToTable("NORMALIZATION_SCHEMA", "staging");

                entity.HasIndex(e => new { e.NormalizationId, e.TimeStamp, e.UserId, e.Description, e.JurisdictionId, e.NormFromTax, e.NormToTax, e.DefaultGlBalanceAcct, e.DefaultGlExpenseAcct, e.DefIncomeTaxRateId, e.AmortizationTypeId, e.ReconcileItemId, e.BookDeprAllocInd, e.CostOfRemovalFt, e.GlAccountId, e.BasisDiffRetireReversal, e.CapDeprInd, e.NoZeroCheck, e.NormTypeId, e.MidFrom, e.MidTo, e.MidDefTax, e.MidDefTaxOther, e.MidNormId, e.BasisDiffActivitySplit })
                    .HasName("ClusteredIndex_fd96f845b666463081f7abc9c131b639");

                entity.Property(e => e.AmortizationTypeId).HasColumnName("AMORTIZATION_TYPE_ID");

                entity.Property(e => e.BasisDiffActivitySplit)
                    .HasColumnName("BASIS_DIFF_ACTIVITY_SPLIT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BasisDiffRetireReversal)
                    .HasColumnName("BASIS_DIFF_RETIRE_REVERSAL")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BookDeprAllocInd)
                    .HasColumnName("BOOK_DEPR_ALLOC_IND")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CapDeprInd)
                    .HasColumnName("CAP_DEPR_IND")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CostOfRemovalFt)
                    .HasColumnName("COST_OF_REMOVAL_FT")
                    .HasColumnType("decimal(22, 8)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefIncomeTaxRateId).HasColumnName("DEF_INCOME_TAX_RATE_ID");

                entity.Property(e => e.DefaultGlBalanceAcct).HasColumnName("DEFAULT_GL_BALANCE_ACCT");

                entity.Property(e => e.DefaultGlExpenseAcct).HasColumnName("DEFAULT_GL_EXPENSE_ACCT");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.GlAccountId).HasColumnName("GL_ACCOUNT_ID");

                entity.Property(e => e.JurisdictionId).HasColumnName("JURISDICTION_ID");

                entity.Property(e => e.MidDefTax).HasColumnName("MID_DEF_TAX");

                entity.Property(e => e.MidDefTaxOther).HasColumnName("MID_DEF_TAX_OTHER");

                entity.Property(e => e.MidFrom).HasColumnName("MID_FROM");

                entity.Property(e => e.MidNormId).HasColumnName("MID_NORM_ID");

                entity.Property(e => e.MidTo).HasColumnName("MID_TO");

                entity.Property(e => e.NoZeroCheck)
                    .HasColumnName("NO_ZERO_CHECK")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NormFromTax).HasColumnName("NORM_FROM_TAX");

                entity.Property(e => e.NormToTax).HasColumnName("NORM_TO_TAX");

                entity.Property(e => e.NormTypeId).HasColumnName("NORM_TYPE_ID");

                entity.Property(e => e.NormalizationId).HasColumnName("NORMALIZATION_ID");

                entity.Property(e => e.ReconcileItemId).HasColumnName("RECONCILE_ITEM_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<PpCompanySecurity>(entity =>
            {
                entity.HasKey(p => new { p.Users, p.CompanyId });

                entity.ToTable("PP_COMPANY_SECURITY", "staging");

                entity.HasIndex(e => new { e.Users, e.CompanyId, e.TimeStamp, e.UserId })
                    .HasName("ClusteredIndex_c00a32813f654411bc2fcc29e7e5a5ee");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);

                entity.Property(e => e.Users)
                    .IsRequired()
                    .HasColumnName("USERS")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<PwrhouseCompany>(entity =>
            {
                entity.ToTable("PWRHOUSE_COMPANY", "staging");

                entity.HasIndex(e => new { e.CompanyId, e.TimeStamp, e.UserId })
                    .HasName("ClusteredIndex_ebc3e9ddd3924461833d70effd322924");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<PwrhouseTaxVersionType>(entity =>
            {
                entity.ToTable("PWRHOUSE_TAX_VERSION_TYPE", "staging");

                entity.HasIndex(e => new { e.VersionTypeId, e.TimeStamp, e.UserId })
                    .HasName("ClusteredIndex_6be72830291d48179d1e7297e580fc2e");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);

                entity.Property(e => e.VersionTypeId)
                    .HasColumnName("VERSION_TYPE_ID")
                    .HasColumnType("decimal(22, 2)");
            });

            modelBuilder.Entity<PwrhouseTaxYear>(entity =>
            {
                entity.ToTable("PWRHOUSE_TAX_YEAR", "staging");

                entity.HasIndex(e => new { e.TaxYear, e.TimeStamp, e.UserId })
                    .HasName("ClusteredIndex_d58fe9c9b36a48f48d49da60abf7324e");

                entity.Property(e => e.TaxYear)
                    .HasColumnName("TAX_YEAR")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<RecoveryPeriod>(entity =>
            {
                entity.ToTable("RECOVERY_PERIOD", "staging");

                entity.HasIndex(e => new { e.RecoveryPeriodId, e.TimeStamp, e.UserId, e.Period, e.Description })
                    .HasName("ClusteredIndex_b6328157d7cd4940ae9ca6c040803860");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.Period).HasColumnName("PERIOD");

                entity.Property(e => e.RecoveryPeriodId).HasColumnName("RECOVERY_PERIOD_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<Summary4562>(entity =>
            {
                entity.ToTable("SUMMARY_4562", "staging");

                entity.HasIndex(e => new { e.Summary4562Id, e.TimeStamp, e.UserId, e.Description })
                    .HasName("ClusteredIndex_c12a09f49be2468daf05e779a87bca4c");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.Summary4562Id).HasColumnName("SUMMARY_4562_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxActivityCode>(entity =>
            {
                entity.ToTable("TAX_ACTIVITY_CODE", "staging");

                entity.HasIndex(e => new { e.TaxActivityCodeId, e.TimeStamp, e.UserId, e.Description, e.Sign, e.TaxActivityTypeId })
                    .HasName("ClusteredIndex_c59cd71586984d82a8b213512ada50fd");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.Sign)
                    .HasColumnName("SIGN")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TaxActivityCodeId).HasColumnName("TAX_ACTIVITY_CODE_ID");

                entity.Property(e => e.TaxActivityTypeId).HasColumnName("TAX_ACTIVITY_TYPE_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxBook>(entity =>
            {
                entity.ToTable("TAX_BOOK", "staging");

                entity.HasIndex(e => new { e.TaxBookId, e.TimeStamp, e.UserId, e.Description, e.BookDeprAllocInd, e.ReportIndicator, e.Fin48Indicator })
                    .HasName("ClusteredIndex_a0bb57ac70ca4b11ad664d769e6d90a1");

                entity.Property(e => e.BookDeprAllocInd)
                    .HasColumnName("BOOK_DEPR_ALLOC_IND")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.Fin48Indicator).HasColumnName("FIN48_INDICATOR");

                entity.Property(e => e.ReportIndicator)
                    .HasColumnName("REPORT_INDICATOR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxBookId).HasColumnName("TAX_BOOK_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxBookReconcile>(entity =>
            {
                entity.HasKey(p => new { p.TaxIncludeId, p.TaxYear, p.TaxRecordId, p.ReconcileItemId });

                entity.ToTable("TAX_BOOK_RECONCILE", "staging");

                entity.HasIndex(e => new { e.TaxIncludeId, e.TaxYear, e.TaxRecordId, e.ReconcileItemId, e.TimeStamp, e.UserId, e.BasisAmountBeg, e.BasisAmountEnd, e.BasisAmountActivity, e.BasisAmountInputRetire, e.BasisAmountTransfer })
                    .HasName("ClusteredIndex_6be7304856e4464f97e2da8d309cea4e");

                entity.Property(e => e.BasisAmountActivity)
                    .HasColumnName("BASIS_AMOUNT_ACTIVITY")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BasisAmountBeg)
                    .HasColumnName("BASIS_AMOUNT_BEG")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BasisAmountEnd)
                    .HasColumnName("BASIS_AMOUNT_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BasisAmountInputRetire)
                    .HasColumnName("BASIS_AMOUNT_INPUT_RETIRE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BasisAmountTransfer)
                    .HasColumnName("BASIS_AMOUNT_TRANSFER")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReconcileItemId).HasColumnName("RECONCILE_ITEM_ID");

                entity.Property(e => e.TaxIncludeId).HasColumnName("TAX_INCLUDE_ID");

                entity.Property(e => e.TaxRecordId).HasColumnName("TAX_RECORD_ID");

                entity.Property(e => e.TaxYear)
                    .HasColumnName("TAX_YEAR")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxBookReconcileTransfer>(entity =>
            {
                entity.HasKey(p => new { p.TaxTransferId, p.TaxIncludeId, p.TaxRecordId, p.ReconcileItemId });

                entity.ToTable("TAX_BOOK_RECONCILE_TRANSFER", "staging");

                entity.HasIndex(e => new { e.TaxTransferId, e.TaxIncludeId, e.TaxYear, e.TaxRecordId, e.ReconcileItemId, e.TimeStamp, e.UserId, e.BasisAmountBeg, e.Additions })
                    .HasName("ClusteredIndex_c5def77b05024eaf92a096c1247393ab");

                entity.Property(e => e.Additions)
                    .HasColumnName("ADDITIONS")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.BasisAmountBeg)
                    .HasColumnName("BASIS_AMOUNT_BEG")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReconcileItemId).HasColumnName("RECONCILE_ITEM_ID");

                entity.Property(e => e.TaxIncludeId).HasColumnName("TAX_INCLUDE_ID");

                entity.Property(e => e.TaxRecordId).HasColumnName("TAX_RECORD_ID");

                entity.Property(e => e.TaxTransferId).HasColumnName("TAX_TRANSFER_ID");

                entity.Property(e => e.TaxYear)
                    .HasColumnName("TAX_YEAR")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxBookSchema>(entity =>
            {
                entity.HasKey(p => new { p.X, p.TaxBookId });

                entity.ToTable("TAX_BOOK_SCHEMA", "staging");

                entity.HasIndex(e => new { e.X, e.TaxBookId, e.TimeStamp, e.UserId })
                    .HasName("ClusteredIndex_5f260021d29646d18fbb63acb5dda3d1");

                entity.Property(e => e.TaxBookId).HasColumnName("TAX_BOOK_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxClass>(entity =>
            {
                entity.ToTable("TAX_CLASS", "staging");

                entity.HasIndex(e => new { e.TaxClassId, e.TimeStamp, e.UserId, e.Description, e.SummaryTaxClassId, e.TaxGroupId, e.TaxFcstSumId, e.TaxServiceId, e.OperInd })
                    .HasName("ClusteredIndex_5c373c19fe70490185db600a5dcf46a9");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.OperInd).HasColumnName("OPER_IND");

                entity.Property(e => e.SummaryTaxClassId).HasColumnName("SUMMARY_TAX_CLASS_ID");

                entity.Property(e => e.TaxClassId).HasColumnName("TAX_CLASS_ID");

                entity.Property(e => e.TaxFcstSumId).HasColumnName("TAX_FCST_SUM_ID");

                entity.Property(e => e.TaxGroupId).HasColumnName("TAX_GROUP_ID");

                entity.Property(e => e.TaxServiceId).HasColumnName("TAX_SERVICE_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxConvention>(entity =>
            {
                entity.ToTable("TAX_CONVENTION", "staging");

                entity.HasIndex(e => new { e.ConventionId, e.TimeStamp, e.UserId, e.Description, e.RetireDeprId, e.RetireBalId, e.RetireReserveId, e.GainLossId, e.SalvageId, e.EstSalvageId, e.CapGainId, e.CostOfRemovalId, e.TaxConventionLock })
                    .HasName("ClusteredIndex_215fdf65dc9f40e39955d2638f9f50b5");

                entity.Property(e => e.CapGainId).HasColumnName("CAP_GAIN_ID");

                entity.Property(e => e.ConventionId).HasColumnName("CONVENTION_ID");

                entity.Property(e => e.CostOfRemovalId).HasColumnName("COST_OF_REMOVAL_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.EstSalvageId).HasColumnName("EST_SALVAGE_ID");

                entity.Property(e => e.GainLossId).HasColumnName("GAIN_LOSS_ID");

                entity.Property(e => e.RetireBalId).HasColumnName("RETIRE_BAL_ID");

                entity.Property(e => e.RetireDeprId).HasColumnName("RETIRE_DEPR_ID");

                entity.Property(e => e.RetireReserveId).HasColumnName("RETIRE_RESERVE_ID");

                entity.Property(e => e.SalvageId).HasColumnName("SALVAGE_ID");

                entity.Property(e => e.TaxConventionLock)
                    .HasColumnName("TAX_CONVENTION_LOCK")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxCredit>(entity =>
            {
                entity.ToTable("TAX_CREDIT", "staging");

                entity.HasIndex(e => new { e.TaxCreditId, e.TimeStamp, e.UserId, e.Description, e.ExtTaxCredit })
                    .HasName("ClusteredIndex_b8cb623c482c4f84b42e337cc8426d89");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.ExtTaxCredit)
                    .HasColumnName("EXT_TAX_CREDIT")
                    .HasMaxLength(50);

                entity.Property(e => e.TaxCreditId).HasColumnName("TAX_CREDIT_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxDepreciation>(entity =>
            {
                entity.HasKey(p => new { p.TaxBookId, p.TaxYear, p.TaxRecordId });

                entity.ToTable("TAX_DEPRECIATION", "staging");

                entity.HasIndex(e => new { e.TaxBookId, e.TaxYear, e.TaxRecordId, e.TimeStamp, e.UserId, e.TypeOfPropertyId, e.TaxLawId, e.ConventionId, e.ExtraordinaryConvention, e.TaxRateId, e.RemainingLifeIndicator, e.TaxLimitId, e.Summary4562Id, e.ListedPropertyInd, e.RecoveryPeriodId, e.TaxCreditId, e.DeferredTaxSchemaId, e.BookBalance, e.TaxBalance, e.RemainingLife, e.AccumReserve, e.SlReserve, e.DepreciableBase, e.FixedDepreciableBase, e.ActualSalvage, e.EstimatedSalvage, e.AccumSalvage, e.Additions, e.Transfers, e.Adjustments, e.Retirements, e.ExtraordinaryRetires, e.AccumOrdinaryRetires, e.Depreciation, e.CostOfRemoval, e.CorExpense, e.GainLoss, e.CapitalGainLoss, e.EstSalvagePct, e.BookBalanceEnd, e.TaxBalanceEnd, e.AccumReserveEnd, e.AccumSalvageEnd, e.AccumOrdinRetiresEnd, e.SlReserveEnd, e.RetireInvolConv, e.SalvageInvolConv, e.SalvageExtraord, e.CalcDepreciation, e.OverAdjDepreciation, e.RetireResImpact, e.TransferResImpact, e.SalvageResImpact, e.CorResImpact, e.AdjustedRetireBasis, e.ReserveAtSwitch, e.Quantity, e.CapitalizedDepr, e.ReserveAtSwitchEnd, e.NumberMonthsBeg, e.NumberMonthsEnd, e.ExRetireResImpact, e.ExGainLoss, e.QuantityEnd, e.EstimatedSalvageEnd, e.JobCreationAmount, e.BookBalanceAdjust, e.AccumReserveAdjust, e.DepreciableBaseAdjust, e.DepreciationAdjust, e.GainLossAdjust, e.CapGainLossAdjust, e.BookBalanceAdjustMethod, e.AccumReserveAdjustMethod, e.DepreciableBaseAdjustMethod, e.DepreciationAdjustMethod, e.TaxLayerId, e.TransferDepr })
                    .HasName("ClusteredIndex_baced409e4bc405f91c408a042617c36");

                entity.Property(e => e.AccumOrdinRetiresEnd)
                    .HasColumnName("ACCUM_ORDIN_RETIRES_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccumOrdinaryRetires)
                    .HasColumnName("ACCUM_ORDINARY_RETIRES")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccumReserve)
                    .HasColumnName("ACCUM_RESERVE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccumReserveAdjust)
                    .HasColumnName("ACCUM_RESERVE_ADJUST")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccumReserveAdjustMethod)
                    .HasColumnName("ACCUM_RESERVE_ADJUST_METHOD")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AccumReserveEnd)
                    .HasColumnName("ACCUM_RESERVE_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccumSalvage)
                    .HasColumnName("ACCUM_SALVAGE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccumSalvageEnd)
                    .HasColumnName("ACCUM_SALVAGE_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualSalvage)
                    .HasColumnName("ACTUAL_SALVAGE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Additions)
                    .HasColumnName("ADDITIONS")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AdjustedRetireBasis)
                    .HasColumnName("ADJUSTED_RETIRE_BASIS")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Adjustments)
                    .HasColumnName("ADJUSTMENTS")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BookBalance)
                    .HasColumnName("BOOK_BALANCE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BookBalanceAdjust)
                    .HasColumnName("BOOK_BALANCE_ADJUST")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BookBalanceAdjustMethod)
                    .HasColumnName("BOOK_BALANCE_ADJUST_METHOD")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BookBalanceEnd)
                    .HasColumnName("BOOK_BALANCE_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CalcDepreciation)
                    .HasColumnName("CALC_DEPRECIATION")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CapGainLossAdjust)
                    .HasColumnName("CAP_GAIN_LOSS_ADJUST")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CapitalGainLoss)
                    .HasColumnName("CAPITAL_GAIN_LOSS")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CapitalizedDepr)
                    .HasColumnName("CAPITALIZED_DEPR")
                    .HasColumnType("decimal(22, 8)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConventionId).HasColumnName("CONVENTION_ID");

                entity.Property(e => e.CorExpense)
                    .HasColumnName("COR_EXPENSE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CorResImpact)
                    .HasColumnName("COR_RES_IMPACT")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CostOfRemoval)
                    .HasColumnName("COST_OF_REMOVAL")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DeferredTaxSchemaId)
                    .HasColumnName("DEFERRED_TAX_SCHEMA_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepreciableBase)
                    .HasColumnName("DEPRECIABLE_BASE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepreciableBaseAdjust)
                    .HasColumnName("DEPRECIABLE_BASE_ADJUST")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepreciableBaseAdjustMethod)
                    .HasColumnName("DEPRECIABLE_BASE_ADJUST_METHOD")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Depreciation)
                    .HasColumnName("DEPRECIATION")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepreciationAdjust)
                    .HasColumnName("DEPRECIATION_ADJUST")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepreciationAdjustMethod)
                    .HasColumnName("DEPRECIATION_ADJUST_METHOD")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EstSalvagePct)
                    .HasColumnName("EST_SALVAGE_PCT")
                    .HasColumnType("decimal(22, 8)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedSalvage)
                    .HasColumnName("ESTIMATED_SALVAGE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedSalvageEnd)
                    .HasColumnName("ESTIMATED_SALVAGE_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExGainLoss)
                    .HasColumnName("EX_GAIN_LOSS")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExRetireResImpact)
                    .HasColumnName("EX_RETIRE_RES_IMPACT")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExtraordinaryConvention).HasColumnName("EXTRAORDINARY_CONVENTION");

                entity.Property(e => e.ExtraordinaryRetires)
                    .HasColumnName("EXTRAORDINARY_RETIRES")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FixedDepreciableBase)
                    .HasColumnName("FIXED_DEPRECIABLE_BASE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GainLoss)
                    .HasColumnName("GAIN_LOSS")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GainLossAdjust)
                    .HasColumnName("GAIN_LOSS_ADJUST")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.JobCreationAmount)
                    .HasColumnName("JOB_CREATION_AMOUNT")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ListedPropertyInd).HasColumnName("LISTED_PROPERTY_IND");

                entity.Property(e => e.NumberMonthsBeg)
                    .HasColumnName("NUMBER_MONTHS_BEG")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NumberMonthsEnd)
                    .HasColumnName("NUMBER_MONTHS_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OverAdjDepreciation)
                    .HasColumnName("OVER_ADJ_DEPRECIATION")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QuantityEnd)
                    .HasColumnName("QUANTITY_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RecoveryPeriodId).HasColumnName("RECOVERY_PERIOD_ID");

                entity.Property(e => e.RemainingLife)
                    .HasColumnName("REMAINING_LIFE")
                    .HasColumnType("decimal(22, 8)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RemainingLifeIndicator).HasColumnName("REMAINING_LIFE_INDICATOR");

                entity.Property(e => e.ReserveAtSwitch)
                    .HasColumnName("RESERVE_AT_SWITCH")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReserveAtSwitchEnd)
                    .HasColumnName("RESERVE_AT_SWITCH_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RetireInvolConv)
                    .HasColumnName("RETIRE_INVOL_CONV")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RetireResImpact)
                    .HasColumnName("RETIRE_RES_IMPACT")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Retirements)
                    .HasColumnName("RETIREMENTS")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SalvageExtraord)
                    .HasColumnName("SALVAGE_EXTRAORD")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SalvageInvolConv)
                    .HasColumnName("SALVAGE_INVOL_CONV")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SalvageResImpact)
                    .HasColumnName("SALVAGE_RES_IMPACT")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SlReserve)
                    .HasColumnName("SL_RESERVE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SlReserveEnd)
                    .HasColumnName("SL_RESERVE_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Summary4562Id).HasColumnName("SUMMARY_4562_ID");

                entity.Property(e => e.TaxBalance)
                    .HasColumnName("TAX_BALANCE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxBalanceEnd)
                    .HasColumnName("TAX_BALANCE_END")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxBookId).HasColumnName("TAX_BOOK_ID");

                entity.Property(e => e.TaxCreditId).HasColumnName("TAX_CREDIT_ID");

                entity.Property(e => e.TaxLawId).HasColumnName("TAX_LAW_ID");

                entity.Property(e => e.TaxLayerId).HasColumnName("TAX_LAYER_ID");

                entity.Property(e => e.TaxLimitId).HasColumnName("TAX_LIMIT_ID");

                entity.Property(e => e.TaxRateId).HasColumnName("TAX_RATE_ID");

                entity.Property(e => e.TaxRecordId).HasColumnName("TAX_RECORD_ID");

                entity.Property(e => e.TaxYear)
                    .HasColumnName("TAX_YEAR")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("date");

                entity.Property(e => e.TransferDepr)
                    .HasColumnName("TRANSFER_DEPR")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.TransferResImpact)
                    .HasColumnName("TRANSFER_RES_IMPACT")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Transfers)
                    .HasColumnName("TRANSFERS")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TypeOfPropertyId).HasColumnName("TYPE_OF_PROPERTY_ID");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxDepreciationTransfer>(entity =>
            {
                entity.HasKey(p => new { p.TaxTransferId, p.TaxBookId, p.TaxRecordId });

                entity.ToTable("TAX_DEPRECIATION_TRANSFER", "staging");

                entity.HasIndex(e => new { e.TaxTransferId, e.TaxBookId, e.TaxYear, e.TaxRecordId, e.TimeStamp, e.UserId, e.BookBalance, e.TaxBalance, e.AccumReserve, e.SlReserve, e.FixedDepreciableBase, e.EstimatedSalvage, e.AccumSalvage, e.AccumOrdinaryRetires, e.ReserveAtSwitch, e.Quantity, e.Additions, e.CalcDepreciation })
                    .HasName("ClusteredIndex_17e531c4dbee4e8fb2a41d82d61c0507");

                entity.Property(e => e.AccumOrdinaryRetires)
                    .HasColumnName("ACCUM_ORDINARY_RETIRES")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccumReserve)
                    .HasColumnName("ACCUM_RESERVE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccumSalvage)
                    .HasColumnName("ACCUM_SALVAGE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Additions)
                    .HasColumnName("ADDITIONS")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.BookBalance)
                    .HasColumnName("BOOK_BALANCE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CalcDepreciation)
                    .HasColumnName("CALC_DEPRECIATION")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.EstimatedSalvage)
                    .HasColumnName("ESTIMATED_SALVAGE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FixedDepreciableBase)
                    .HasColumnName("FIXED_DEPRECIABLE_BASE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReserveAtSwitch)
                    .HasColumnName("RESERVE_AT_SWITCH")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SlReserve)
                    .HasColumnName("SL_RESERVE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxBalance)
                    .HasColumnName("TAX_BALANCE")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxBookId).HasColumnName("TAX_BOOK_ID");

                entity.Property(e => e.TaxRecordId).HasColumnName("TAX_RECORD_ID");

                entity.Property(e => e.TaxTransferId).HasColumnName("TAX_TRANSFER_ID");

                entity.Property(e => e.TaxYear)
                    .HasColumnName("TAX_YEAR")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxInclude>(entity =>
            {
                entity.ToTable("TAX_INCLUDE", "staging");

                entity.HasIndex(e => new { e.TaxIncludeId, e.Description, e.TimeStamp, e.UserId })
                    .HasName("ClusteredIndex_d042499e9f9f4fdf9958136017336dae");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxIncludeId).HasColumnName("TAX_INCLUDE_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxIncludeActivity>(entity =>
            {
                entity.HasKey(p => new { p.TaxIncludeId, p.TaxBookId });

                entity.ToTable("TAX_INCLUDE_ACTIVITY", "staging");

                entity.HasIndex(e => new { e.TaxIncludeId, e.TaxBookId, e.TimeStamp, e.UserId })
                    .HasName("ClusteredIndex_1a2ea55e237549e78f7852971438c9a8");

                entity.Property(e => e.TaxBookId).HasColumnName("TAX_BOOK_ID");

                entity.Property(e => e.TaxIncludeId).HasColumnName("TAX_INCLUDE_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxLaw>(entity =>
            {
                entity.ToTable("TAX_LAW", "staging");

                entity.HasIndex(e => new { e.TaxLawId, e.TimeStamp, e.UserId, e.Description })
                    .HasName("ClusteredIndex_41506b874157417aab7ce321452a5880");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxLawId).HasColumnName("TAX_LAW_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxLimit>(entity =>
            {
                entity.ToTable("TAX_LIMIT", "staging");

                entity.HasIndex(e => new { e.TaxLimitId, e.TimeStamp, e.UserId, e.Description, e.TaxCreditPercent, e.BasisReductionPercent, e.ReconcileItemId, e.TaxIncludeId, e.CalcFutureYears, e.CompareRate })
                    .HasName("ClusteredIndex_880f304488224b558ef37faeb6945c66");

                entity.Property(e => e.BasisReductionPercent)
                    .HasColumnName("BASIS_REDUCTION_PERCENT")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.CalcFutureYears)
                    .HasColumnName("CALC_FUTURE_YEARS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CompareRate).HasColumnName("COMPARE_RATE");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.ReconcileItemId).HasColumnName("RECONCILE_ITEM_ID");

                entity.Property(e => e.TaxCreditPercent)
                    .HasColumnName("TAX_CREDIT_PERCENT")
                    .HasColumnType("decimal(22, 8)");

                entity.Property(e => e.TaxIncludeId).HasColumnName("TAX_INCLUDE_ID");

                entity.Property(e => e.TaxLimitId).HasColumnName("TAX_LIMIT_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxLocation>(entity =>
            {
                entity.ToTable("TAX_LOCATION", "staging");

                entity.HasIndex(e => new { e.TaxLocationId, e.TimeStamp, e.UserId, e.Description })
                    .HasName("ClusteredIndex_5b001b9819b34ea096320f62eadb7afa");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.TaxLocationId).HasColumnName("TAX_LOCATION_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxRateControl>(entity =>
            {
                entity.ToTable("TAX_RATE_CONTROL", "staging");

                entity.HasIndex(e => new { e.TaxRateId, e.StartMethod, e.SwitchToMethod, e.TimeStamp, e.UserId, e.Description, e.NetGross, e.SwitchYear, e.SwitchedYear, e.Life, e.HalfYearConvention, e.RoundingConvention, e.RemainingLifePlan, e.TaxRateLock, e.ExtTaxRate })
                    .HasName("ClusteredIndex_60300b484448405a92710e98f01d2de3");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.ExtTaxRate)
                    .HasColumnName("EXT_TAX_RATE")
                    .HasMaxLength(50);

                entity.Property(e => e.HalfYearConvention).HasColumnName("HALF_YEAR_CONVENTION");

                entity.Property(e => e.Life)
                    .HasColumnName("LIFE")
                    .HasColumnType("decimal(22, 8)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NetGross)
                    .HasColumnName("NET_GROSS")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RemainingLifePlan).HasColumnName("REMAINING_LIFE_PLAN");

                entity.Property(e => e.RoundingConvention)
                    .HasColumnName("ROUNDING_CONVENTION")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StartMethod).HasColumnName("START_METHOD");

                entity.Property(e => e.SwitchToMethod).HasColumnName("SWITCH_TO_METHOD");

                entity.Property(e => e.SwitchYear).HasColumnName("SWITCH_YEAR");

                entity.Property(e => e.SwitchedYear).HasColumnName("SWITCHED_YEAR");

                entity.Property(e => e.TaxRateId).HasColumnName("TAX_RATE_ID");

                entity.Property(e => e.TaxRateLock)
                    .HasColumnName("TAX_RATE_LOCK")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxReconcileItem>(entity =>
            {
                entity.ToTable("TAX_RECONCILE_ITEM", "staging");

                entity.HasIndex(e => new { e.ReconcileItemId, e.TimeStamp, e.UserId, e.Description, e.Type, e.InputRetireInd, e.DefaultTaxIncludeId, e.TaxTypeOfPropertyId, e.NetBasisRpt, e.Calced, e.DeprDeduction, e.K1ExportGenInclude })
                    .HasName("ClusteredIndex_0e4a135a0d844481a6f75aab40eda9be");

                entity.Property(e => e.Calced)
                    .HasColumnName("CALCED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefaultTaxIncludeId)
                    .HasColumnName("DEFAULT_TAX_INCLUDE_ID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DeprDeduction)
                    .HasColumnName("DEPR_DEDUCTION")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.InputRetireInd).HasColumnName("INPUT_RETIRE_IND");

                entity.Property(e => e.K1ExportGenInclude).HasColumnName("K1_EXPORT_GEN_INCLUDE");

                entity.Property(e => e.NetBasisRpt).HasColumnName("NET_BASIS_RPT");

                entity.Property(e => e.ReconcileItemId).HasColumnName("RECONCILE_ITEM_ID");

                entity.Property(e => e.TaxTypeOfPropertyId).HasColumnName("TAX_TYPE_OF_PROPERTY_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxRecordControl>(entity =>
            {
                entity.ToTable("TAX_RECORD_CONTROL", "staging");

                entity.HasIndex(e => new { e.TaxRecordId, e.CompanyId, e.TaxClassId, e.VersionId, e.VintageId, e.InServiceMonth, e.TimeStamp, e.TaxLocationId, e.UserId, e.SubTaxClassId, e.AssetId, e.K1ExportId })
                    .HasName("ClusteredIndex_19e03598e8784c08b41237570801dd77");

                entity.Property(e => e.AssetId).HasColumnName("ASSET_ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.InServiceMonth)
                    .HasColumnName("IN_SERVICE_MONTH")
                    .HasColumnType("date");

                entity.Property(e => e.K1ExportId).HasColumnName("K1_EXPORT_ID");

                entity.Property(e => e.SubTaxClassId).HasColumnName("SUB_TAX_CLASS_ID");

                entity.Property(e => e.TaxClassId).HasColumnName("TAX_CLASS_ID");

                entity.Property(e => e.TaxLocationId).HasColumnName("TAX_LOCATION_ID");

                entity.Property(e => e.TaxRecordId).HasColumnName("TAX_RECORD_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);

                entity.Property(e => e.VersionId).HasColumnName("VERSION_ID");

                entity.Property(e => e.VintageId).HasColumnName("VINTAGE_ID");
            });

            modelBuilder.Entity<TaxTransferControl>(entity =>
            {
                entity.ToTable("TAX_TRANSFER_CONTROL", "staging");

                entity.HasIndex(e => new { e.TaxTransferId, e.TimeStamp, e.UserId, e.TaxYear, e.FromTrid, e.ToTrid, e.BookAmount, e.StatusId, e.StatusComment, e.ToTridOffset, e.TransferType, e.PackageId, e.ToTridDefGain, e.Proceeds, e.CreateToTrid, e.VersionId, e.SequenceNumber, e.CalcDeferredGain, e.DeferredGainAmount, e.CompanyId, e.TaxClassId, e.TaxDeprSchemaIdFrom, e.TaxDeprSchemaIdTo, e.DefGainFromTaxClass, e.DefGainToTaxClass, e.DeferredTaxSchemaId, e.Notes, e.DefGainVintageId, e.TaxLayerId, e.AssetId, e.InServiceMonth, e.TransferMonth })
                    .HasName("ClusteredIndex_4720df8f651840939ba4265d5fda4591");

                entity.Property(e => e.AssetId).HasColumnName("ASSET_ID");

                entity.Property(e => e.BookAmount)
                    .HasColumnName("BOOK_AMOUNT")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CalcDeferredGain).HasColumnName("CALC_DEFERRED_GAIN");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.CreateToTrid).HasColumnName("CREATE_TO_TRID");

                entity.Property(e => e.DefGainFromTaxClass).HasColumnName("DEF_GAIN_FROM_TAX_CLASS");

                entity.Property(e => e.DefGainToTaxClass).HasColumnName("DEF_GAIN_TO_TAX_CLASS");

                entity.Property(e => e.DefGainVintageId).HasColumnName("DEF_GAIN_VINTAGE_ID");

                entity.Property(e => e.DeferredGainAmount)
                    .HasColumnName("DEFERRED_GAIN_AMOUNT")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.DeferredTaxSchemaId).HasColumnName("DEFERRED_TAX_SCHEMA_ID");

                entity.Property(e => e.FromTrid).HasColumnName("FROM_TRID");

                entity.Property(e => e.InServiceMonth)
                    .HasColumnName("IN_SERVICE_MONTH")
                    .HasColumnType("date");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(2000);

                entity.Property(e => e.PackageId).HasColumnName("PACKAGE_ID");

                entity.Property(e => e.Proceeds)
                    .HasColumnName("PROCEEDS")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.SequenceNumber)
                    .HasColumnName("SEQUENCE_NUMBER")
                    .HasColumnType("decimal(30, 0)");

                entity.Property(e => e.StatusComment)
                    .HasColumnName("STATUS_COMMENT")
                    .HasMaxLength(255);

                entity.Property(e => e.StatusId)
                    .HasColumnName("STATUS_ID")
                    .HasColumnType("decimal(2, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxClassId).HasColumnName("TAX_CLASS_ID");

                entity.Property(e => e.TaxDeprSchemaIdFrom).HasColumnName("TAX_DEPR_SCHEMA_ID_FROM");

                entity.Property(e => e.TaxDeprSchemaIdTo).HasColumnName("TAX_DEPR_SCHEMA_ID_TO");

                entity.Property(e => e.TaxLayerId).HasColumnName("TAX_LAYER_ID");

                entity.Property(e => e.TaxTransferId).HasColumnName("TAX_TRANSFER_ID");

                entity.Property(e => e.TaxYear)
                    .HasColumnName("TAX_YEAR")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.ToTrid).HasColumnName("TO_TRID");

                entity.Property(e => e.ToTridDefGain).HasColumnName("TO_TRID_DEF_GAIN");

                entity.Property(e => e.ToTridOffset).HasColumnName("TO_TRID_OFFSET");

                entity.Property(e => e.TransferMonth)
                    .HasColumnName("TRANSFER_MONTH")
                    .HasColumnType("date");

                entity.Property(e => e.TransferType)
                    .HasColumnName("TRANSFER_TYPE")
                    .HasMaxLength(35);

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);

                entity.Property(e => e.VersionId).HasColumnName("VERSION_ID");
            });

            modelBuilder.Entity<TaxTypeOfProperty>(entity =>
            {
                entity.ToTable("TAX_TYPE_OF_PROPERTY", "staging");

                entity.HasIndex(e => new { e.TypeOfPropertyId, e.TimeStamp, e.UserId, e.Description, e.ExternalId1, e.ExternalId2, e.ExternalId3, e.ExternalId4, e.ExternalId5, e.ExternalId6, e.ExternalId7, e.ExternalId8, e.ExternalId9, e.ExternalId10, e.ExternalId11, e.ExternalId12, e.ExternalId13, e.ExternalId14, e.ExternalId15, e.ExternalId16, e.ExternalId17, e.ExternalId18, e.ExternalId19, e.ExternalId20, e.ExternalId21, e.ExternalId22, e.ExternalId23, e.ExternalId24, e.ExternalId25, e.ExternalId26, e.ExternalId27, e.ExternalId28, e.ExternalId29, e.ExternalId30, e.ExternalId31, e.ExternalId32, e.ExternalId33, e.ExternalId34, e.ExternalId35, e.ExternalId36, e.ExternalId37, e.ExternalId38, e.ExternalId39, e.ExternalId40, e.ExternalId41 })
                    .HasName("ClusteredIndex_4098c55f9e4d460184a53d4419717290");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId1)
                    .HasColumnName("EXTERNAL_ID1")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId10)
                    .HasColumnName("EXTERNAL_ID10")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId11)
                    .HasColumnName("EXTERNAL_ID11")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId12)
                    .HasColumnName("EXTERNAL_ID12")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId13)
                    .HasColumnName("EXTERNAL_ID13")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId14)
                    .HasColumnName("EXTERNAL_ID14")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId15)
                    .HasColumnName("EXTERNAL_ID15")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId16)
                    .HasColumnName("EXTERNAL_ID16")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId17)
                    .HasColumnName("EXTERNAL_ID17")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId18)
                    .HasColumnName("EXTERNAL_ID18")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId19)
                    .HasColumnName("EXTERNAL_ID19")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId2)
                    .HasColumnName("EXTERNAL_ID2")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId20)
                    .HasColumnName("EXTERNAL_ID20")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId21)
                    .HasColumnName("EXTERNAL_ID21")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId22)
                    .HasColumnName("EXTERNAL_ID22")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId23)
                    .HasColumnName("EXTERNAL_ID23")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId24)
                    .HasColumnName("EXTERNAL_ID24")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId25)
                    .HasColumnName("EXTERNAL_ID25")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId26)
                    .HasColumnName("EXTERNAL_ID26")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId27)
                    .HasColumnName("EXTERNAL_ID27")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId28)
                    .HasColumnName("EXTERNAL_ID28")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId29)
                    .HasColumnName("EXTERNAL_ID29")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId3)
                    .HasColumnName("EXTERNAL_ID3")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId30)
                    .HasColumnName("EXTERNAL_ID30")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId31)
                    .HasColumnName("EXTERNAL_ID31")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId32)
                    .HasColumnName("EXTERNAL_ID32")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId33)
                    .HasColumnName("EXTERNAL_ID33")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId34)
                    .HasColumnName("EXTERNAL_ID34")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId35)
                    .HasColumnName("EXTERNAL_ID35")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId36)
                    .HasColumnName("EXTERNAL_ID36")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId37)
                    .HasColumnName("EXTERNAL_ID37")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId38)
                    .HasColumnName("EXTERNAL_ID38")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId39)
                    .HasColumnName("EXTERNAL_ID39")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId4)
                    .HasColumnName("EXTERNAL_ID4")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId40)
                    .HasColumnName("EXTERNAL_ID40")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId41)
                    .HasColumnName("EXTERNAL_ID41")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId5)
                    .HasColumnName("EXTERNAL_ID5")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId6)
                    .HasColumnName("EXTERNAL_ID6")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId7)
                    .HasColumnName("EXTERNAL_ID7")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId8)
                    .HasColumnName("EXTERNAL_ID8")
                    .HasMaxLength(35);

                entity.Property(e => e.ExternalId9)
                    .HasColumnName("EXTERNAL_ID9")
                    .HasMaxLength(35);

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.TypeOfPropertyId).HasColumnName("TYPE_OF_PROPERTY_ID");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);
            });

            modelBuilder.Entity<TaxVintageConvention>(entity =>
            {
                entity.ToTable("TAX_VINTAGE_CONVENTION", "staging");

                entity.HasIndex(e => new { e.VintageConventionId, e.TimeStamp, e.UserId, e.Description })
                    .HasName("ClusteredIndex_fa32166c9d354570bfc1458581c07637");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);

                entity.Property(e => e.VintageConventionId).HasColumnName("VINTAGE_CONVENTION_ID");
            });

            modelBuilder.Entity<TaxYearVersion>(entity =>
            {
                entity.ToTable("TAX_YEAR_VERSION", "staging");

                entity.HasIndex(e => new { e.TaxYearVersionId, e.VersionId, e.TimeStamp, e.UserId, e.TaxYear, e.TaxYearLock, e.Months })
                    .HasName("ClusteredIndex_f2765b8aa3d94bafa6857516e0a908d2");

                entity.Property(e => e.Months)
                    .HasColumnName("MONTHS")
                    .HasColumnType("decimal(22, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxYear)
                    .HasColumnName("TAX_YEAR")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TaxYearLock).HasColumnName("TAX_YEAR_LOCK");

                entity.Property(e => e.TaxYearVersionId).HasColumnName("TAX_YEAR_VERSION_ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);

                entity.Property(e => e.VersionId).HasColumnName("VERSION_ID");
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.ToTable("VERSION", "staging");

                entity.HasIndex(e => new { e.VersionId, e.TimeStamp, e.UserId, e.Description, e.PriorVersionId, e.LongDescription, e.Official, e.CreateDate, e.LastYear, e.Status, e.VersionTypeId, e.ActualsMonth })
                    .HasName("ClusteredIndex_367152723ca345faba8625ee05578345");

                entity.Property(e => e.ActualsMonth)
                    .HasColumnName("ACTUALS_MONTH")
                    .HasColumnType("decimal(22, 2)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.LastYear).HasColumnName("LAST_YEAR");

                entity.Property(e => e.LongDescription)
                    .HasColumnName("LONG_DESCRIPTION")
                    .HasMaxLength(254);

                entity.Property(e => e.Official).HasColumnName("OFFICIAL");

                entity.Property(e => e.PriorVersionId).HasColumnName("PRIOR_VERSION_ID");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);

                entity.Property(e => e.VersionId).HasColumnName("VERSION_ID");

                entity.Property(e => e.VersionTypeId).HasColumnName("VERSION_TYPE_ID");
            });

            modelBuilder.Entity<VersionType>(entity =>
            {
                entity.ToTable("VERSION_TYPE", "staging");

                entity.HasIndex(e => new { e.VersionTypeId, e.TimeStamp, e.UserId, e.Description })
                    .HasName("ClusteredIndex_a09ae490d2274c2c9c3337e5a6f2beca");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);

                entity.Property(e => e.VersionTypeId).HasColumnName("VERSION_TYPE_ID");
            });

            modelBuilder.Entity<Vintage>(entity =>
            {
                entity.ToTable("VINTAGE", "staging");

                entity.HasIndex(e => new { e.VintageId, e.TimeStamp, e.UserId, e.Description, e.Year, e.StartMonth, e.EndMonth, e.ExtClassCodeValue, e.BonusStartMonth, e.BonusEndMonth, e.VintageConventionId })
                    .HasName("ClusteredIndex_0a49e8f2d345460fabf5cc2842112473");

                entity.Property(e => e.BonusEndMonth).HasColumnName("BONUS_END_MONTH");

                entity.Property(e => e.BonusStartMonth).HasColumnName("BONUS_START_MONTH");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(35);

                entity.Property(e => e.EndMonth).HasColumnName("END_MONTH");

                entity.Property(e => e.ExtClassCodeValue)
                    .HasColumnName("EXT_CLASS_CODE_VALUE")
                    .HasMaxLength(35);

                entity.Property(e => e.StartMonth).HasColumnName("START_MONTH");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasMaxLength(18);

                entity.Property(e => e.VintageConventionId).HasColumnName("VINTAGE_CONVENTION_ID");

                entity.Property(e => e.VintageId).HasColumnName("VINTAGE_ID");

                entity.Property(e => e.Year).HasColumnName("YEAR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
