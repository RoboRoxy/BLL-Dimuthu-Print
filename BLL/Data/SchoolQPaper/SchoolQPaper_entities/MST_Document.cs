namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_Document
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_Document()
        {
            TRN_Receipt_D = new HashSet<TRN_Receipt_D>();
            TRN_Receivable = new HashSet<TRN_Receivable>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DOCU_id { get; set; }

        [Required]
        [StringLength(50)]
        public string DOCU_name { get; set; }

        [Required]
        [StringLength(5)]
        public string DOCU_prefix { get; set; }

        public int DOCU_last_no { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_Receipt_D> TRN_Receipt_D { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_Receivable> TRN_Receivable { get; set; }
    }
}
