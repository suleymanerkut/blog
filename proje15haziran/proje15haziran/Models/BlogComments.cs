using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proje15haziran.Models
{
    public class BlogComments
    {
        public IEnumerable<Blog> value1 { get; set; }
        public IEnumerable<Comments> value2 { get; set; }
    }
}