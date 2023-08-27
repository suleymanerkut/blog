using proje15haziran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proje15haziran.Controllers
{
    public class CommentController:Controller
    {
        private GoblinContext db=new GoblinContext();

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
        public PartialViewResult Addcomment(Comments c, int id)
        {
            ViewBag.Id = id;
            c.blogid = ViewBag.Id;
            c.date = DateTime.Now;
            c.onay = true;
            db.Comments.Add(c);
            db.SaveChanges();
            return PartialView();
        }
    }
}