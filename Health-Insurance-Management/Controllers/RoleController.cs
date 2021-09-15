using Health_Insurance_Management.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Health_Insurance_Management.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        private ApplicationRoleManager _roleManager;
        public RoleController()
        {
        }

        public RoleController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
    
            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {

                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public ActionResult Index()
        {
            List<RoleViewModel> lst = new List<RoleViewModel>();
            foreach (var role in RoleManager.Roles)
                lst.Add(new RoleViewModel(role));
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            var role = new ApplicationRole() { Name = model.Name };
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
    }
}