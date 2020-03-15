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
    public class RoomsController : Controller
    {
        private TheHouseEntities db = new TheHouseEntities();

        // GET: Admin/Rooms
        public ActionResult Index()
        {
            var tbl_RoomsDetails = db.tbl_RoomsDetails.Include(t => t.tbl_Category).Include(t => t.tbl_House).Include(t => t.tbl_Type);
            return View(tbl_RoomsDetails.ToList());
        }

        // GET: Admin/Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RoomsDetails tbl_RoomsDetails = db.tbl_RoomsDetails.Find(id);
            if (tbl_RoomsDetails == null)
            {
                return HttpNotFound();
            }
            return View(tbl_RoomsDetails);
        }

        // GET: Admin/Rooms/Create
        public ActionResult Create()
        {
            ViewBag.FK_CateID = new SelectList(db.tbl_Category, "Cat_Id", "Cat_Name");
            ViewBag.FK_HouseID = new SelectList(db.tbl_House, "H_ID", "H_Name");
            ViewBag.FK_TypeID = new SelectList(db.tbl_Type, "Type_Id", "Type_Name");
            return View();
        }

        // POST: Admin/Rooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_RoomsDetails NewRoom , HttpPostedFileBase RoomImg)
        {
            if (ModelState.IsValid)
            {
                
                if (RoomImg!=null)
                {
                    string ext = Path.GetExtension(RoomImg.FileName);
                    if (ext.ToLower()==".jpeg" || ext.ToLower() == ".jpg" || ext.ToLower() == ".png")
                    {
                        var imgName = Path.GetFileName("Room" + Guid.NewGuid() + " " +ext);
                        string imgPath = Path.Combine(Server.MapPath("~/Content/RoomImages/"), imgName);
                        RoomImg.SaveAs(imgPath);
                        NewRoom.R_Image = imgName;
                        db.tbl_RoomsDetails.Add(NewRoom);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Error = "Invalid format!";
                    }
                }
                else
                {
                    ViewBag.Error = "Image file Problem!";
                }
              
            }

            ViewBag.FK_CateID = new SelectList(db.tbl_Category, "Cat_Id", "Cat_Name", NewRoom.FK_CateID);
            ViewBag.FK_HouseID = new SelectList(db.tbl_House, "H_ID", "H_Name", NewRoom.FK_HouseID);
            ViewBag.FK_TypeID = new SelectList(db.tbl_Type, "Type_Id", "Type_Name", NewRoom.FK_TypeID);
            return View(NewRoom);
        }

        // GET: Admin/Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RoomsDetails tbl_RoomsDetails = db.tbl_RoomsDetails.Find(id);
            if (tbl_RoomsDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_CateID = new SelectList(db.tbl_Category, "Cat_Id", "Cat_Name", tbl_RoomsDetails.FK_CateID);
            ViewBag.FK_HouseID = new SelectList(db.tbl_House, "H_ID", "H_Name", tbl_RoomsDetails.FK_HouseID);
            ViewBag.FK_TypeID = new SelectList(db.tbl_Type, "Type_Id", "Type_Name", tbl_RoomsDetails.FK_TypeID);
            return View(tbl_RoomsDetails);
        }

        // POST: Admin/Rooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_RoomsDetails Room,HttpPostedFileBase RoomImg)
        {
            try
            {
                if (RoomImg != null)
                {
                    var filePath = Server.MapPath("~/Content/HotelImg/" + Room.R_Image);
                    if (System.IO.File.Exists(filePath))
                    {
                        string ext = Path.GetExtension(RoomImg.FileName);
                        if (ext == ".jpg" || ext == "png" || ext == ".jpeg")
                        {
                            System.IO.File.Delete(filePath);

                            var imgName = Path.GetFileName("Room" + Guid.NewGuid() + " " + ext);
                            string imgPath = Path.Combine(Server.MapPath("~/Content/RoomImages/"), imgName);
                            RoomImg.SaveAs(imgPath);
                            Room.R_Image = imgName;
                            db.Entry(Room).State = System.Data.Entity.EntityState.Modified;
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
                        string ext = Path.GetExtension(RoomImg.FileName);
                        var imgName = Path.GetFileName("Room" + Guid.NewGuid() + " " + ext);
                        string imgPath = Path.Combine(Server.MapPath("~/Content/RoomImages/"), imgName);
                        RoomImg.SaveAs(imgPath);
                        Room.R_Image = imgName;
                        db.Entry(Room).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    Room.R_Image = Room.R_Image;
                    db.Entry(Room).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    db.Entry(tbl_RoomsDetails).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.FK_CateID = new SelectList(db.tbl_Category, "Cat_Id", "Cat_Name", tbl_RoomsDetails.FK_CateID);
            //ViewBag.FK_HouseID = new SelectList(db.tbl_House, "H_ID", "H_Name", tbl_RoomsDetails.FK_HouseID);
            //ViewBag.FK_TypeID = new SelectList(db.tbl_Type, "Type_Id", "Type_Name", tbl_RoomsDetails.FK_TypeID);
            //return View(tbl_RoomsDetails);
        }

        // GET: Admin/Rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RoomsDetails tbl_RoomsDetails = db.tbl_RoomsDetails.Find(id);
            if (tbl_RoomsDetails == null)
            {
                return HttpNotFound();
            }
            return View(tbl_RoomsDetails);
        }

        // POST: Admin/Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_RoomsDetails tbl_RoomsDetails = db.tbl_RoomsDetails.Find(id);
            db.tbl_RoomsDetails.Remove(tbl_RoomsDetails);
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
