using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using proje15haziran.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static proje15haziran.Models.UserModel;

namespace proje15haziran.Controllers
{
   // [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;

        public AccountController()
        {
            UserManager=new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityDataContext()));
            UserManager.PasswordValidator = new PasswordValidator()
            {
                
                RequiredLength = 6                               
            };

            UserManager.UserValidator = new UserValidator<ApplicationUser>(UserManager)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = false
            };

        }


        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "Hob erişim hakkın yok birader" });
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model,string returnUrl)
        {

            if (ModelState.IsValid)
            {

            

            var user=UserManager.Find(model.Username,model.Password);
            if (user==null)
            {
                ModelState.AddModelError("", "Yanlış Kullanıcı adı ya da Şifre");

            }
            else
            {
                var authManager=HttpContext.GetOwinContext().Authentication;
                var identitiy = UserManager.CreateIdentity(user, "ApplicationCookie");
                var authProperties = new AuthenticationProperties()
                {
                 IsPersistent = true,
                };

                authManager.SignOut(authProperties);
                authManager.SignIn(authProperties,identitiy);

                return Redirect(string.IsNullOrEmpty(returnUrl)?"/":returnUrl);
            }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user=new ApplicationUser();
                user.Email = model.Email;
                user.UserName = model.Username;
                
                
               
                var result=UserManager.Create(user,model.Password);
                if (result.Succeeded)
                {
 

                    UserManager.AddToRole(user.Id, "User");
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error);
                    }
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Login");
        }
    }
}