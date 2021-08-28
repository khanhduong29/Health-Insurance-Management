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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.GetPolicy);
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "PolicyName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeId,PolicyId,EmployeeName,Designation,JoinDate,Salary,EmployeeAddress,EmployeePhone,Status,CreatedDate,UpdatedDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Status = Status.Active;
                employee.CreatedDate = DateTime.Now;
                db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "PolicyName", employee.PolicyId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "PolicyName", employee.PolicyId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeId,PolicyId,EmployeeName,Designation,JoinDate,Salary,EmployeeAddress,EmployeePhone,Status,CreatedDate,UpdatedDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.UpdatedDate = DateTime.Now;
                
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "PolicyName", employee.PolicyId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("ChangeStatus")]
        public async Task<ActionResult> ChangStatus(int id)
        {
            var employee = await db.Employees.FindAsync(id);

            employee.Status = employee.Status == Status.Active ? Status.Deactive : Status.Active;
            db.Entry(employee).State = EntityState.Modified;
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
