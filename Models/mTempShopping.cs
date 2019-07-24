using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
    public class mTempShopping
    {
        public long temp_id { get; set; }
        public Nullable<int> cart_id_get { get; set; }
        public Nullable<int> ad_id { get; set; }
        public Nullable<int> temp_count { get; set; }
        public Nullable<System.DateTime> temp_date { get; set; }
        public Nullable<int> user_id { get; set; }
        public string trans_id { get; set; }
    }
}