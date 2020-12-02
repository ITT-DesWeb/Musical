using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Musical.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musical.Web.Clase
{
    public class Utility
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();

        public static void CheckRoles(string rol)
        {
            var role = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if (!role.RoleExists(rol))
            {
                role.Create(new IdentityRole(rol));
            }
        }

        internal static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("superuser@mail.com");
            if (user==null)
            {
                CreateSuperUser("superuser@mail.com","Admin_123",null,"Administrator");
            }
        }

        private static void CreateSuperUser(string email, string password, string phone, string rol)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //Aqui estamos creando un objeto
            var user = new ApplicationUser()
            {
                UserName=email,
                Email=email,
                PhoneNumber=phone
            };
            //Crea al usuairo
            userManager.Create(user,password);
            //agregarle un rol
            userManager.AddToRole(user.Id,rol);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}