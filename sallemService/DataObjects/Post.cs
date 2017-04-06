
namespace sallemService.DataObjects
{
    using Microsoft.Azure.Mobile.Server;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post : EntityData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Comments = new HashSet<Comment>();
            PostAbuses = new HashSet<PostAbus>();
            PostImages = new HashSet<PostImage>();
        }

        

        [Required]
        [StringLength(50)]
        public string PostedAt { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [StringLength(128)]
        public string ActivityId { get; set; }

        [StringLength(128)]
        public string ImagePath { get; set; }

        public virtual Activity Activity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostAbus> PostAbuses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostImage> PostImages { get; set; }

        public virtual User User { get; set; }
    }
}
