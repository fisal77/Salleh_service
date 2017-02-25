namespace sallemService.DataObjects
{
    using Microsoft.Azure.Mobile.Server;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ActivityDetail: EntityData
    {
        public new Guid Id { get; set; }

        public Guid ActivityId { get; set; }

        public Guid ParticipantId { get; set; }

        public byte ParticipationStatus { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual User User { get; set; }
    }
}
