using AsRealEstate2.Models;
using System.Linq;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class LocationController : Controller
    {
        AsRealEstateDbContext db = new AsRealEstateDbContext();
        public ActionResult Index()
        {
            var lst = db.Locations.ToList();

            return View(lst);
        }
    }
}