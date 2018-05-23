using System.Web.Mvc;

namespace CowTippingApi.Controllers
{
    public class Cows : Controller
    {
        // GET
        public ActionResult Index()
        {
            return
            View();
        }
    }
}