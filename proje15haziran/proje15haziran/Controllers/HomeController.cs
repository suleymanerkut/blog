using proje15haziran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace proje15haziran.Controllers
{

    public class HomeController : Controller
    {
        private GoblinContext context = new GoblinContext();
        // GET: Home

        public ActionResult Index()
        {
            var bloglar = context.Bloglar
                .Where(i => i.Onay == true && i.Anasayfa == true)
                .Select(i => new BlogModel()
                {
                    Id = i.Id,
                    Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                    Aciklama = i.Aciklama.Length > 100 ? i.Baslik.Substring(0, 100) + "..." :i.Aciklama,
                    Tarih = i.Tarih,
                    Anasayfa = i.Anasayfa,
                    Onay = i.Onay,
                    Resim = i.Resim
                });
            return View(bloglar.ToList().OrderByDescending(i => i.Tarih));

            }
    }
}
