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
    public class HouseController : Controller
    {
        private TheHouseEntities db = new TheHouseEntities();

        // GET: Admin/House
        public ActionResult Index()
        {
            try
            {
                var userDetails = (tbl_User)Session["App"];
                if (userDetails != null)
                {
                    var dataResult = db.sp_SelectHouseDetailById(userDetails.User_Id).ToList();
                    Session["HD"] = dataResult;
                    return View(dataResult);
                }
                else
                {
                    return RedirectToAction("");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("");
            }
        }

        //Search Hotel By Name
        public PartialViewResult SearchHotel(string q)
        {
            try
            {
                if (q.Length>0)
                {
                    //var record = db.tbl_House.Where(x => x.H_Name.StartsWith(q)).ToList();
                    var record = db.tbl_House.Where(x => x.H_Name.Contains(q)).ToList();
                    return PartialView(record);
                }
                else
                {
                    var record = db.tbl_House.ToList();
                    return PartialView(record);
                }
            }
            catch (Exception ex)
            {
                var record = db.tbl_House.ToList();
                return PartialView(record);
            }
        }

        // GET: Admin/House/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_House tbl_House = db.tbl_House.Find(id);
            if (tbl_House == null)
            {
                return HttpNotFound();
            }
            return View(tbl_House);
        }

        // GET: Admin/House/Create
        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.tbl_User, "User_ID", "FullName");
            return View();
        }

        // POST: Admin/House/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_House NewHouse,HttpPostedFileBase HotelImg)
        {
            try
            {
                var UserDetails = (tbl_User)Session["App"];
                if (ModelState.IsValid)
                {
                    if (HotelImg != null)
                    {
                        string ext = Path.GetExtension(HotelImg.FileName);
                        if (ext == ".jpg" || ext=="png" ||ext == ".jpeg")
                        {
                            var fileName = Path.GetFileName(HotelImg.FileName + " " + NewHouse.H_ID +" "+ext);
                            string imgPath = Path.Combine(Server.MapPath("~/Content/HotelImg/"), fileName);
                            HotelImg.SaveAs(imgPath);
                            NewHouse.H_Image = fileName;
                            NewHouse.H_Status = true;
                            NewHouse.FK_UserID = UserDetails.User_Id;
                            db.tbl_House.Add(NewHouse);
                            db.SaveChanges();
                            ModelState.Clear();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Error = "Upload JPG / PNG format!";
                        }
                    }
                    return View();
                }
                else
                {
                    ViewBag.Error = "Your input data is invalid!";
                    return View(NewHouse);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
 
        }

        // GET: Admin/House/Edit/5
        public ActionResult Edit(int? id)
       {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_House HouseDetails = db.tbl_House.Find(id);
            if (HouseDetails == null)
            {
                return HttpNotFound();
            }
            return View(HouseDetails);
        }

        // POST: Admin/House/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_House House,HttpPostedFileBase HotelImg)
        {
            try
            {
                if (HotelImg!=null)
                {
                    var filePath = Server.MapPath("~/Content/HotelImg/" + House.H_Image);
                    if (System.IO.File.Exists(filePath))
                    {
                        string ext = Path.GetExtension(HotelImg.FileName);
                        if (ext == ".jpg" || ext == "png" || ext == ".jpeg")
                        {
                            System.IO.File.Delete(filePath);
                            HotelImg.SaveAs(Path.Combine(Server.MapPath("~/Content/HotelImg/"), Path.GetFileName(House.H_ID + " " +HotelImg.FileName+ " " +ext)));
                            House.H_Image = House.H_ID + " " + HotelImg.FileName + " " + ext;
                            db.Entry(House).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            
                        }
                        else
                        {
                            ViewBag.Error = "Upload JPG / PNG format!";
                            return View();
                        }
                        
                    }
                    else
                    {
                        string ext = Path.GetExtension(HotelImg.FileName);
                        HotelImg.SaveAs(Path.Combine(Server.MapPath("~/Content/HotelImg/"), Path.GetFileName(House.H_ID + " " + HotelImg.FileName + " " + ext)));
                        House.H_Image = House.H_ID + " " + HotelImg.FileName + " " + ext;
                        db.Entry(House).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    House.H_Image = House.H_Image;
                    db.Entry(House).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Admin/House/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_House tbl_House = db.tbl_House.Find(id);
            if (tbl_House == null)
            {
                return HttpNotFound();
            }
            return View(tbl_House);
        }

        // POST: Admin/House/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_House tbl_House = db.tbl_House.Find(id);
            db.tbl_House.Remove(tbl_House);
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
