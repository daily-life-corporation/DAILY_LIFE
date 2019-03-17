using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAILY_LIFE.Models;

namespace DAILY_LIFE.Controllers
{
    public class UserTypeController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: UserType
        public ActionResult Index()
        {
            return View(db.tbl_user_type.ToList());
        }

        // GET: UserType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user_type tbl_user_type = db.tbl_user_type.Find(id);
            if (tbl_user_type == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user_type);
        }

        // GET: UserType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_type_id,user_type_name")] tbl_user_type tbl_user_type)
        {
            if (ModelState.IsValid)
            {
                db.tbl_user_type.Add(tbl_user_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_user_type);
        }

        // GET: UserType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user_type tbl_user_type = db.tbl_user_type.Find(id);
            if (tbl_user_type == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user_type);
        }

        // POST: UserType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_type_id,user_type_name")] tbl_user_type tbl_user_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_user_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_user_type);
        }

        // GET: UserType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user_type tbl_user_type = db.tbl_user_type.Find(id);
            if (tbl_user_type == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user_type);
        }

        // POST: UserType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_user_type tbl_user_type = db.tbl_user_type.Find(id);
            db.tbl_user_type.Remove(tbl_user_type);
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
