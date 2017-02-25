namespace sallemService.DataObjects
{
    using Microsoft.Azure.Mobile.Server;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Friendship : EntityData
    {
        [Key]
        [Column(Order = 0)]
        public new Guid Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid FriendId { get; set; }

        [Required]
        [StringLength(23)]
        public string FriendsSince { get; set; }

        public byte StatusId { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
