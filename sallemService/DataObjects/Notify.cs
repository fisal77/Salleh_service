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
        public string SourceUser { get; set; }

        [Required]
        [StringLength(128)]
        public string DestUser { get; set; }

        [Required]
        [StringLength(23)]
        public string PublishedAt { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]        
        public bool Delivered { get; set; }





    }
}