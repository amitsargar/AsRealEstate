using AsRealEstate2.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AsRealEstate2.Controllers
{
    public class MemberController : Controller
    {
        AsRealEstateDbContext db = new AsRealEstateDbContext();
        // GET: Member
        public ActionResult Index()
        {
            var lst = db.Members.ToList();
            //foreach (var member in members)
            //{
            //    member.GenderName = Enum.GetName(typeof(Gender), member.Gender);
            //}
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            try
            {
                db.Members.Add(member);
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
            var member = db.Members.Single(c => c.MemberId == Id);
            return View(member);
        }


        [HttpPost]
        public ActionResult Edit(int Id, Member member)
        {
            try
            {
                //var _member = db.members.Single(c => c.Id == Id);
                //_member = member;
                //if (TryUpdateModel(_member))
                //{
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}
                if (ModelState.IsValid)
                {
                    db.Entry(member).State = EntityState.Modified;
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
            var member = db.Members.Single(c => c.MemberId == Id);
            return View(member);
        }

        public ActionResult Delete(int Id)
        {
            var member = db.Members.Single(c => c.MemberId == Id);
            return View(member);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var member = db.Members.Single(c => c.MemberId == Id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");

            //return View(member);
        }
    }
}