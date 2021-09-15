using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Health_Insurance_Management.Models;

namespace Health_Insurance_Management.Controllers
{
    public class HospitalInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HospitalInfoes
        public async Task<ActionResult> Index()
        {
            return View(await db.HospitalInfos.ToListAsync());
        }

        // GET: HospitalInfoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalInfo hospitalInfo = await db.HospitalInfos.FindAsync(id);
            if (hospitalInfo == null)
            {
                return HttpNotFound();
            }
            return View(hospitalInfo);
        }

        // GET: HospitalInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HospitalInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HospitalId,HospitalName,HospitalPhone,HospitalAddress,HospitalURL,Status,CreatedDate,UpdatedDate")] HospitalInfo hospitalInfo)
        {
            if (ModelState.IsValid)
            {
                db.HospitalInfos.Add(hospitalInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hospitalInfo);
        }

        // GET: HospitalInfoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalInfo hospitalInfo = await db.HospitalInfos.FindAsync(id);
            if (hospitalInfo == null)
            {
                return HttpNotFound();
            }
            return View(hospitalInfo);
        }

        // POST: HospitalInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HospitalId,HospitalName,HospitalPhone,HospitalAddress,HospitalURL,Status,CreatedDate,UpdatedDate")] HospitalInfo hospitalInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospitalInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hospitalInfo);
        }

        // GET: HospitalInfoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalInfo hospitalInfo = await db.HospitalInfos.FindAsync(id);
            if (hospitalInfo == null)
            {
                return HttpNotFound();
            }
            return View(hospitalInfo);
        }

        // POST: HospitalInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HospitalInfo hospitalInfo = await db.HospitalInfos.FindAsync(id);
            db.HospitalInfos.Remove(hospitalInfo);
            await db.SaveChangesAsync();
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
