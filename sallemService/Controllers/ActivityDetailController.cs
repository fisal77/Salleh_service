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
    public class ActivityDetailController : TableController<ActivityDetail>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sallemContext context = new sallemContext();
            DomainManager = new EntityDomainManager<ActivityDetail>(context, Request);
        }

        // GET tables/ActivityDetail
        public IQueryable<ActivityDetail> GetAllActivityDetail()
        {
            return Query(); 
        }

        // GET tables/ActivityDetail/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ActivityDetail> GetActivityDetail(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ActivityDetail/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ActivityDetail> PatchActivityDetail(string id, Delta<ActivityDetail> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/ActivityDetail
        public async Task<IHttpActionResult> PostActivityDetail(ActivityDetail item)
        {
            ActivityDetail current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ActivityDetail/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteActivityDetail(string id)
        {
             return DeleteAsync(id);
        }
    }
}
