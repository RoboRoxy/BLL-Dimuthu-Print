namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_Agent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_Agent()
        {
            MST_School = new HashSet<MST_School>();
            TRN_Receipt_H = new HashSet<TRN_Receipt_H>();
        }

        [Key]
        public int AGENT_id { get; set; }

        [Required]
        [StringLength(150)]
        public string AGENT_name { get; set; }

        [Required]
        [StringLength(150)]
        public string AGENT_font { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_School> MST_School { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_Receipt_H> TRN_Receipt_H { get; set; }
    }
}
