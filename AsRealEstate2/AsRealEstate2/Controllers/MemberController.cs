using AsRealEstate2.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class MemberController : Controller
    {
        AsRealEstateDbContext db = new AsRealEstateDbContext();
        // GET: Member
        public ActionResult Index()
        {
            var lst = db.Members.ToList();
            //foreach (var member in members)
            //{
            //    member.GenderName = Enum.GetName(typeof(Gender), member.Gender);
            //}
            return View(lst);
        }
    }
}