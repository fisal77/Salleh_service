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
    public class PostImageController : TableController<PostImage>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sallemContext context = new sallemContext();
            DomainManager = new EntityDomainManager<PostImage>(context, Request);
        }

        // GET tables/PostImage
        public IQueryable<PostImage> GetAllPostImage()
        {
            return Query(); 
        }

        // GET tables/PostImage/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PostImage> GetPostImage(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/PostImage/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<PostImage> PatchPostImage(string id, Delta<PostImage> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/PostImage
        public async Task<IHttpActionResult> PostPostImage(PostImage item)
        {
            PostImage current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/PostImage/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePostImage(string id)
        {
             return DeleteAsync(id);
        }
    }
}
