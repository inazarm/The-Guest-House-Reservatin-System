using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheHouse.Models;

namespace TheHouse.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private TheHouseEntities db = new TheHouseEntities();

        // GET: Admin/User
        public ActionResult Index()
        {
            return View(db.tbl_User.ToList());
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User tbl_User = db.tbl_User.Find(id);
            if (tbl_User == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_User tbl_User)
        {
            if (ModelState.IsValid)
            {
                db.tbl_User.Add(tbl_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_User);
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User tbl_User = db.tbl_User.Find(id);
            if (tbl_User == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_User User, HttpPostedFileBase UserImg)
        {
            try
            {
                if (UserImg != null)
                {
                    var filePath = Server.MapPath("~/Content/ProfileImg/" + User.UserImage);
                    if (System.IO.File.Exists(filePath))
                    {
                        string ext = Path.GetExtension(UserImg.FileName);
                        if (ext == ".png" || ext == ".jpg")
                        {
                            System.IO.File.Delete(filePath);
                            UserImg.SaveAs(Path.Combine(Server.MapPath("~/Content/ProfileImg/"),Path.GetFileName(User.UserEmail + " " + ext)));
                            User.UserImage = User.UserEmail + " " + ext;
                            db.Entry(User).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Only .PNG .JPG files allowed!";
                            return View();
                        }

                    }
                    else
                    {
                        string ext = Path.GetExtension(UserImg.FileName);
                        UserImg.SaveAs(Path.Combine(Server.MapPath("~/Content/ProfileImg/"), Path.GetFileName(User.UserEmail + " " + ext)));
                        User.UserImage = User.UserEmail + " " + ext;
                        db.Entry(User).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    User.UserImage = User.UserImage;
                    db.Entry(User).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User tbl_User = db.tbl_User.Find(id);
            if (tbl_User == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_User tbl_User = db.tbl_User.Find(id);
            db.tbl_User.Remove(tbl_User);
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
