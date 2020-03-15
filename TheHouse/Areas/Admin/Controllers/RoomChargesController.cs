using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheHouse.Models;

namespace TheHouse.Areas.Admin.Controllers
{
    public class RoomChargesController : Controller
    {
        private TheHouseEntities db = new TheHouseEntities();

        // GET: Admin/Controller to assign charges to rooms..
        public ActionResult Index()
        {
            var tbl_RoomCharges = db.tbl_RoomCharges.Include(t => t.tbl_Category).Include(t => t.tbl_Type);
            return View(tbl_RoomCharges.ToList());
        }

        // GET: Admin/RoomCharges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RoomCharges tbl_RoomCharges = db.tbl_RoomCharges.Find(id);
            if (tbl_RoomCharges == null)
            {
                return HttpNotFound();
            }
            return View(tbl_RoomCharges);
        }

        // GET: Admin/RoomCharges/Create
        public ActionResult Create()
        {
            ViewBag.FK_CatID = new SelectList(db.tbl_Category, "Cat_Id", "Cat_Name");
            ViewBag.FK_TypeID = new SelectList(db.tbl_Type, "Type_Id", "Type_Name");
            return View();
        }

        // POST: Admin/RoomCharges/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_RoomCharges tbl_RoomCharges)
        {
            if (ModelState.IsValid)
            {
                db.tbl_RoomCharges.Add(tbl_RoomCharges);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_CatID = new SelectList(db.tbl_Category, "Cat_Id", "Cat_Name", tbl_RoomCharges.FK_CatID);
            ViewBag.FK_TypeID = new SelectList(db.tbl_Type, "Type_Id", "Type_Name", tbl_RoomCharges.FK_TypeID);
            return View(tbl_RoomCharges);
        }

        // GET: Admin/RoomCharges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RoomCharges tbl_RoomCharges = db.tbl_RoomCharges.Find(id);
            if (tbl_RoomCharges == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_CatID = new SelectList(db.tbl_Category, "Cat_Id", "Cat_Name", tbl_RoomCharges.FK_CatID);
            ViewBag.FK_TypeID = new SelectList(db.tbl_Type, "Type_Id", "Type_Name", tbl_RoomCharges.FK_TypeID);
            return View(tbl_RoomCharges);
        }

        // POST: Admin/RoomCharges/Edit/5
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_RoomCharges tbl_RoomCharges)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_RoomCharges).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_CatID = new SelectList(db.tbl_Category, "Cat_Id", "Cat_Name", tbl_RoomCharges.FK_CatID);
            ViewBag.FK_TypeID = new SelectList(db.tbl_Type, "Type_Id", "Type_Name", tbl_RoomCharges.FK_TypeID);
            return View(tbl_RoomCharges);
        }

        // GET: Admin/RoomCharges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RoomCharges tbl_RoomCharges = db.tbl_RoomCharges.Find(id);
            if (tbl_RoomCharges == null)
            {
                return HttpNotFound();
            }
            return View(tbl_RoomCharges);
        }

        // POST: Admin/RoomCharges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_RoomCharges tbl_RoomCharges = db.tbl_RoomCharges.Find(id);
            db.tbl_RoomCharges.Remove(tbl_RoomCharges);
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
