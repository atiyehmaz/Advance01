using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcAdvance01.Areas.Administrator.ViewModels;
using MvcAdvance01.Models;

namespace MvcAdvance01.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administrator/Home
        public ActionResult Index()
        {
            Administrator.ViewModels.AdminViewModels oAVM = new ViewModels.AdminViewModels();

            oAVM.Admin = db.Admins.First();
            oAVM.Comments = db.Comments.ToList();
            oAVM.PostCategories = db.PostCategories.ToList();
            oAVM.Posts = db.Posts.ToList();
            oAVM.Prices = db.PriceTypes.ToList();
            oAVM.Users = db.Users.ToList();
            oAVM.Customers = db.Customers.ToList();
            return View(oAVM);
        }

        // GET: Administrator/Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminViewModels adminViewModels = db.AdminViewModels.Find(id);
            if (adminViewModels == null)
            {
                return HttpNotFound();
            }
            return View(adminViewModels);
        }

        // GET: Administrator/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] AdminViewModels adminViewModels)
        {
            if (ModelState.IsValid)
            {
                db.AdminViewModels.Add(adminViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminViewModels);
        }

        // GET: Administrator/Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminViewModels adminViewModels = db.AdminViewModels.Find(id);
            if (adminViewModels == null)
            {
                return HttpNotFound();
            }
            return View(adminViewModels);
        }

        // POST: Administrator/Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] AdminViewModels adminViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminViewModels);
        }

        // GET: Administrator/Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminViewModels adminViewModels = db.AdminViewModels.Find(id);
            if (adminViewModels == null)
            {
                return HttpNotFound();
            }
            return View(adminViewModels);
        }

        // POST: Administrator/Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminViewModels adminViewModels = db.AdminViewModels.Find(id);
            db.AdminViewModels.Remove(adminViewModels);
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
