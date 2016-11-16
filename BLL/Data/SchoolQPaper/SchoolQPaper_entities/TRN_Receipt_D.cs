namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRN_Receipt_D
    {
        [Key]
        public int RECEIPTD_id { get; set; }

        public decimal RECEIPTD_amount { get; set; }

        public int RECEIPTD_doc_id { get; set; }

        public int RECEIPT_id { get; set; }

        public int DOCU_id { get; set; }

        public virtual MST_Document MST_Document { get; set; }

        public virtual TRN_Receipt_H TRN_Receipt_H { get; set; }
    }
}
