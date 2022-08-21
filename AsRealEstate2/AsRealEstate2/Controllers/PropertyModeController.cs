using AsRealEstate2.Models;
using System.Data.Entity;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PropertyMode propertyMode)
        {
            try
            {
                db.PropertyModes.Add(propertyMode);
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
            var propertyMode = db.PropertyModes.Single(c => c.PropertyModeId == Id);
            return View(propertyMode);
        }


        [HttpPost]
        public ActionResult Edit(int Id, PropertyMode propertyMode)
        {
            try
            {
                //var _propertyMode = db.PropertyModes.Single(c => c.Id == Id);
                //_propertyMode = propertyMode;
                //if (TryUpdateModel(_propertyMode))
                //{
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
                if (ModelState.IsValid)
                {
                    db.Entry(propertyMode).State = EntityState.Modified;
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
            var propertyMode = db.PropertyModes.Single(c => c.PropertyModeId == Id);
            return View(propertyMode);
        }

        public ActionResult Delete(int Id)
        {
            var propertyMode = db.PropertyModes.Single(c => c.PropertyModeId == Id);
            return View(propertyMode);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var propertyMode = db.PropertyModes.Single(c => c.PropertyModeId == Id);
            db.PropertyModes.Remove(propertyMode);
            db.SaveChanges();
            return RedirectToAction("Index");

            //return View(propertyMode);
        }
    }
}