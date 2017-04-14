using sallemService.DataObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace sallemService.Models
{
    public class PostsViewConfig : EntityTypeConfiguration<PostsView>
    {
        public PostsViewConfig()
        {
            HasKey(x => x.PostId);
            ToTable("PostsView");
        }
    }
}