using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnRaoVat.Models
{

    [MetadataType(typeof(RegisterValidation))]
    public class RegisterModels
    {
        
        public long ID { get; set; }

        public string UserGroupID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Email { get; set; }

        public string Phone { get; set; }

        public string CaptchaCode { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}