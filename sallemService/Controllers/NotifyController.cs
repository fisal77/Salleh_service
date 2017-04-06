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
    public class NotifyController : TableController<Notify>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sallemContext context = new sallemContext();
            DomainManager = new EntityDomainManager<Notify>(context, Request);
        }

        // GET tables/Notify
        public IQueryable<Notify> GetAllNotify()
        {
            return Query(); 
        }

        // GET tables/Notify/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Notify> GetNotify(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Notify/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Notify> PatchNotify(string id, Delta<Notify> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Notify
        public async Task<IHttpActionResult> PostNotify(Notify item)
        {
            Notify current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Notify/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteNotify(string id)
        {
             return DeleteAsync(id);
        }
    }
}
