using AsRealEstate2.Models;
using System.Linq;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class CountryController : Controller
    {
        AsRealEstateDbContext db = new AsRealEstateDbContext();
        public ActionResult Index()
        {
            var lst = db.Countries.ToList();

            return View(lst);
        }
    }
}