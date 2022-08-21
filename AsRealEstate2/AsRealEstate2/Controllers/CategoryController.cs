using AsRealEstate2.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class CategoryController : Controller
    {
        AsRealEstateDbContext db = new AsRealEstateDbContext();
        // GET: Category
        public ActionResult Index()
        {
            var lst = db.Categories.ToList();

            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                db.Categories.Add(category);
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
            var category = db.Categories.Single(c => c.CategoryId == Id);
            return View(category);
        }


        [HttpPost]
        public ActionResult Edit(int Id, Category category)
        {
            try
            {
                //var _category = db.Categories.Single(c => c.Id == Id);
                //_category = category;
                //if (TryUpdateModel(_category))
                //{
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
                if (ModelState.IsValid)
                {
                    db.Entry(category).State = EntityState.Modified;
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
            var category = db.Categories.Single(c => c.CategoryId == Id);
            return View(category);
        }

        public ActionResult Delete(int Id)
        {
            var category = db.Categories.Single(c => c.CategoryId == Id);
            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var category = db.Categories.Single(c => c.CategoryId == Id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");

            //return View(category);
        }
    }
}