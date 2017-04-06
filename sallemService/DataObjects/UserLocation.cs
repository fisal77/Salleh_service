namespace sallemService.DataObjects
{
    using Microsoft.Azure.Mobile.Server;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserLocation : EntityData
    {
        

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        [Required]
        [StringLength(23)]
        public string SeenAt { get; set; }

        public virtual User User { get; set; }
    }
}
