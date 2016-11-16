namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_Zone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_Zone()
        {
            MST_Division = new HashSet<MST_Division>();
            MST_School = new HashSet<MST_School>();
        }

        [Key]
        public int ZONE_id { get; set; }

        [Required]
        [StringLength(150)]
        public string ZONE_name { get; set; }

        [Required]
        [StringLength(150)]
        public string ZONE_font { get; set; }

        public int PROVINCE_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_Division> MST_Division { get; set; }

        public virtual MST_Province MST_Province { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_School> MST_School { get; set; }
    }
}
