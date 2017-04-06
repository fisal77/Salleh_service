using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using sallemService.DataObjects;
using sallemService.Models;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Azure.NotificationHubs;

namespace sallemService.Controllers
{
    public class UserController : TableController<User>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sallemContext context = new sallemContext();
            DomainManager = new EntityDomainManager<User>(context, Request);
        }

        // GET tables/User
        public IQueryable<User> GetAllUser()
        {
            return Query(); 
        }

        // GET tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<User> GetUser(string id)
        {
            return Lookup(id);
        }
        

        // PATCH tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<User> PatchUser(string id, Delta<User> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/User
        public async Task<IHttpActionResult> PostUser(User item)
        {
            //Original code
            User current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
            //
            

         
        

    }

        // DELETE tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUser(string id)
        {
             return DeleteAsync(id);
        }


        //GET tables/user/4B9CD758-7F2D-4245-B5B1-B3152654DA7A
        public SingleResult<User> GetUserByEmail(string email)
        {
            SingleResult<User> result = new SingleResult<User>(Query().Where(x => x.Email == email));
            return result;
        }
    }
}
