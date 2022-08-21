using AsRealEstate2.Models;
using System.Data.Entity;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Location location)
        {
            try
            {
                db.Locations.Add(location);
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
            var location = db.Locations.Single(c => c.CityId == Id);
            return View(location);
        }


        [HttpPost]
        public ActionResult Edit(int Id, Location location)
        {
            try
            {
                //var _location = db.Locations.Single(c => c.Id == Id);
                //_location = location;
                //if (TryUpdateModel(_location))
                //{
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
                if (ModelState.IsValid)
                {
                    db.Entry(location).State = EntityState.Modified;
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
            var location = db.Locations.Single(c => c.CityId == Id);
            return View(location);
        }

        public ActionResult Delete(int Id)
        {
            var location = db.Locations.Single(c => c.CityId == Id);
            return View(location);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var location = db.Locations.Single(c => c.CityId == Id);
            db.Locations.Remove(location);
            db.SaveChanges();
            return RedirectToAction("Index");

            //return View(location);
        }
    }
}