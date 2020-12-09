using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Musical.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Musical.Web.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class RolesController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        //metodo get add
         public ActionResult AddRoles(string id)
        {
            var user = db.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult AddRoles(UserViewModels uvm)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var userRole = userManager.GetRoles(uvm.UserId);
            if (userRole.Count>0)
            {
                userManager.RemoveFromRoles(uvm.UserId,userRole.ToArray());
                userManager.AddToRole(uvm.UserId,uvm.RolName);
            }
            else
            {
                userManager.AddToRole(uvm.UserId,uvm.RolName);
            }

            return RedirectToAction("Index");
        }
    }
}