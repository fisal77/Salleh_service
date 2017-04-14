using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using System.Threading.Tasks;
using System.Collections.Generic;
using sallemService.DataObjects;
using sallemService.Models;
using System.Linq;
using System.Data.Entity;

namespace sallemService.Controllers
{
    [MobileAppController]
    public class PostsViewController : ApiController
    {
        // GET api/PostsView
        public string Get()
        {
            return "Hello from custom controller!";
        }
        // GET api/PostsView/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<List<PostsView>> GetCustomPosts(string id, string update)
        {
            return GetPostsViewSync(id, update);
        }
        private async Task<List<PostsView>> GetPostsViewSync(string id, string lastUpdate)
        {
            List<PostsView> friendsPosts = new List<PostsView>();
            try
            {
                string i = id;
                sallemContext context = new sallemContext();

                var friends = await context.Friendships.Where(x => x.Id == i
                 && x.StatusId == 2
                ).Select(x => x.FriendId).ToListAsync();
                friends.Add(id);
                List<PostsView> posts = new List<PostsView>();
                if (lastUpdate != null && !string.IsNullOrEmpty(lastUpdate))
                {
                    posts = await context.PostsViews.Where
                        (x => friends.Contains(x.PosterId)
                          && string.Compare(x.PostedAt, lastUpdate) > 0
                        ).OrderByDescending(x => x.PostedAt)
                        .ToListAsync();
                }
                else
                {
                    posts = await context.PostsViews.Where
                       (x => friends.Contains(x.PosterId))
                       .OrderByDescending(x => x.PostedAt)
                       .ToListAsync();
                }
                foreach (var item in posts)
                {
                    string tempPostId = item.PostId;
                    var postComments = await context.CommentsViews.Where(
                        x => x.PostId == tempPostId
                        ).OrderByDescending(x => x.CommentDate).ToListAsync();
                    PostsView friendPost = new PostsView();
                    friendPost.PostId = item.PostId;
                    friendPost.PostedAt = item.PostedAt;
                    friendPost.Subject = item.Subject;
                    friendPost.PosterId = item.PosterId;
                    friendPost.ImagePath = item.ImagePath;
                    friendPost.PostImage = item.PostImage;
                    friendPost.PosterFirstName = item.PosterFirstName;
                    friendPost.PosterLastName = item.PosterLastName;
                    friendPost.PosterImage = item.PosterImage;
                    friendPost.PostComments = postComments.ToArray();

                    friendsPosts.Add(friendPost);
                }
                return friendsPosts;
            }
            catch (System.Exception e)
            {
                string m = e.Message;
                throw;
            }


        }
    }
}
