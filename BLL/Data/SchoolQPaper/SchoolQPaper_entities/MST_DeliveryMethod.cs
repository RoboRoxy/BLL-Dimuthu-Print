namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_DeliveryMethod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_DeliveryMethod()
        {
            TRN_PaperOrder01_H = new HashSet<TRN_PaperOrder01_H>();
            TRN_PaperOrder02_H = new HashSet<TRN_PaperOrder02_H>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DELIMETH_id { get; set; }

        [Required]
        [StringLength(50)]
        public string DELIMETH_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_PaperOrder01_H> TRN_PaperOrder01_H { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_PaperOrder02_H> TRN_PaperOrder02_H { get; set; }
    }
}
