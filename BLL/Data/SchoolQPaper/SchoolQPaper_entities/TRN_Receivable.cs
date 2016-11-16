namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRN_Receivable
    {
        [Key]
        public int RECEIVABLES_id { get; set; }

        public int RECEIVABLES_doc_id { get; set; }

        public decimal RECEIVABLES_value { get; set; }

        public decimal RECEIVABLES_balance { get; set; }

        public int? RECEIVABLES_ref_id { get; set; }

        public int DOCU_id { get; set; }

        public virtual MST_Document MST_Document { get; set; }
    }
}
