using AsRealEstate2.Models;
using System.Data.Entity;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(City city)
        {
            try
            {
                db.Cities.Add(city);
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
            var city = db.Cities.Single(c => c.CityId == Id);
            return View(city);
        }


        [HttpPost]
        public ActionResult Edit(int Id, City city)
        {
            try
            {
                //var _city = db.Cities.Single(c => c.Id == Id);
                //_city = city;
                //if (TryUpdateModel(_city))
                //{
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
                if (ModelState.IsValid)
                {
                    db.Entry(city).State = EntityState.Modified;
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
            var city = db.Cities.Single(c => c.CityId == Id);
            return View(city);
        }

        public ActionResult Delete(int Id)
        {
            var city = db.Cities.Single(c => c.CityId == Id);
            return View(city);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var city = db.Cities.Single(c => c.CityId == Id);
            db.Cities.Remove(city);
            db.SaveChanges();
            return RedirectToAction("Index");

            //return View(city);
        }
    }
}