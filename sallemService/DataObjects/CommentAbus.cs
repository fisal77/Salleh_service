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
        public new Guid Id { get; set; }

        public Guid CommentId { get; set; }

        public Guid ReporterId { get; set; }

        public int TypeId { get; set; }

        public int StatusId { get; set; }

        public virtual Comment Comment { get; set; }

        public virtual User User { get; set; }
    }
}
