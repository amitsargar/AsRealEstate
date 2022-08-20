using AsRealEstate2.Models;
using System.Linq;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class RoleController : Controller
    {
        AsRealEstateDbContext db = new AsRealEstateDbContext();
        // GET: Role
        public ActionResult Index()
        {
            var roles = db.Roles.ToList();
            return View();
        }
    }
}