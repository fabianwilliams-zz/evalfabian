using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using efwams.DataObjects;
using efwams.Models;

namespace efwams.Controllers
{
    public class EvalUserItemController : TableController<EvalUserItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<EvalUserItem>(context, Request, Services);
        }

        // GET tables/EvalUserItem
        public IQueryable<EvalUserItem> GetAllEvalUserItem()
        {
            return Query(); 
        }

        // GET tables/EvalUserItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<EvalUserItem> GetEvalUserItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/EvalUserItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<EvalUserItem> PatchEvalUserItem(string id, Delta<EvalUserItem> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/EvalUserItem
        public async Task<IHttpActionResult> PostEvalUserItem(EvalUserItem item)
        {
            EvalUserItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/EvalUserItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteEvalUserItem(string id)
        {
             return DeleteAsync(id);
        }

    }
}