using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using proje15haziran.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace proje15haziran.Models
{
    public class GoblinContext:DbContext
    {
        public GoblinContext():base("GoblinDataBase")
        {
            Database.SetInitializer(new GoblinInitializer());
        }
        public DbSet<Blog> Bloglar { get; set; }
        public DbSet<Category> Kategoriler { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}