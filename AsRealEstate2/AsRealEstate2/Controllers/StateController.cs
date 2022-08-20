using AsRealEstate2.Models;
using System.Linq;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class StateController : Controller
    {
        AsRealEstateDbContext db = new AsRealEstateDbContext();
        public ActionResult Index()
        {
            var lst = db.States.ToList();

            return View(lst);
        }
    }
}