using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using proje15haziran.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;

namespace proje15haziran.Models
{
    public class GoblinInitializer : DropCreateDatabaseIfModelChanges<GoblinContext>
    {
        protected override void Seed(GoblinContext context)
        {
            List<Category> Kategoriler = new List<Category>()
            {
                new Category() {CategoryName="Dizi"},
                new Category() {CategoryName="Oyun"},
                new Category() {CategoryName="Film"},
                new Category() {CategoryName="Kitap"},
                new Category() {CategoryName="Müzik"},
                new Category() {CategoryName="Teknoloji"}
            };

            foreach (var item in Kategoriler)
            { context.Kategoriler.Add(item); }
            context.SaveChanges();

            List<Blog> Bloglar = new List<Blog>()
            {
                new Blog() {Baslik="Mandolorian", Aciklama="Grogu",Icerik="Grogu neden hala dizide bilen var mı?", Tarih=DateTime.Now.AddDays(-2),Anasayfa=true,Onay=true,Resim="https://helios-i.mashable.com/imagery/articles/07gzR51infAlHLrbHQnWR9e/hero-image.fill.size_1248x702.v1679496551.jpg",CategoryId=1},
                new Blog() {Baslik="Baldur's Gate 3", Aciklama="Bu yaz tam sürümü çıkış yapacak gibi",Icerik="Zarınız bol olsun 20 gelsin hep",Tarih=DateTime.Now.AddDays(-10),Anasayfa=true,Onay=true,Resim="https://cdn.wccftech.com/wp-content/uploads/2022/03/Baldurs-Gate-3-Header-scaled.jpg",CategoryId=2},
                new Blog() {Baslik="Spider-Man Across The Spiderverse ", Aciklama="Fazlasıyla güzel bir filmdi",Icerik="Fazlasıyla güzel bir filmdi ne eksik ne fazla çizimler muhteşem hale gelmiş",Tarih=DateTime.Now.AddDays(-13),Anasayfa=true,Onay=true,Resim="https://www.dexerto.com/cdn-cgi/image/width=640,quality=75,format=auto/https://editors.dexerto.com/wp-content/uploads/2023/05/25/spider-verse-2-reviews.jpg",CategoryId=3},
                new Blog() {Baslik="Drizzt ", Aciklama="Dirizt dürdane çok iyi rpg kitap serisi",Icerik="Sürükleyici bir seri Dnd evrenine hakim olup okumak daha da zevkli",Tarih=DateTime.Now.AddDays(-1),Anasayfa=true,Onay=true,Resim="https://i0.wp.com/tlbranson.com/wp-content/uploads/2018/12/The-Dark-Elf-Trilogy-Legend-of-Drizzt-Reading-Order-1024x561.jpg",CategoryId=4},
                new Blog() {Baslik="Pink Floyd", Aciklama="70ler iyiydi aslında",Icerik="Pink floydu severiz iyi grup",Tarih=DateTime.Now.AddDays(-35),Anasayfa=true,Onay=true,Resim="https://images.theconversation.com/files/512871/original/file-20230301-26-ryosag.jpg?ixlib=rb-1.1.0&rect=44%2C1211%2C5835%2C2917&q=45&auto=format&w=1356&h=668&fit=crop",CategoryId=5},
                new Blog() {Baslik="Rtx 5090", Aciklama="Nasıl güçlü mü",Icerik="Pink floydu severiz iyi grup",Tarih=DateTime.Now.AddDays(-35),Anasayfa=true,Onay=true,Resim="https://www.nvidia.com/content/dam/en-zz/Solutions/geforce/ada/rtx-4090/geforce-ada-4090-web-og-1200x630.jpg",CategoryId=5},

            };

            foreach (var item in Bloglar)
            { context.Bloglar.Add(item); }
            context.SaveChanges();

            List<Comments> comments = new List<Comments>()
            {
                new Comments() { blogid=1,comment="Bu bir yorumdur mando iyi",username="Yorumcu Başı",date=DateTime.Now,onay=true},
                new Comments() { blogid=2,comment="Bu bir yorumdur baldur iyi",username="Yorumcu Başı",date=DateTime.Now,onay=true},
                new Comments() { blogid=3,comment="Bu bir yorumdur spider iyi",username="Yorumcu Başı",date=DateTime.Now,onay=true},
                new Comments() { blogid=4,comment="Bu bir yorumdur drizzt iyi",username="Yorumcu Başı",date=DateTime.Now,onay=true},
                new Comments() { blogid=5,comment="Bu bir yorumdur Pink Floyd iyi",username="Yorumcu Başı",date=DateTime.Now,onay=true},
                new Comments() { blogid=6,comment="Bu bir yorumdur 5090 iyi",username="Yorumcu Başı",date=DateTime.Now,onay=true}
            };
            foreach (var item in comments)
            { context.Comments.Add(item); }
            context.SaveChanges();

            base.Seed(context);
        }
    }

}