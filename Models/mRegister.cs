using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jarchim.Models
{
    public class mRegister
    {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string user_email { get; set; }
        [Required(ErrorMessage = "UserName is Required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password =>> 3 to 100")]
        [RegularExpression(@"[a-z0-9A-Z]+", ErrorMessage = "Danger")]
        public string user_pass { get; set; }
        [Required(ErrorMessage = "User Name is Required")]
        [Remote("DupUserName","Home",HttpMethod ="POST",ErrorMessage ="This UserName Is Used")]
        [StringLength(100,MinimumLength =3,ErrorMessage ="UserName >> 3 to 100")]
        public string last_name { get; set; }
        public Nullable<System.DateTime> user_birthday { get; set; }
        public string user_mobile { get; set; }
        public string user_phone { get; set; }
        public string user_province { get; set; }
        public string user_city { get; set; }
        public string user_postal_code { get; set; }
        public string user_addr { get; set; }
        public string user_pic { get; set; }
        public Nullable<int> user_access { get; set; }
        public Nullable<System.DateTime> user_reg_date { get; set; }
        public Nullable<bool> user_is_sex { get; set; }
    }
}