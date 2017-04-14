using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sallemService.DataObjects
{
    public class PostsView
    {
        public string PostId { get; set; }
        public string PostedAt { get; set; }
        public string Subject { get; set; }
        public string PosterId { get; set; }
        public string ImagePath { get; set; }
        public string PostImage { get; set; }
        public string PosterFirstName { get; set; }
        public string PosterLastName { get; set; }
        public string PosterImage { get; set; }
        public CommentsView[] PostComments { get; set; }
    }
}