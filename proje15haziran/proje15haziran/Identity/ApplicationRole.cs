﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proje15haziran.Identity
{
    public class ApplicationRole:IdentityRole
    {
        public string Description { get; set; }
    }
}