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
            //Declare result list.
            List<PostsView> friendsPosts = new List<PostsView>();
            try
            {

                string i = id;
                sallemContext context = new sallemContext();
                //First get friends of current user id.
                var friends = await context.Friendships.Where(x => x.Id == i
                 && x.StatusId == 2
                ).Select(x => x.FriendId).ToListAsync();
                //Add user himself.
                friends.Add(id);
                List<PostsView> posts = new List<PostsView>();
                //In case need only refresh. Then load posts from last update date and onward.
                if (lastUpdate != null && !string.IsNullOrEmpty(lastUpdate))
                {
                    //Find posts that has user id that is one of the id(s) contained in friends
                    //list including the current user himself where postedat field is greater than last
                    //update argument.
                      posts = await context.PostsViews.Where
                        (x => friends.Contains(x.PosterId)
                          && string.Compare(x.PostedAt, lastUpdate) > 0
                        ).OrderByDescending(x => x.PostedAt)
                        .ToListAsync();
                }
                //Otherwise, get all posts.
                else
                {
                    //Find posts that has user id that is one of the id(s) contained in friends list
                     //including the current user himself.
                       posts = await context.PostsViews.Where
                       (x => friends.Contains(x.PosterId))
                       .OrderByDescending(x => x.PostedAt)
                       .ToListAsync();
                }
                //Materialize the result.
                foreach (var item in posts)
                {
                    string tempPostId = item.PostId;
                    //Find comments of this post.
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
