using AsRealEstate2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class PropertyController : Controller
    {
        AsRealEstateDbContext db = new AsRealEstateDbContext();
        // GET: Role
        public ActionResult Index()
        {
            var properties = db.Properties.ToList();
            return View(properties);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Property property)
        {
            try
            {
                db.Properties.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                return View();
            }

        }
        public ActionResult Edit(int Id)
        {
            var property = db.Properties.Single(c => c.Id == Id);
            return View(property);
        }


        [HttpPost]
        public ActionResult Edit(int Id, Property property)
        {
            try
            {
                //var _property = db.Locations.Single(c => c.Id == Id);
                //_property = property;
                //if (TryUpdateModel(_property))
                //{
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
                if (ModelState.IsValid)
                {
                    db.Entry(property).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (System.Exception)
            {
                return View();
            }
        }

        public ActionResult Details(int Id)
        {
            var property = db.Properties.Single(c => c.Id == Id);
            return View(property);
        }

        public ActionResult Delete(int Id)
        {
            var property = db.Properties.Single(c => c.Id == Id);
            return View(property);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var property = db.Properties.Single(c => c.Id == Id);
            db.Properties.Remove(property);
            db.SaveChanges();
            return RedirectToAction("Index");

            //return View(property);
        }
    }
}