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
    public class UsersController : Controller
    {
        private TheHouseEntities db = new TheHouseEntities();

        // GET: Admin/Users
        public ActionResult Index()
        {
            var Role = Session["app"] as tbl_User;
            if (Role.UserType=="Admin")
            {
                var Data = db.tbl_User.ToList();
                return View(Data);
            }
            else
            {
                var Data = db.tbl_User.Where(user => user.User_Id == Role.User_Id).ToList();
                return View(Data);
            }
            
        }

        //Search Owner By Name
        public PartialViewResult SearchOwner(string q)
        {
            try
            {
                if (q.Length > 0)
                {
                    var record = db.tbl_User.Where(x => x.FullName.Contains(q)).ToList();
                    return PartialView(record);
                }
                else
                {
                    var record = db.tbl_User.ToList();
                    return PartialView(record);
                }
            }
            catch (Exception ex)
            {
                var record = db.tbl_User.ToList();
                return PartialView(record);
            }
        }

        // GET: Admin/Users/Details/5
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

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_User NewUser,HttpPostedFileBase ProfileImg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isEmailAlreadyExists = db.tbl_User.Any(email => email.UserEmail == NewUser.UserEmail);
                    if (isEmailAlreadyExists)
                    {
                        ModelState.AddModelError("Email", "User with this email already exists");
                        return View(NewUser);
                    }
                    else
                    {
                        NewUser.UserImage = "defualt.png";
                        NewUser.CreatedDate = DateTime.Now.ToLongDateString();
                        NewUser.UserType = "User";
                        NewUser.isActive = true;
                        db.tbl_User.Add(NewUser);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.Error = "Image is null";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        var isEmailAlreadyExists = db.tbl_User.Any(email=>email.UserEmail==NewUser.UserEmail);
            //        if (ProfileImg!=null)
            //        {
            //            string ext = Path.GetExtension(ProfileImg.FileName);
            //            if (isEmailAlreadyExists)
            //            {
            //                ModelState.AddModelError("Email", "User with this email already exists");
            //                return View(NewUser);
            //            }
            //            else
            //            {
            //                if (ext.ToLower() == ".jpeg" || ext.ToLower() == ".png" || ext.ToLower() == ".jpg")
            //                {
            //                    var fileName = Path.GetFileName(ProfileImg.FileName + " " + NewUser.User_Id + " " + ext);
            //                    string imgPath = Path.Combine(Server.MapPath("~/Content/ProfileImg/"), fileName);
            //                    ProfileImg.SaveAs(imgPath);
            //                    NewUser.UserImage = fileName;
            //                    NewUser.CreatedDate = DateTime.Now.ToLongDateString();
            //                    NewUser.UserType = "User";
            //                    NewUser.isActive = true;
            //                    db.tbl_User.Add(NewUser);
            //                    db.SaveChanges();
            //                    return RedirectToAction("Index");
            //                }
            //                else
            //                {
            //                    ViewBag.Error = "Invalid File Type";
            //                    return View();
            //                }
            //            }
            //        }
            //        else
            //        {
            //            ViewBag.Error = "Image is null";
            //            return View();
            //        }

            //    }

            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Error = "Exception occurs" + ex.Message;
            //    return View();
            //}


            //return View(NewUser);
        }

        // GET: Admin/Users/Edit/5
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

        // POST: Admin/Users/Edit/5
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
                        if (ext == ".png" || ext == ".jpg" || ext==".jpeg")
                        {
                            System.IO.File.Delete(filePath);
                            UserImg.SaveAs(Path.Combine(Server.MapPath("~/Content/ProfileImg/"), Path.GetFileName(User.UserEmail + " " + ext)));
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
                return View(ex.Message);
            }
        }

        // GET: Admin/Users/Delete/5
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

        // POST: Admin/Users/Delete/5
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
