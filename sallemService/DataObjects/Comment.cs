namespace sallemService.DataObjects
{
    using Microsoft.Azure.Mobile.Server;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment : EntityData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            CommentAbuses = new HashSet<CommentAbus>();
        }

        

        [Required]
        [StringLength(128)]
        public string PostId { get; set; }

        [Required]
        [StringLength(23)]
        public string CommentedAt { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        public string Subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentAbus> CommentAbuses { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
