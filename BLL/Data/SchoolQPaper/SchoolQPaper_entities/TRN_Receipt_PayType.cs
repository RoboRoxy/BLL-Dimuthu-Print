namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRN_Receipt_PayType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRN_Receipt_PayType()
        {
            TRN_Receipt_CHQ_Info = new HashSet<TRN_Receipt_CHQ_Info>();
            TRN_Receipt_MO_Info = new HashSet<TRN_Receipt_MO_Info>();
        }

        [Key]
        public int RECEIPTPAYTYP_id { get; set; }

        public decimal RECEIPTPAYTYP_amount { get; set; }

        public int PAYTYP_id { get; set; }

        public int RECEIPT_id { get; set; }

        public virtual MST_PayType MST_PayType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_Receipt_CHQ_Info> TRN_Receipt_CHQ_Info { get; set; }

        public virtual TRN_Receipt_H TRN_Receipt_H { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_Receipt_MO_Info> TRN_Receipt_MO_Info { get; set; }
    }
}
