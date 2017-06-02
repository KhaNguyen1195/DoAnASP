using System;
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
    }
}