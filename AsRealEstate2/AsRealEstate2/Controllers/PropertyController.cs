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
            var listedProperties = db.ListedProperties.ToList();
            return View(listedProperties);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ListedProperty listedProperty)
        {
            try
            {
                db.ListedProperties.Add(listedProperty);
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
            var property = db.ListedProperties.Single(c => c.ListedPropertyId == Id);
            return View(property);
        }


        [HttpPost]
        public ActionResult Edit(int Id, ListedProperty listedProperty)
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
                    db.Entry(listedProperty).State = EntityState.Modified;
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
            var listedProperty = db.ListedProperties.Single(c => c.ListedPropertyId == Id);
            return View(listedProperty);
        }

        public ActionResult Delete(int Id)
        {
            var listedProperty = db.ListedProperties.Single(c => c.ListedPropertyId == Id);
            return View(listedProperty);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var listedProperty = db.ListedProperties.Single(c => c.ListedPropertyId == Id);
            db.ListedProperties.Remove(listedProperty);
            db.SaveChanges();
            return RedirectToAction("Index");

            //return View(property);
        }
    }
}