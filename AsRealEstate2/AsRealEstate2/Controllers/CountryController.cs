using AsRealEstate2.Models;
using AsRealEstate2.Utilities;
using System.Data.Entity;
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
            //Common.SendEmail();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            try
            {
                db.Countries.Add(country);
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
            var country = db.Countries.Single(c => c.CountryId == Id);
            return View(country);
        }


        [HttpPost]
        public ActionResult Edit(int Id, Country country)
        {
            try
            {
                //var _country = db.Countries.Single(c => c.Id == Id);
                //_country = country;
                //if (TryUpdateModel(_country))
                //{
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
                if (ModelState.IsValid)
                {
                    db.Entry(country).State = EntityState.Modified;
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
            var country = db.Countries.Single(c => c.CountryId == Id);
            return View(country);
        }

        public ActionResult Delete(int Id)
        {
            var country = db.Countries.Single(c => c.CountryId == Id);
            return View(country);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var country = db.Countries.Single(c => c.CountryId == Id);
            db.Countries.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");

            //return View(country);
        }

    }
}