using AsRealEstate2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class LoginController : Controller
    {
        private AsRealEstateDbContext db = new AsRealEstateDbContext();
        // GET: Login
        public ActionResult Login()
        {
            if (Session["LoggedInUserId"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Country");
            }
        }
        [HttpPost]
        public ActionResult Login(UserLogin UL)
        {
            if (UL == null)
            {
                return View();
            }
            else
            {
                var user = db.Members.Where(u => u.EmailId == UL.EmailId
                                          && u.Password == UL.Password && u.IsActive)
                            .FirstOrDefault();
                if (user != null)
                {
                    Session["LoggedInUserId"] = user.MemberId;
                    Session["LoggedInUserName"] = user.MemberName;
                    Session["LoggedInUserRoleId"] = user.RoleId;
                    return RedirectToAction("Index", "Country");
                }
            }
            return View();
        }
    }
}