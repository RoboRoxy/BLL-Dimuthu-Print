namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_PayType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_PayType()
        {
            TRN_PaperOrder01_H = new HashSet<TRN_PaperOrder01_H>();
            TRN_PaperOrder02_H = new HashSet<TRN_PaperOrder02_H>();
            TRN_Receipt_PayType = new HashSet<TRN_Receipt_PayType>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PAYTYP_id { get; set; }

        [Required]
        [StringLength(50)]
        public string PAYTYP_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_PaperOrder01_H> TRN_PaperOrder01_H { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_PaperOrder02_H> TRN_PaperOrder02_H { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_Receipt_PayType> TRN_Receipt_PayType { get; set; }
    }
}
