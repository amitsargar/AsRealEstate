using AsRealEstate2.Models;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class HomeController : Controller
    {
        AsRealEstateDbContext db = new AsRealEstateDbContext();
        public ActionResult Index()
        {
            //var roles = db.Roles.ToList();
            return View();
        }
    }
}