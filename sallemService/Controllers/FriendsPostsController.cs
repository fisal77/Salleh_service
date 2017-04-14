using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using System.Threading.Tasks;
using sallemService.Models;
using System.Linq;
using sallemService.DataObjects;
using System.Data.Entity;
using System.Collections.Generic;

namespace sallemService.Controllers
{
    [MobileAppController]
    public class FriendsPostsController : ApiController
    {
        // GET api/FriendsPosts
        public string Get()
        {
            return "Hello from custom controller!";
        }
        // GET api/friendsposts/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<List<FriendPost>> GetFriendsPosts(string id)
        {
            var result = GetFriendsPostsSync(id);
            return result;

            
        }
        private async Task<List<FriendPost>> GetFriendsPostsSync(string id)
        {
            List<FriendPost> friendsPosts = new List<FriendPost>();
            try
            {
                string i = id;
                sallemContext context = new sallemContext();

                var friends = await context.Friendships.Where(x => x.Id == i
                 && x.StatusId == 2
                ).Select(x => x.FriendId).ToListAsync();
                friends.Add(id);
                var posts = await context.Posts.Where
                    (x => friends.Contains(x.UserId)).OrderByDescending(x => x.PostedAt)
                    .ToListAsync();
                foreach (var item in posts)
                {

                    FriendPost friendPost = new FriendPost();
                    friendPost.Id = item.Id;
                    friendPost.PostedAt = item.PostedAt;
                    friendPost.Subject = item.Subject;
                    friendPost.UserId = item.UserId;
                    friendPost.ImagePath = item.ImagePath;
                    friendPost.ActivityId = item.ActivityId;
                    friendPost.PostImage = item.PostImage;
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
public class FriendPost
{
   public string Id { get; set; }
    public string PostedAt { get; set; }

    
    public string Subject { get; set; }

   
    public string UserId { get; set; }

    
    public string ActivityId { get; set; }

    
    public string ImagePath { get; set; }

    public string PostImage { get; set; }

}
public class CustomPost
{
    public string Id { get; set; }
    public string PostedAt { get; set; }


    public string Subject { get; set; }
}
