namespace sallemService.DataObjects
{
    using Microsoft.Azure.Mobile.Server;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostAbuses")]
    public partial class PostAbus : EntityData
    {
        

        [Required]
        [StringLength(128)]
        public string PostId { get; set; }

        [Required]
        [StringLength(128)]
        public string ReporterId { get; set; }

        public int TypeId { get; set; }

        public int StatusId { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
