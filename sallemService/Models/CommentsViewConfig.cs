using sallemService.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace sallemService.Models
{
    public class CommentsViewConfig : EntityTypeConfiguration<CommentsView>
    {
        public CommentsViewConfig()
        {
            HasKey(x => x.CommentId);
            ToTable("CommentsView");
        }
    }
}