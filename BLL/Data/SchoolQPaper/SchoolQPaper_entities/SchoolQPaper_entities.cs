namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SchoolQPaper_entities : DbContext
    {
        public SchoolQPaper_entities()
            : base("name=SchoolQPaper_entities")
        {
        }

        public virtual DbSet<MST_Agent> MST_Agent { get; set; }
        public virtual DbSet<MST_DeliveryMethod> MST_DeliveryMethod { get; set; }
        public virtual DbSet<MST_Division> MST_Division { get; set; }
        public virtual DbSet<MST_Document> MST_Document { get; set; }
        public virtual DbSet<MST_Grade> MST_Grade { get; set; }
        public virtual DbSet<MST_GradSubj> MST_GradSubj { get; set; }
        public virtual DbSet<MST_PayType> MST_PayType { get; set; }
        public virtual DbSet<MST_Province> MST_Province { get; set; }
        public virtual DbSet<MST_School> MST_School { get; set; }
        public virtual DbSet<MST_Subject> MST_Subject { get; set; }
        public virtual DbSet<MST_TrainStation> MST_TrainStation { get; set; }
        public virtual DbSet<MST_Zone> MST_Zone { get; set; }
        public virtual DbSet<TRN_PaperOrder01_D> TRN_PaperOrder01_D { get; set; }
        public virtual DbSet<TRN_PaperOrder01_H> TRN_PaperOrder01_H { get; set; }
        public virtual DbSet<TRN_PaperOrder02_D> TRN_PaperOrder02_D { get; set; }
        public virtual DbSet<TRN_PaperOrder02_H> TRN_PaperOrder02_H { get; set; }
        public virtual DbSet<TRN_Receipt_CHQ_Info> TRN_Receipt_CHQ_Info { get; set; }
        public virtual DbSet<TRN_Receipt_D> TRN_Receipt_D { get; set; }
        public virtual DbSet<TRN_Receipt_H> TRN_Receipt_H { get; set; }
        public virtual DbSet<TRN_Receipt_MO_Info> TRN_Receipt_MO_Info { get; set; }
        public virtual DbSet<TRN_Receipt_PayType> TRN_Receipt_PayType { get; set; }
        public virtual DbSet<TRN_Receivable> TRN_Receivable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MST_DeliveryMethod>()
                .HasMany(e => e.TRN_PaperOrder01_H)
                .WithRequired(e => e.MST_DeliveryMethod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_DeliveryMethod>()
                .HasMany(e => e.TRN_PaperOrder02_H)
                .WithRequired(e => e.MST_DeliveryMethod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_Document>()
                .HasMany(e => e.TRN_Receipt_D)
                .WithRequired(e => e.MST_Document)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_Document>()
                .HasMany(e => e.TRN_Receivable)
                .WithRequired(e => e.MST_Document)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_Grade>()
                .Property(e => e.GRADE_paper_price)
                .HasPrecision(5, 2);

            modelBuilder.Entity<MST_Grade>()
                .HasMany(e => e.MST_GradSubj)
                .WithRequired(e => e.MST_Grade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_Grade>()
                .HasMany(e => e.TRN_PaperOrder01_D)
                .WithRequired(e => e.MST_Grade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_Grade>()
                .HasMany(e => e.TRN_PaperOrder02_D)
                .WithRequired(e => e.MST_Grade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_PayType>()
                .HasMany(e => e.TRN_PaperOrder01_H)
                .WithRequired(e => e.MST_PayType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_PayType>()
                .HasMany(e => e.TRN_PaperOrder02_H)
                .WithRequired(e => e.MST_PayType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_PayType>()
                .HasMany(e => e.TRN_Receipt_PayType)
                .WithRequired(e => e.MST_PayType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_Province>()
                .HasMany(e => e.MST_Zone)
                .WithRequired(e => e.MST_Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_School>()
                .HasMany(e => e.TRN_PaperOrder01_H)
                .WithRequired(e => e.MST_School)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_School>()
                .HasMany(e => e.TRN_PaperOrder02_H)
                .WithRequired(e => e.MST_School)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_Subject>()
                .HasMany(e => e.MST_GradSubj)
                .WithRequired(e => e.MST_Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_Subject>()
                .HasMany(e => e.TRN_PaperOrder01_D)
                .WithRequired(e => e.MST_Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_Subject>()
                .HasMany(e => e.TRN_PaperOrder02_D)
                .WithRequired(e => e.MST_Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_Zone>()
                .HasMany(e => e.MST_Division)
                .WithRequired(e => e.MST_Zone)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRN_PaperOrder01_H>()
                .Property(e => e.PPRODR01_advanced_pay)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRN_PaperOrder01_H>()
                .Property(e => e.PPRODR01_gross_tot)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRN_PaperOrder01_H>()
                .Property(e => e.PPRODR01_discount_amnt)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRN_PaperOrder01_H>()
                .Property(e => e.PPRODR01_net_tot)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRN_PaperOrder01_H>()
                .Property(e => e.PPRODR01_discount_percnt)
                .HasPrecision(4, 2);

            modelBuilder.Entity<TRN_PaperOrder01_H>()
                .HasMany(e => e.TRN_PaperOrder01_D)
                .WithRequired(e => e.TRN_PaperOrder01_H)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRN_PaperOrder02_H>()
                .Property(e => e.PPRODR02_advanced_pay)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRN_PaperOrder02_H>()
                .Property(e => e.PPRODR02_gross_tot)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRN_PaperOrder02_H>()
                .Property(e => e.PPRODR02_discount_amnt)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRN_PaperOrder02_H>()
                .Property(e => e.PPRODR02_net_tot)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRN_PaperOrder02_H>()
                .Property(e => e.PPRODR02_discount_percnt)
                .HasPrecision(4, 2);

            modelBuilder.Entity<TRN_PaperOrder02_H>()
                .HasMany(e => e.TRN_PaperOrder02_D)
                .WithRequired(e => e.TRN_PaperOrder02_H)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRN_Receipt_D>()
                .Property(e => e.RECEIPTD_amount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRN_Receipt_H>()
                .Property(e => e.RECEIPT_amount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRN_Receipt_H>()
                .HasMany(e => e.TRN_Receipt_D)
                .WithRequired(e => e.TRN_Receipt_H)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRN_Receipt_H>()
                .HasMany(e => e.TRN_Receipt_PayType)
                .WithRequired(e => e.TRN_Receipt_H)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRN_Receipt_PayType>()
                .Property(e => e.RECEIPTPAYTYP_amount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRN_Receipt_PayType>()
                .HasMany(e => e.TRN_Receipt_CHQ_Info)
                .WithRequired(e => e.TRN_Receipt_PayType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRN_Receipt_PayType>()
                .HasMany(e => e.TRN_Receipt_MO_Info)
                .WithRequired(e => e.TRN_Receipt_PayType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRN_Receivable>()
                .Property(e => e.RECEIVABLES_value)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRN_Receivable>()
                .Property(e => e.RECEIVABLES_balance)
                .HasPrecision(12, 2);
        }
    }
}
