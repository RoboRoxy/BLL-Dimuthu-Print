namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRN_Receipt_MO_Info
    {
        [Key]
        public int RECEIPTMO_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RECEIPTMO_date { get; set; }

        [StringLength(30)]
        public string RECEIPTMO_no { get; set; }

        [StringLength(150)]
        public string RECEIPTMO_office { get; set; }

        public int RECEIPTPAYTYP_id { get; set; }

        public virtual TRN_Receipt_PayType TRN_Receipt_PayType { get; set; }
    }
}
