namespace BLL.Data.SchoolQPaper.SchoolQPaper_entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_School
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_School()
        {
            TRN_PaperOrder01_H = new HashSet<TRN_PaperOrder01_H>();
            TRN_PaperOrder02_H = new HashSet<TRN_PaperOrder02_H>();
            TRN_Receipt_H = new HashSet<TRN_Receipt_H>();
        }

        [Key]
        public int SCHL_id { get; set; }

        [Required]
        [StringLength(10)]
        public string SCHL_code { get; set; }

        [Required]
        [StringLength(250)]
        public string SCHL_name { get; set; }

        [StringLength(500)]
        public string SCHL_address { get; set; }

        [Required]
        [StringLength(150)]
        public string SCHL_font { get; set; }

        [StringLength(250)]
        public string SCHL_principal_name { get; set; }

        [StringLength(500)]
        public string SCHL_principal_address { get; set; }

        [StringLength(15)]
        public string SCHL_principal_tele { get; set; }

        public int? AGENT_id { get; set; }

        public int? PROVINCE_id { get; set; }

        public int? ZONE_id { get; set; }

        public int? DIVISION_id { get; set; }

        public virtual MST_Agent MST_Agent { get; set; }

        public virtual MST_Division MST_Division { get; set; }

        public virtual MST_Province MST_Province { get; set; }

        public virtual MST_Zone MST_Zone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_PaperOrder01_H> TRN_PaperOrder01_H { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_PaperOrder02_H> TRN_PaperOrder02_H { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_Receipt_H> TRN_Receipt_H { get; set; }
    }
}
