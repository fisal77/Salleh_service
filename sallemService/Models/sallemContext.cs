using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using sallemService.DataObjects;

namespace sallemService.Models
{
    public class sallemContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public sallemContext() : base(connectionStringName)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityDetail> ActivityDetails { get; set; }
        public virtual DbSet<CommentAbus> CommentAbuses { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<PostAbus> PostAbuses { get; set; }
        public virtual DbSet<PostImage> PostImages { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<UserLocation> UserLocations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Notify> Notifies { get; set; }
        public virtual DbSet<PostsView> PostsViews { get; set; }
        public virtual DbSet<CommentsView> CommentsViews { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));

            modelBuilder.Configurations.Add(new PostsViewConfig());
            modelBuilder.Configurations.Add(new CommentsViewConfig());

            modelBuilder.Entity<Activity>()
                 .Property(e => e.HeldOn)
                 .IsFixedLength();

            modelBuilder.Entity<Activity>()
                .Property(e => e.Longitude)
                .HasPrecision(10, 6);

            modelBuilder.Entity<Activity>()
                .Property(e => e.Latitude)
                .HasPrecision(10, 6);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.ActivityDetails)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasMany(e => e.CommentAbuses)
                .WithRequired(e => e.Comment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Friendship>()
                .Property(e => e.Id)
                .HasColumnOrder(0);
            modelBuilder.Entity<Friendship>()
                .Property(e => e.FriendId)
                .HasColumnOrder(1);
            modelBuilder.Entity<Friendship>()
                .Property(e => e.FriendsSince)
                .IsFixedLength();
            modelBuilder.Entity<Post>()
               .HasMany(e => e.PostImages)
               .WithRequired(e => e.Post)
               .WillCascadeOnDelete(false);


            modelBuilder.Entity<Post>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostAbuses)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserLocation>()
                .Property(e => e.Longitude)
                .HasPrecision(10, 6);

            modelBuilder.Entity<UserLocation>()
                .Property(e => e.Latitude)
                .HasPrecision(10, 6);

            modelBuilder.Entity<UserLocation>()
                .Property(e => e.SeenAt)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.JoinedAt)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Activities)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.OrganizerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ActivityDetails)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ParticipantId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CommentAbuses)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ReporterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friendships)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friendships1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.FriendId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PostAbuses)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ReporterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserLocations)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);


        }
    }
}


