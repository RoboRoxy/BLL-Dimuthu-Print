namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRN_PaperOrder02_H
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRN_PaperOrder02_H()
        {
            TRN_PaperOrder02_D = new HashSet<TRN_PaperOrder02_D>();
        }

        [Key]
        public int PPRODR02_id { get; set; }

        [Required]
        [StringLength(10)]
        public string PPRODR02_code { get; set; }

        public DateTime PPRODR02_datetime { get; set; }

        [StringLength(300)]
        public string PPRODR02_remarks { get; set; }

        public decimal PPRODR02_advanced_pay { get; set; }

        [StringLength(12)]
        public string PPRODR02_cheque_no { get; set; }

        [StringLength(150)]
        public string PPRODR02_mo_office { get; set; }

        [Required]
        [StringLength(150)]
        public string PPRODR02_font { get; set; }

        public decimal PPRODR02_gross_tot { get; set; }

        public decimal PPRODR02_discount_amnt { get; set; }

        public decimal PPRODR02_net_tot { get; set; }

        public decimal PPRODR02_discount_percnt { get; set; }

        [StringLength(50)]
        public string PPRODR02_telephone { get; set; }

        [StringLength(100)]
        public string PPRODR02_train_received_by { get; set; }

        [StringLength(20)]
        public string PPRODR02_train_received_by_nic { get; set; }

        public int? TRAINST_id { get; set; }

        public int SCHL_id { get; set; }

        public int DELIMETH_id { get; set; }

        public int PAYTYP_id { get; set; }

        public virtual MST_DeliveryMethod MST_DeliveryMethod { get; set; }

        public virtual MST_PayType MST_PayType { get; set; }

        public virtual MST_School MST_School { get; set; }

        public virtual MST_TrainStation MST_TrainStation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_PaperOrder02_D> TRN_PaperOrder02_D { get; set; }
    }
}
