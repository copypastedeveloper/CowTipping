using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CowTipping.Messages;
using EasyNetQ;

namespace CowTippingApi.Controllers
{
    [RoutePrefix("api/cow/tip")]
    public class TipACowController : ApiController
    {

        [HttpPost,Route("{cowName}")]
        public HttpResponseMessage TipIt(string cowName)
        {
            if (string.IsNullOrWhiteSpace(cowName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Must supply a cow name");
            }

            var bus = RabbitHutch.CreateBus("host=localhost");

            bus.Publish(new TimeToTipACow(cowName, DateTime.Now));

            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
