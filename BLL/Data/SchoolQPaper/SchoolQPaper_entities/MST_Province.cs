namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_Province
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_Province()
        {
            MST_School = new HashSet<MST_School>();
            MST_Zone = new HashSet<MST_Zone>();
        }

        [Key]
        public int PROVINCE_id { get; set; }

        [Required]
        [StringLength(150)]
        public string PROVINCE_name { get; set; }

        [Required]
        [StringLength(150)]
        public string PROVINCE_font { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_School> MST_School { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_Zone> MST_Zone { get; set; }
    }
}
