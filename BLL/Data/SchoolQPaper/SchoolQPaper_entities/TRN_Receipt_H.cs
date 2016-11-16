namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRN_Receipt_H
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRN_Receipt_H()
        {
            TRN_Receipt_D = new HashSet<TRN_Receipt_D>();
            TRN_Receipt_PayType = new HashSet<TRN_Receipt_PayType>();
        }

        [Key]
        public int RECEIPT_id { get; set; }

        [Required]
        [StringLength(10)]
        public string RECEIPT_code { get; set; }

        public DateTime RECEIPT_date { get; set; }

        public DateTime RECEIPT_tran_date { get; set; }

        public decimal RECEIPT_amount { get; set; }

        [StringLength(300)]
        public string RECEIPT_remarks { get; set; }

        [Required]
        [StringLength(150)]
        public string RECEIPT_font { get; set; }

        public int? SCHL_id { get; set; }

        public int? AGENT_id { get; set; }

        public virtual MST_Agent MST_Agent { get; set; }

        public virtual MST_School MST_School { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_Receipt_D> TRN_Receipt_D { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_Receipt_PayType> TRN_Receipt_PayType { get; set; }
    }
}
