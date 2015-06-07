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
    public class SpeakerSessionItemController : TableController<SpeakerSessionItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<SpeakerSessionItem>(context, Request, Services);
        }

        // GET tables/SpeakerSessionItem
        public IQueryable<SpeakerSessionItem> GetAllSpeakerSessionItem()
        {
            return Query(); 
        }

        // GET tables/SpeakerSessionItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<SpeakerSessionItem> GetSpeakerSessionItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/SpeakerSessionItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<SpeakerSessionItem> PatchSpeakerSessionItem(string id, Delta<SpeakerSessionItem> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/SpeakerSessionItem
        public async Task<IHttpActionResult> PostSpeakerSessionItem(SpeakerSessionItem item)
        {
            SpeakerSessionItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/SpeakerSessionItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSpeakerSessionItem(string id)
        {
             return DeleteAsync(id);
        }

    }
}