using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDWITHEF.Models;

namespace CRUDWITHEF.Controllers
{
    public class employee_masterController : Controller
    {
        private CRUDWITHEFEntities db = new CRUDWITHEFEntities();

        // GET: employee_master
        public ActionResult Index()
        {
            return View(db.employee_master.ToList());
        }

        // GET: employee_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_master employee_master = db.employee_master.Find(id);
            if (employee_master == null)
            {
                return HttpNotFound();
            }
            return View(employee_master);
        }

        // GET: employee_master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employee_master/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,empcode,empname,designation,salary")] employee_master employee_master)
        {
            if (ModelState.IsValid)
            {
                db.employee_master.Add(employee_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee_master);
        }

        // GET: employee_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_master employee_master = db.employee_master.Find(id);
            if (employee_master == null)
            {
                return HttpNotFound();
            }
            return View(employee_master);
        }

        // POST: employee_master/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,empcode,empname,designation,salary")] employee_master employee_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee_master);
        }

        // GET: employee_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee_master employee_master = db.employee_master.Find(id);
            if (employee_master == null)
            {
                return HttpNotFound();
            }
            return View(employee_master);
        }

        // POST: employee_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee_master employee_master = db.employee_master.Find(id);
            db.employee_master.Remove(employee_master);
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
