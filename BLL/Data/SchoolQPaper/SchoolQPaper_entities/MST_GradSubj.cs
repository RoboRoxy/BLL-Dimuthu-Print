namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_GradSubj
    {
        [Key]
        public int GRDSUBJ_id { get; set; }

        public bool GRDSUBJ_autofill { get; set; }

        public bool GRDSUBJ_splitval { get; set; }

        public int? GRDSUBJ_group { get; set; }

        public int GRADE_id { get; set; }

        public int SUBJ_id { get; set; }

        public virtual MST_Grade MST_Grade { get; set; }

        public virtual MST_Subject MST_Subject { get; set; }
    }
}
