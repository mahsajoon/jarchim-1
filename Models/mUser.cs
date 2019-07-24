﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
    public class mUser
    {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string user_email { get; set; }
        public string user_pass { get; set; }
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