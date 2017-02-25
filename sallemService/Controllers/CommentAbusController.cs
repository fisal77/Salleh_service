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
    public class CommentAbusController : TableController<CommentAbus>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sallemContext context = new sallemContext();
            DomainManager = new EntityDomainManager<CommentAbus>(context, Request);
        }

        // GET tables/CommentAbus
        public IQueryable<CommentAbus> GetAllCommentAbus()
        {
            return Query(); 
        }

        // GET tables/CommentAbus/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CommentAbus> GetCommentAbus(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CommentAbus/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CommentAbus> PatchCommentAbus(string id, Delta<CommentAbus> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/CommentAbus
        public async Task<IHttpActionResult> PostCommentAbus(CommentAbus item)
        {
            CommentAbus current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CommentAbus/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCommentAbus(string id)
        {
             return DeleteAsync(id);
        }
    }
}
