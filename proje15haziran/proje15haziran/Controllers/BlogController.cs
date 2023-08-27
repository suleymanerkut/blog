using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using proje15haziran.Models;

namespace proje15haziran.Controllers
{
    public class BlogController : Controller
    {
        private GoblinContext db = new GoblinContext();


        public ActionResult list(int? id, string AnahtarKelime)
        {
            var bloglar = db.Bloglar
         .Where(i => i.Onay == true)
         .Select(i => new BlogModel()
         {
             Id = i.Id,
             Baslik = i.Baslik,
             Aciklama = i.Aciklama,
             Tarih = i.Tarih,
             Anasayfa = i.Anasayfa,
             Onay = i.Onay,
             Icerik = i.Icerik,
             Resim = i.Resim,
             CategoryID = i.CategoryId

         }).AsQueryable();

            if (string.IsNullOrEmpty("AnahtarKelime") == false)
            {
                bloglar = bloglar.Where(i => i.Baslik.Contains(AnahtarKelime)
                || i.Aciklama.Contains(AnahtarKelime)
                || i.Baslik.Contains(AnahtarKelime)
                || i.Icerik.Contains(AnahtarKelime));
            }

            if (id != null)
            {
                bloglar = bloglar.Where(i => i.CategoryID == id);
            }



            return View(bloglar.ToList());
        }

        public ActionResult search(string AnahtarKelime)
        {
            var bloglar = db.Bloglar
         .Where(i => i.Onay == true)
         .Select(i => new BlogModel()
         {
             Id = i.Id,
             Baslik = i.Baslik,
             Aciklama = i.Aciklama,
             Tarih = i.Tarih,
             Anasayfa = i.Anasayfa,
             Onay = i.Onay,
             Icerik = i.Icerik,
             Resim = i.Resim,
             CategoryID = i.CategoryId

         }).AsQueryable();

            if (string.IsNullOrEmpty("AnahtarKelime") == false)
            {
                bloglar = bloglar.Where(i => i.Baslik.Contains(AnahtarKelime)
                || i.Aciklama.Contains(AnahtarKelime)
                || i.Baslik.Contains(AnahtarKelime)
                || i.Icerik.Contains(AnahtarKelime));
            }
            return View(bloglar.ToList());
        }

       

        // GET: Blog
        public ActionResult Index()
        {
            var bloglar = db.Bloglar.Include(b => b.Category).OrderByDescending(i => i.Tarih);
            return View(bloglar.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
          

            Blog blog = db.Bloglar.Find(id);

            


            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "CategoryName");
            return View();
        }

        // POST: Blog/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Baslik,Aciklama,Resim,Icerik,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.Tarih = DateTime.Now;
                blog.Onay = true;
                blog.Anasayfa = true;
                db.Bloglar.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Baslik,Aciklama,Resim,Icerik,Onay,Anasayfa,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Bloglar.Find(blog.Id);
                if (entity != null)
                {
                    entity.Baslik = blog.Baslik;
                    entity.Aciklama = blog.Aciklama;
                    entity.Resim = blog.Resim;
                    entity.Icerik = blog.Icerik;
                    entity.Onay = blog.Onay;
                    entity.Anasayfa = blog.Anasayfa;
                    entity.CategoryId = blog.CategoryId;

                    db.SaveChanges();

                    TempData["Blog"] = entity;
                    return RedirectToAction("Index");
                }

            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Bloglar.Find(id);
            db.Bloglar.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult Commentlist(int? id)
        {


            var comments = db.Comments
         .Where(c => c.blogid == id)
         .Select(c => new CommentsModel()
         {
             Id = c.Id,
             username = c.username,
             blogid = c.blogid,
             comment = c.comment,
             date = c.date,
             onay = c.onay,

         }).AsQueryable();


            return PartialView(comments.ToList());
        }

        [HttpGet]
        public PartialViewResult Addcomment(int id)
        {
            ViewBag.Id = id;
            return PartialView();
        }


        [HttpPost]
        public PartialViewResult Addcomment (Comments c,int id)
        {
            ViewBag.Id = id;
            c.blogid=ViewBag.Id;
            c.date = DateTime.Now;
            c.onay = true;
            db.Comments.Add(c);
            db.SaveChanges();
            return PartialView();
        }

        public ActionResult DeleteComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCommentConfirmed(int id)
        {
            Comments comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CommentEdit(int? id)
        {          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.blogid = db.Comments.Find(comment.blogid);
            return View(comment);
        }

        // POST: Blog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CommentEdit([Bind(Include = "Id,username,comment,date,onay,blogid")] Comments comment)
        {
            
            if (ModelState.IsValid)
            {
                var entity = db.Comments.Find(comment.Id);
                if (entity != null)
                {
                    entity.username = comment.username;
                    entity.comment = comment.comment;
                    entity.date = comment.date;                  
                    entity.onay = comment.onay;
                    entity.blogid = comment.blogid;


                    db.SaveChanges();

                    TempData["Comments"] = entity;
                    return RedirectToAction("Index");
                }

            }
            //ViewBag.id = db.Comments.Find(comment.Id);
            return View(comment);
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
