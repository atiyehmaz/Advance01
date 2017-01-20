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
    public class PriceTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PriceTypes
        public ActionResult Index()
        {
            var priceTypes = db.PriceTypes.Include(p => p.CustomerType).Include(p => p.Product);
            return View(priceTypes.ToList());
        }

        // GET: PriceTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceType priceType = db.PriceTypes.Find(id);
             

            if (priceType == null)
            {
                return HttpNotFound();
            }
            return View(priceType);
        }

        // GET: PriceTypes/Create
        public ActionResult Create()
        {
            ViewBag.CustomerTypeID = new SelectList(db.CustomerTypes, "ID", "Title");
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Title");
            return View();
        }

        // POST: PriceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Factory,Final,TakhfifKharid,Eshantion,Marjin,Promotion,Tablighat,Rebate,TakhfifForush,ArzeshAfzude,StartDateLicence,EndDateLicence,StartDatePro,EndDatePro,CustomerTypeID,ProductID")] PriceType priceType)
        {
            if (ModelState.IsValid)
            {
                db.PriceTypes.Add(priceType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerTypeID = new SelectList(db.CustomerTypes, "ID", "Title", priceType.CustomerTypeID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Title", priceType.ProductID);
            return View(priceType);
        }

        // GET: PriceTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceType priceType = db.PriceTypes.Find(id);
            if (priceType == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerTypeID = new SelectList(db.CustomerTypes, "ID", "Title", priceType.CustomerTypeID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Title", priceType.ProductID);
            return View(priceType);
        }

        // POST: PriceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Factory,Final,TakhfifKharid,Eshantion,Marjin,Promotion,Tablighat,Rebate,TakhfifForush,ArzeshAfzude,StartDateLicence,EndDateLicence,StartDatePro,EndDatePro,CustomerTypeID,ProductID")] PriceType priceType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerTypeID = new SelectList(db.CustomerTypes, "ID", "Title", priceType.CustomerTypeID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Title", priceType.ProductID);
            return View(priceType);
        }

        // GET: PriceTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceType priceType = db.PriceTypes.Find(id);
            if (priceType == null)
            {
                return HttpNotFound();
            }
            return View(priceType);
        }

        // POST: PriceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PriceType priceType = db.PriceTypes.Find(id);
            db.PriceTypes.Remove(priceType);
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
