using AsRealEstate2.Models;
using System.Linq;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class PropertyModeController : Controller
    {
        AsRealEstateDbContext db = new AsRealEstateDbContext();
        public ActionResult Index()
        {
            var lst = db.PropertyModes.ToList();

            return View(lst);
        }
    }
}