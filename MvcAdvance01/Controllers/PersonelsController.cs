using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcAdvance01.Models;
using MvcAdvance01.Models.Utility;

namespace MvcAdvance01.Controllers
{
    public class PersonelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personels
        public ActionResult Index()
        {
        
         
            return View(db.Personels.ToList());
        }

        // GET: Personels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personels.Find(id);

            personel.Birtdate = personel.Birtdate.Value.ToPersian();

            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: Personels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PID,NID,Fullname,Email,Birtdate,Mobile,BankID")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                personel.Birtdate = personel.Birtdate.Value.ToMiladi();
                db.Personels.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personel);
        }

        // GET: Personels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personels.Find(id);
            personel.Birtdate = personel.Birtdate.Value.ToPersian();
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PID,NID,Fullname,Email,Birtdate,Mobile,BankID")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                personel.Birtdate = personel.Birtdate.Value.ToMiladi();
                db.Entry(personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personel);
        }

        // GET: Personels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personels.Find(id);
            personel.Birtdate = personel.Birtdate.Value.ToPersian();
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personel personel = db.Personels.Find(id);
            db.Personels.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        public PartialViewResult _Search(string keyword) 
        {
            System.Threading.Thread.Sleep(2000);

            var searchResult = db.Personels.Where(f => f.Fullname.Contains(keyword)).ToList();
            return(PartialView(searchResult));
        }
    }
}
