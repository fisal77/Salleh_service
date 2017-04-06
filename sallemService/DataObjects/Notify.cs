using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sallemService.DataObjects
{
    public class Notify:EntityData
    {
        [Required]
        [StringLength(128)]
        public String SourceUser { get; set; }

        [Required]
        [StringLength(128)]
        public String DestUser { get; set; }

        [Required]
        [StringLength(23)]
        public String PublishedAt { get; set; }

        [Required]
        [StringLength(20)]
        public String Title { get; set; }

        [Required]
        public String Subject { get; set; }
                
        public bool Delivered { get; set; }





    }
}