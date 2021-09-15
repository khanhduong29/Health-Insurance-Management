using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Health_Insurance_Management.Models;
using Health_Insurance_Management.Models.Enum;

namespace Health_Insurance_Management.Controllers
{
    public class HospitalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hospital
        public ActionResult Index()
        {
            return View(db.HospitalInfos.ToList());
        }

        // GET: Hospital/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalInfo hospitalInfo = db.HospitalInfos.Find(id);
            if (hospitalInfo == null)
            {
                return HttpNotFound();
            }
            return View(hospitalInfo);
        }

        // GET: Hospital/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospital/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HospitalId,HospitalName,HospitalPhone,HospitalAddress,HospitalURL,Status,CreatedDate,UpdatedDate")] HospitalInfo hospitalInfo)
        {
            if (ModelState.IsValid)
            {
                hospitalInfo.Status = Status.Active;
                hospitalInfo.CreatedDate = DateTime.Now;
                hospitalInfo.UpdatedDate = DateTime.Now;
                db.HospitalInfos.Add(hospitalInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospitalInfo);
        }

        // GET: Hospital/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalInfo hospitalInfo = db.HospitalInfos.Find(id);
            if (hospitalInfo == null)
            {
                return HttpNotFound();
            }
            return View(hospitalInfo);
        }

        // POST: Hospital/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HospitalId,HospitalName,HospitalPhone,HospitalAddress,HospitalURL,Status,CreatedDate,UpdatedDate")] HospitalInfo hospitalInfo)
        {
            if (ModelState.IsValid)
            {
                hospitalInfo.UpdatedDate = DateTime.Now;
                db.Entry(hospitalInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospitalInfo);
        }

        // GET: Hospital/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalInfo hospitalInfo = db.HospitalInfos.Find(id);
            if (hospitalInfo == null)
            {
                return HttpNotFound();
            }
            return View(hospitalInfo);
        }

        // POST: Hospital/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HospitalInfo hospitalInfo = db.HospitalInfos.Find(id);
            db.HospitalInfos.Remove(hospitalInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("ChangeStatus")]
        public ActionResult ChangStatus(int id)
        {
            var hospital = db.HospitalInfos.Find(id);

            hospital.Status = hospital.Status == Status.Active ? Status.Deactive : Status.Active;
            db.Entry(hospital).State = EntityState.Modified;
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
