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
    public class TypeController : Controller
    {
        private TheHouseEntities db = new TheHouseEntities();

        // GET: Admin/Type
        public ActionResult Index()
        {
            var tbl_Type = db.tbl_Type.Include(t => t.tbl_Category);
            return View(tbl_Type.ToList());
        }

        // GET: Admin/Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Type tbl_Type = db.tbl_Type.Find(id);
            if (tbl_Type == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Type);
        }

        // GET: Admin/Type/Create
        public ActionResult Create()
        {
            ViewBag.FK_CateID = new SelectList(db.tbl_Category, "Cat_Id", "Cat_Name");
            return View();
        }

        // POST: Admin/Type/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_Type tbl_Type)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Type.Add(tbl_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_CateID = new SelectList(db.tbl_Category, "Cat_Id", "Cat_Name", tbl_Type.FK_CateID);
            return View(tbl_Type);
        }

        // GET: Admin/Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Type tbl_Type = db.tbl_Type.Find(id);
            if (tbl_Type == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_CateID = new SelectList(db.tbl_Category, "Cat_Id", "Cat_Name", tbl_Type.FK_CateID);
            return View(tbl_Type);
        }

        // POST: Admin/Type/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_Type tbl_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_CateID = new SelectList(db.tbl_Category, "Cat_Id", "Cat_Name", tbl_Type.FK_CateID);
            return View(tbl_Type);
        }

        // GET: Admin/Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Type tbl_Type = db.tbl_Type.Find(id);
            if (tbl_Type == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Type);
        }

        // POST: Admin/Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Type tbl_Type = db.tbl_Type.Find(id);
            db.tbl_Type.Remove(tbl_Type);
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
