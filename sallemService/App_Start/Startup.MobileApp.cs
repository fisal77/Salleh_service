using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using sallemService.DataObjects;
using sallemService.Models;
using Owin;

namespace sallemService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;


            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new sallemInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<sallemContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class sallemInitializer : CreateDatabaseIfNotExists<sallemContext>
    {
        protected override void Seed(sallemContext context)
        {
            //List<TodoItem> todoItems = new List<TodoItem>
            //{
            //    new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
            //    new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            //};

            //foreach (TodoItem todoItem in todoItems)
            //{
            //    context.Set<TodoItem>().Add(todoItem);
            //}
            //Guid userId = Guid.NewGuid();
            //Guid friendId = Guid.NewGuid();
            //Guid postId = Guid.NewGuid();
            //Guid commentId = Guid.NewGuid();
            //Guid activityId = Guid.NewGuid();

            //List<User> users = new List<User>
            //{
            //    new User { Id = userId ,FirstName = "Abdullah", LastName ="BaMusa",
            //                Email="x.bamusa@gmail.com", Avatar = new byte[6], StatusID = 0 },
            //     new User { Id = friendId ,FirstName = "Muhammad", LastName ="Ali",
            //                Email="sss@gmai.com", Avatar = new byte[8], StatusID = 0 }

            //};

            //foreach (User user in users)
            //{
            //    context.Set<User>().Add(user);
            //}

            //List<Activity> activities = new List<Activity>
            //{
            //    new Activity { Id = activityId, OrganizerId = userId,
            //                    HeldOn = DateTime.Now.ToString(), Longitude = 122.1254265M, Latitude = 54.1254265M,
            //                    Subject = "Study" }


            //};

            //foreach (Activity act in activities)
            //{
            //    context.Set<Activity>().Add(act);
            //}
            //List<ActivityDetail> details = new List<ActivityDetail>
            //{
            //    new ActivityDetail { Id = Guid.NewGuid(), ActivityId = activityId, ParticipantId = friendId,ParticipationStatus = 0 }


            //};

            //foreach (ActivityDetail det in details)
            //{
            //    context.Set<ActivityDetail>().Add(det);
            //}

            //List<Comment> comments = new List<Comment>
            //{
            //    new Comment { Id = commentId, PostId = postId, UserId = userId,
            //        CommentedAt = DateTime.Now.ToString(), Subject = "gfdgdfgfd" }


            //};

            //foreach (Comment act in comments)
            //{
            //    context.Set<Comment>().Add(act);
            //}
            //List<CommentAbus> comabuses = new List<CommentAbus>
            //{
            //    new CommentAbus { Id = Guid.NewGuid(), CommentId = commentId, ReporterId = userId,TypeId = 0, StatusId = 0 }


            //};

            //foreach (CommentAbus act in comabuses)
            //{
            //    context.Set<CommentAbus>().Add(act);
            //}
            //List<Friendship> friends = new List<Friendship>
            //{
            //    new Friendship {Id = userId, FriendId = friendId, StatusId = 0 }


            //};

            //foreach (Friendship act in friends)
            //{
            //    context.Set<Friendship>().Add(act);
            //}

            //List<Post> posts = new List<Post>
            //{
            //    new Post { Id = Guid.NewGuid(), UserId = userId, ActivityId = activityId,
            //        PostedAt = DateTime.Now.ToString(), Subject = "Hello, this the first post" }


            //};

            //foreach (Post act in posts)
            //{
            //    context.Set<Post>().Add(act);
            //}

            //List<PostImage> postImages = new List<PostImage>
            //{
            //    new PostImage { Id = Guid.NewGuid(), PostId = postId }


            //};

            //foreach (PostImage act in postImages)
            //{
            //    context.Set<PostImage>().Add(act);
            //}

            //List<UserLocation> locations = new List<UserLocation>
            //{
            //    new UserLocation { Id = Guid.NewGuid(), Longitude = 44.542145M, Latitude = 88.5412546M, SeenAt = DateTime.Now.ToString() }


            //};

            //foreach (UserLocation act in locations)
            //{
            //    context.Set<UserLocation>().Add(act);
            //}






            base.Seed(context);
        }
    }
}

