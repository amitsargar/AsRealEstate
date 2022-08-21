using AsRealEstate2.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class StateController : Controller
    {
        AsRealEstateDbContext db = new AsRealEstateDbContext();
        public ActionResult Index()
        {
            var lst = db.States.ToList();

            return View(lst);
        }

        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            ViewBag.CreatedBy = new SelectList(db.Members, "MemberId", "MemberName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(State state)
        {
            try
            {
                db.States.Add(state);
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
            var state = db.States.Single(c => c.StateId == Id);
            return View(state);
        }


        [HttpPost]
        public ActionResult Edit(int Id, State state)
        {
            try
            {
                //var _state = db.States.Single(c => c.Id == Id);
                //_state = state;
                //if (TryUpdateModel(_state))
                //{
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
                if (ModelState.IsValid)
                {
                    db.Entry(state).State = EntityState.Modified;
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
            var state = db.States.Single(c => c.StateId == Id);
            return View(state);
        }

        public ActionResult Delete(int Id)
        {
            var state = db.States.Single(c => c.StateId == Id);
            return View(state);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var state = db.States.Single(c => c.StateId == Id);
            db.States.Remove(state);
            db.SaveChanges();
            return RedirectToAction("Index");

            //return View(state);
        }
    }
}