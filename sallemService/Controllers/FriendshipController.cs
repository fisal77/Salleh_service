using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using sallemService.DataObjects;
using sallemService.Models;
using System;

namespace sallemService.Controllers
{
    public class FriendshipController : TableController<Friendship>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sallemContext context = new sallemContext();
            DomainManager = new EntityDomainManager<Friendship>(context, Request);
        }

        // GET tables/Friendship
        public IQueryable<Friendship> GetAllFriendship()
        {
            return Query(); 
        }

        // GET tables/Friendship/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Friendship> GetFriendship(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Friendship/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Friendship> PatchFriendship(string id, Delta<Friendship> patch)
        {
             return UpdateAsync(id, patch);
        }
        protected override Task<Friendship> UpdateAsync(string id, Delta<Friendship> patch)
        {
            return LocalUpdate(id, patch);

            //return base.UpdateAsync(id, patch);
        }
        private async Task<Friendship> LocalUpdate(string id, Delta<Friendship> patch)
        {
            try
            {
                Friendship updatable = patch.GetEntity();
                sallemContext context = new sallemContext();
                var friends = context.Friendships;
                var friendOne = friends.Where(x => x.Id == id && x.FriendId == updatable.FriendId).FirstOrDefault();
                if (friendOne != null) //Update first part of friendship
                {
                    friendOne.StatusId = updatable.StatusId;
                    friendOne.FriendsSince = updatable.FriendsSince;
                    //Add the second the part after his react to the request
                    Friendship secondPart = new Friendship();
                    secondPart.Id = friendOne.FriendId;
                    secondPart.FriendId = friendOne.Id;
                    secondPart.FriendsSince = friendOne.FriendsSince;
                    secondPart.StatusId = friendOne.StatusId;
                    secondPart.CreatedAt = DateTime.Now;
                    secondPart.Version = new byte[] { 1 };
                    secondPart.Deleted = false;
                    friends.Add(secondPart);
                }
                await context.SaveChangesAsync();
                return patch.GetEntity();

            }
            catch (Exception e)
            {
                String s = e.Message;
                throw;
            }
        }

        // POST tables/Friendship
        public async Task<IHttpActionResult> PostFriendship(Friendship item)
        {
            Friendship current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Friendship/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFriendship(string id)
        {
             return DeleteAsync(id);
        }
    }
}
