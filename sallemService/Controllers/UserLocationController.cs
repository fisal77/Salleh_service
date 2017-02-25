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
    public class UserLocationController : TableController<UserLocation>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sallemContext context = new sallemContext();
            DomainManager = new EntityDomainManager<UserLocation>(context, Request);
        }

        // GET tables/UserLocation
        public IQueryable<UserLocation> GetAllUserLocation()
        {
            return Query(); 
        }

        // GET tables/UserLocation/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserLocation> GetUserLocation(string id)
        {
            return Lookup(id);
        }


        // PATCH tables/UserLocation/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserLocation> PatchUserLocation(string id, Delta<UserLocation> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserLocation
        public async Task<IHttpActionResult> PostUserLocation(UserLocation item)
        {
            UserLocation current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserLocation/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserLocation(string id)
        {
             return DeleteAsync(id);
        }
    }
}
