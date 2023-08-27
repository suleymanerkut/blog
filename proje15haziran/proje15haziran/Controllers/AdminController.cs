using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using proje15haziran.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proje15haziran.Controllers
{
    public class AdminController : Controller
    {

        private UserManager<ApplicationUser> UserManager;

        public AdminController()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityDataContext()));
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        public ActionResult Panel()
        {
            return View();
        }
    }
}