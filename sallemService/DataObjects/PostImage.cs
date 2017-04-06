namespace sallemService.DataObjects
{
    using Microsoft.Azure.Mobile.Server;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PostImage : EntityData
    {
        [Required]
        [StringLength(128)]
        public string PostId { get; set; }

        public string Path { get; set; }

        public virtual Post Post { get; set; }




    }
}
