namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRN_PaperOrder01_D
    {
        [Key]
        public int PPRODR01D_id { get; set; }

        public int PPRODR01D_paper_qty { get; set; }

        public bool PPRODR01D_ignore_qty { get; set; }

        public int GRADE_id { get; set; }

        public int SUBJ_id { get; set; }

        public int PPRODR01_id { get; set; }

        public virtual MST_Grade MST_Grade { get; set; }

        public virtual MST_Subject MST_Subject { get; set; }

        public virtual TRN_PaperOrder01_H TRN_PaperOrder01_H { get; set; }
    }
}
