using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
    public class mShoppingCart
    {
        public int cart_id { get; set; }
        public Nullable<double> cookie_id { get; set; }
        public Nullable<int> ad_id { get; set; }
        public Nullable<int> cart_count { get; set; }
        public Nullable<System.DateTime> cart_date { get; set; }
        public Nullable<bool> cart_payment { get; set; }
        public Nullable<int> cart_id_get { get; set; }
    }
}