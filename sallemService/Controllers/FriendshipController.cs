using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using sallemService.DataObjects;
using sallemService.Models;

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
