using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcAdvance01.Models;

namespace MvcAdvance01.Controllers
{
    public class baseSalariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: baseSalaries
        public ActionResult Index()
        {
            var baseSalaries = db.baseSalaries.Include(b => b.Year);
            return View(baseSalaries.ToList());
        }

        // GET: baseSalaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            baseSalary baseSalary = db.baseSalaries.Find(id);
            if (baseSalary == null)
            {
                return HttpNotFound();
            }
            return View(baseSalary);
        }

        // GET: baseSalaries/Create
        public ActionResult Create()
        {
            ViewBag.YearID = new SelectList(db.Years, "ID", "Year");
            return View();
        }

        // POST: baseSalaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,YearID,BaseSalaryDaily,HomeSalary,NavSalary,BonSalary,EzafeTimeSalary,RestSalary,KasrGeibat,SaftPrice,levelPrice")] baseSalary baseSalary)
        {
            if (ModelState.IsValid)
            {
                db.baseSalaries.Add(baseSalary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.YearID = new SelectList(db.Years, "ID", "Year", baseSalary.YearID);
            return View(baseSalary);
        }

        // GET: baseSalaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            baseSalary baseSalary = db.baseSalaries.Find(id);
            if (baseSalary == null)
            {
                return HttpNotFound();
            }
            ViewBag.YearID = new SelectList(db.Years, "ID", "Year", baseSalary.YearID);
            return View(baseSalary);
        }

        // POST: baseSalaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,YearID,BaseSalaryDaily,HomeSalary,NavSalary,BonSalary,EzafeTimeSalary,RestSalary,KasrGeibat,SaftPrice,levelPrice")] baseSalary baseSalary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseSalary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YearID = new SelectList(db.Years, "ID", "Year", baseSalary.YearID);
            return View(baseSalary);
        }

        // GET: baseSalaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            baseSalary baseSalary = db.baseSalaries.Find(id);
            if (baseSalary == null)
            {
                return HttpNotFound();
            }
            return View(baseSalary);
        }

        // POST: baseSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            baseSalary baseSalary = db.baseSalaries.Find(id);
            db.baseSalaries.Remove(baseSalary);
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
    }
}
