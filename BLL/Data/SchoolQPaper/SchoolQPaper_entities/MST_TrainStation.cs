namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_TrainStation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_TrainStation()
        {
            TRN_PaperOrder01_H = new HashSet<TRN_PaperOrder01_H>();
            TRN_PaperOrder02_H = new HashSet<TRN_PaperOrder02_H>();
        }

        [Key]
        public int TRAINST_id { get; set; }

        [Required]
        [StringLength(200)]
        public string TRAINST_name { get; set; }

        [Required]
        [StringLength(150)]
        public string TRAINST_font { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_PaperOrder01_H> TRN_PaperOrder01_H { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_PaperOrder02_H> TRN_PaperOrder02_H { get; set; }
    }
}
