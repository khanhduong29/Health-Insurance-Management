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
    public class PoliciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Policies
        public async Task<ActionResult> Index()
        {
            var policies = db.Policies.Include(p => p.Company);
            return View(await policies.ToListAsync());
        }

        // GET: Policies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = await db.Policies.FindAsync(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // GET: Policies/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.CompanyDetails, "CompanyId", "CompanyName");
            return View();
        }

        // POST: Policies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PolicyId,CompanyId,PolicyName,PolicyDescription,Amount,Emi,MedicalId,Status,CreatedDate,UpdatedDate")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Policies.Add(policy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.CompanyDetails, "CompanyId", "CompanyName", policy.CompanyId);
            return View(policy);
        }

        // GET: Policies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = await db.Policies.FindAsync(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.CompanyDetails, "CompanyId", "CompanyName", policy.CompanyId);
            return View(policy);
        }

        // POST: Policies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PolicyId,CompanyId,PolicyName,PolicyDescription,Amount,Emi,MedicalId,Status,CreatedDate,UpdatedDate")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.CompanyDetails, "CompanyId", "CompanyName", policy.CompanyId);
            return View(policy);
        }

        // GET: Policies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = await db.Policies.FindAsync(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Policy policy = await db.Policies.FindAsync(id);
            db.Policies.Remove(policy);
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
