using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proje15haziran.Models
{
    public class CommentsModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string comment { get; set; }
        public DateTime date { get; set; }
        public bool onay { get; set; }
        //public int like { get; set; }
        //public int Dislike { get; set; }
        public int blogid { get; set; }
    }
}