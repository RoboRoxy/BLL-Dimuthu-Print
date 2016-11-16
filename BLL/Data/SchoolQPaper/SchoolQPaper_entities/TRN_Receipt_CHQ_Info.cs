namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRN_Receipt_CHQ_Info
    {
        [Key]
        public int RECEIPTCHQ_id { get; set; }

        [Required]
        [StringLength(12)]
        public string RECEIPTCHQ_chq_no { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RECEIPTCHQ_date { get; set; }

        public int RECEIPTPAYTYP_id { get; set; }

        public virtual TRN_Receipt_PayType TRN_Receipt_PayType { get; set; }
    }
}
