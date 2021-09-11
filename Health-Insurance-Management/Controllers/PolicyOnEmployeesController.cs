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
using Health_Insurance_Management.Models.Enum;

namespace Health_Insurance_Management.Controllers
{
    public class PolicyOnEmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PolicyOnEmployees
        public async Task<ActionResult> Index()
        {
            var policyOnEmployees = db.PolicyOnEmployees.Include(p => p.Employee).Include(p => p.Policy);
            return View(await policyOnEmployees.ToListAsync());
        }

        // GET: PolicyOnEmployees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyOnEmployee policyOnEmployee = await db.PolicyOnEmployees.FindAsync(id);
            if (policyOnEmployee == null)
            {
                return HttpNotFound();
            }
            return View(policyOnEmployee);
        }

        // GET: PolicyOnEmployees/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "PolicyName");
            return View();
        }

        // POST: PolicyOnEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,EmployeeId,PolicyId,StartDate,EndDate,Status,CreatedDate,UpdatedDate")] PolicyOnEmployee policyOnEmployee)
        {
            if (ModelState.IsValid)
            {
                policyOnEmployee.CreatedDate = DateTime.Now;
                db.PolicyOnEmployees.Add(policyOnEmployee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", policyOnEmployee.EmployeeId);
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "PolicyName", policyOnEmployee.PolicyId);
            return View(policyOnEmployee);
        }

        // GET: PolicyOnEmployees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyOnEmployee policyOnEmployee = await db.PolicyOnEmployees.FindAsync(id);
            if (policyOnEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", policyOnEmployee.EmployeeId);
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "PolicyName", policyOnEmployee.PolicyId);
            return View(policyOnEmployee);
        }

        // POST: PolicyOnEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,EmployeeId,PolicyId,StartDate,EndDate,Status,CreatedDate,UpdatedDate")] PolicyOnEmployee policyOnEmployee)
        {
            if (ModelState.IsValid)
            {
                policyOnEmployee.UpdatedDate = DateTime.Now;
                db.Entry(policyOnEmployee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", policyOnEmployee.EmployeeId);
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "PolicyName", policyOnEmployee.PolicyId);
            return View(policyOnEmployee);
        }

        // GET: PolicyOnEmployees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyOnEmployee policyOnEmployee = await db.PolicyOnEmployees.FindAsync(id);
            if (policyOnEmployee == null)
            {
                return HttpNotFound();
            }
            return View(policyOnEmployee);
        }

        // POST: PolicyOnEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PolicyOnEmployee policyOnEmployee = await db.PolicyOnEmployees.FindAsync(id);
            db.PolicyOnEmployees.Remove(policyOnEmployee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("ChangeStatus")]
        public async Task<ActionResult> ChangStatus(int id)
        {
            var policyOnEmployee = await db.PolicyOnEmployees.FindAsync(id);

            policyOnEmployee.Status = policyOnEmployee.Status == Status.Active ? Status.Deactive : Status.Active;
            db.Entry(policyOnEmployee).State = EntityState.Modified;
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
