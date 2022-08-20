using AsRealEstate2.Models;
using System.Linq;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class CityController : Controller
    {
        AsRealEstateDbContext db = new AsRealEstateDbContext();

        public ActionResult Index()
        {
            var lst = db.Cities.ToList();

            return View(lst);
        }
    }
}