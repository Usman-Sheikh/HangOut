using System.Web.Mvc;

namespace HangOut.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Traditions()
        {
            return View();
        }
        public ActionResult Nightatlahore()
        {
            return View();
        }
        public ActionResult Historicals()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}