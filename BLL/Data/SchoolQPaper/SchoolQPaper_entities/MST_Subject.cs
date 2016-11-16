namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_Subject()
        {
            MST_GradSubj = new HashSet<MST_GradSubj>();
            TRN_PaperOrder01_D = new HashSet<TRN_PaperOrder01_D>();
            TRN_PaperOrder02_D = new HashSet<TRN_PaperOrder02_D>();
        }

        [Key]
        public int SUBJ_id { get; set; }

        [Required]
        [StringLength(200)]
        public string SUBJ_name { get; set; }

        [Required]
        [StringLength(150)]
        public string SUBJ_font { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_GradSubj> MST_GradSubj { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_PaperOrder01_D> TRN_PaperOrder01_D { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_PaperOrder02_D> TRN_PaperOrder02_D { get; set; }
    }
}
