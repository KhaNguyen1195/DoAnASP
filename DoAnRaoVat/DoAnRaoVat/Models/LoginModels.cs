using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnRaoVat.Models
{
    [MetadataType(typeof(LoginValidation))]
    public class LoginModels
    {
      
        public string UserName { set; get; }
        
        public string Password { set; get; }

        public bool RemmemberMe { set; get; }
    }
}