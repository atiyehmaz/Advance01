using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcAdvance01.Areas.Administrator.Models;
using MvcAdvance01.Models;
using MvcAdvance01.Models.Utility;


namespace MvcAdvance01.Areas.Administrator.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        int PageSize = 5;
        int PageIndex = 1;


        // GET: Administrator/Posts
        public ActionResult Index()
        {
            //var posts = db.Posts.Include(p => p.Admin).Include(p => p.PostCategory);
            //return View(posts.ToList());

            //پیجینگ صفحه
            var varPosts0 =
                db.Posts
                .OrderByDescending(current => current.ID)
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize)
                .ToList();
            return View(varPosts0.ToList());






            //    var posts = db.Posts.Include(p => p.Admin).Include(p => p.PostCategory);
            //    return View(posts.ToList());
        }

        //-------------------------------------------------------------
        public ActionResult btnPrev()
        {
            if (PageIndex >= 2)
            {
                PageIndex--;
                var varPosts1 =
                db.Posts
               .OrderByDescending(current => current.ID)
               .Skip((PageIndex - 1) * PageSize)
               .Take(PageSize)
               .ToList();
                return View(varPosts1.ToList());
            }
            var varPosts2 =
              db.Posts
              .OrderByDescending(current => current.ID)
              .Skip((PageIndex - 1) * PageSize)
              .Take(PageSize)
             .ToList();
            return View(varPosts2.ToList());
        }

        //-----------------------------------------------------------

        public ActionResult btnNext()
        {
            PageIndex++;
            var varPosts3 =
            db.Posts
           .OrderByDescending(current => current.ID)
           .Skip((PageIndex - 1) * PageSize)
           .Take(PageSize)
           .ToList();
            return View(varPosts3.ToList());
        }






        // GET: Administrator/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            post.PublishDate = post.PublishDate.Value.ToPersian();
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Administrator/Posts/Create
        public ActionResult Create()
        {
            ViewBag.AdminID = new SelectList(db.Admins, "ID", "Name");
            ViewBag.PostCategoryID = new SelectList(db.PostCategories, "ID", "Name");
            return View();
        }

        // POST: Administrator/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Username,PostWriter,SmallBody,FullBody,Keyword,PublishDate,IsActive,IsCommentable,Image,AdminID,PostCategoryID")] Post post, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                post.PublishDate = post.PublishDate.Value.ToMiladi();

                if (post.Username == null)
                {
                    post.Username = "Administrator";
                }
                //-----------------------------------------------------------------------
                //آپلود عکس در قسمت نگاشت پست جدید

                //حجم فایل قبل از اپلود را مورد بررسی قرار میدهیم
                System.Drawing.Image oImage = System.Drawing.Image.FromStream(UploadImage.InputStream);

                //پسوند فایل را مورد بررسی قرار میدهیم
                string strFileExtention =
                    System.IO.Path.GetExtension(UploadImage.FileName).ToUpper();

                //ماهیت فایل تصویری را مورد بررسی قرار میدهیم
                string strContentType = UploadImage.ContentType.ToUpper();

                if (UploadImage != null)
                {
                    if ((oImage.Width > 1024) || (oImage.Height > 768) || (UploadImage.FileName.Trim() == string.Empty))
                    {
                        post.Image = "blue.png";
                        string strPathName0 = Server.MapPath("~") + "Uploads\\" + post.Image;
                    }

                    else { post.Image = UploadImage.FileName; }
                }

                if ((UploadImage == null)
                    || (UploadImage.ContentLength == 0)
                    || (UploadImage.ContentLength > 1000 * 1024)
                    || (post.Image == null))
                {
                    post.Image = "blue.png";
                    string strPathName0 = Server.MapPath("~") + "Uploads\\" + post.Image;
                }

                else
                {
                    string strPath = Server.MapPath("~") + "Uploads\\";

                    if (System.IO.Directory.Exists(strPath) == false)
                    {
                        System.IO.Directory.CreateDirectory(strPath);
                    }

                    string strPathName = string.Format("{0}\\{1}", strPath, post.Image);

                    UploadImage.SaveAs(strPathName);

                }

                //------------------------------------------------------------------






                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdminID = new SelectList(db.Admins, "ID", "Name", post.AdminID);
            ViewBag.PostCategoryID = new SelectList(db.PostCategories, "ID", "Name", post.PostCategoryID);
            return View(post);
        }

        // GET: Administrator/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            post.PublishDate = post.PublishDate.Value.ToPersian();
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminID = new SelectList(db.Admins, "ID", "Name", post.AdminID);
            ViewBag.PostCategoryID = new SelectList(db.PostCategories, "ID", "Name", post.PostCategoryID);
            return View(post);
        }

        // POST: Administrator/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Username,PostWriter,SmallBody,FullBody,Keyword,PublishDate,IsActive,IsCommentable,Image,AdminID,PostCategoryID")] Post post, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                post.PublishDate = post.PublishDate.Value.ToMiladi();

                if (post.Username == null)
                {
                    post.Username = "Administrator";
                }
                //-----------------------------------------------------------------------
                //آپلود عکس در قسمت نگاشت پست جدید

                //حجم فایل قبل از اپلود را مورد بررسی قرار میدهیم
                System.Drawing.Image oImage = System.Drawing.Image.FromStream(UploadImage.InputStream);

                //پسوند فایل را مورد بررسی قرار میدهیم
                string strFileExtention =
                    System.IO.Path.GetExtension(UploadImage.FileName).ToUpper();

                //ماهیت فایل تصویری را مورد بررسی قرار میدهیم
                string strContentType = UploadImage.ContentType.ToUpper();

                if (UploadImage != null)
                {
                    if ((oImage.Width > 1024) || (oImage.Height > 768) || (UploadImage.FileName.Trim() == string.Empty))
                    {
                        post.Image = "blue.png";
                        string strPathName0 = Server.MapPath("~") + "Uploads\\" + post.Image;
                    }

                    else { post.Image = UploadImage.FileName; }
                }

                if ((UploadImage == null)
                    || (UploadImage.ContentLength == 0)
                    || (UploadImage.ContentLength > 1000 * 1024)
                    || (post.Image == null))
                {
                    post.Image = "blue.png";
                    string strPathName0 = Server.MapPath("~") + "Uploads\\" + post.Image;
                }

                else
                {
                    string strPath = Server.MapPath("~") + "Uploads\\";

                    if (System.IO.Directory.Exists(strPath) == false)
                    {
                        System.IO.Directory.CreateDirectory(strPath);
                    }

                    string strPathName = string.Format("{0}\\{1}", strPath, post.Image);

                    UploadImage.SaveAs(strPathName);

                }

                //------------------------------------------------------------------









                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdminID = new SelectList(db.Admins, "ID", "Name", post.AdminID);
            ViewBag.PostCategoryID = new SelectList(db.PostCategories, "ID", "Name", post.PostCategoryID);
            return View(post);
        }

        // GET: Administrator/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            post.PublishDate = post.PublishDate.Value.ToPersian();
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Administrator/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
