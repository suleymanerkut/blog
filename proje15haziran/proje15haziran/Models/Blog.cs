using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proje15haziran.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Kullanıcı { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public bool Onay { get; set; }
        public bool Anasayfa { get; set; }
        //public int userid { get; set; }
        //public int like { get; set; }
        //public int Dislike { get; set; }
    

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        //public UserModel user { get; set; }
        public ICollection<Comments> Comments { get; set; }



    }
}