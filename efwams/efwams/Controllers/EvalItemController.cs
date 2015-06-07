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
    public class EvalItemController : TableController<EvalItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<EvalItem>(context, Request, Services);
        }

        // GET tables/EvalItem
        public IQueryable<EvalItem> GetAllEvalItem()
        {
            return Query(); 
        }

        // GET tables/EvalItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<EvalItem> GetEvalItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/EvalItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<EvalItem> PatchEvalItem(string id, Delta<EvalItem> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/EvalItem
        public async Task<IHttpActionResult> PostEvalItem(EvalItem item)
        {
            EvalItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/EvalItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteEvalItem(string id)
        {
             return DeleteAsync(id);
        }

    }
}