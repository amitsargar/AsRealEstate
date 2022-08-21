using AsRealEstate2.Models;
using System.Data.Entity;
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
            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Role role)
        {
            try
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                return View();
            }

        }
        public ActionResult Edit(int Id)
        {
            var role = db.Roles.Single(c => c.RoleId == Id);
            return View(role);
        }


        [HttpPost]
        public ActionResult Edit(int Id, Role role)
        {
            try
            {
                //var _role = db.Locations.Single(c => c.Id == Id);
                //_role = role;
                //if (TryUpdateModel(_role))
                //{
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
                if (ModelState.IsValid)
                {
                    db.Entry(role).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (System.Exception ex)
            {
                return View();
            }
        }

        public ActionResult Details(int Id)
        {
            var role = db.Roles.Single(c => c.RoleId == Id);
            return View(role);
        }

        public ActionResult Delete(int Id)
        {
            var role = db.Roles.Single(c => c.RoleId == Id);
            return View(role);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var role = db.Roles.Single(c => c.RoleId == Id);
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");

            //return View(role);
        }
    }
}