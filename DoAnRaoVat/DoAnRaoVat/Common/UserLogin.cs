﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnRaoVat
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { set; get; }
        public string Phone { set; get; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string UserGroupID { get; set; }
    }
}