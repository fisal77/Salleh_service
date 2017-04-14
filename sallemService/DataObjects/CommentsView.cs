using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sallemService.DataObjects
{
    public class CommentsView
    {
        public string CommentId { get; set; }
        public string CommentDate { get; set; }
        public string Comment { get; set; }
        public string PostId { get; set; }
        public string CommenterId { get; set; }
        public string CommenterFirstName { get; set; }
        public string CommenterLastName { get; set; }
        public string CommenterImage { get; set; }
    }
}