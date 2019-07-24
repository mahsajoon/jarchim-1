using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
    public class mContact
    {
        public long contact_id { get; set; }
        public string contact_name { get; set; }
        public string contact_email { get; set; }
        public string contact_phone { get; set; }
        public string contact_text { get; set; }
        public Nullable<bool> contact_is_read { get; set; }
        public Nullable<System.DateTime> contact_date { get; set; }
    }
}