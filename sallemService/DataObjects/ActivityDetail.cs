namespace sallemService.DataObjects
{
    using Microsoft.Azure.Mobile.Server;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ActivityDetail : EntityData
    {
        

        [Required]
        [StringLength(128)]
        public string ActivityId { get; set; }

        [Required]
        [StringLength(128)]
        public string ParticipantId { get; set; }

        public int ParticipationStatus { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual User User { get; set; }
    }
}
