using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
    public class mCopen
    {
        public long copen_id { get; set; }
        public Nullable<long> ad_id { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
        public Nullable<double> copen_per { get; set; }
    }
}