using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
    public class mOrder
    {
        public int order_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> ad_id { get; set; }
        public Nullable<int> order_count { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public Nullable<int> order_status { get; set; }
        public string trans_id { get; set; }
    }
}