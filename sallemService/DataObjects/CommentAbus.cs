namespace sallemService.DataObjects
{
    using Microsoft.Azure.Mobile.Server;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommentAbuses")]
    public partial class CommentAbus : EntityData
    {
        

        [Required]
        [StringLength(128)]
        public string CommentId { get; set; }

        [Required]
        [StringLength(128)]
        public string ReporterId { get; set; }

        public int TypeId { get; set; }

        public int StatusId { get; set; }

        public virtual Comment Comment { get; set; }

        public virtual User User { get; set; }
    }
}
