using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
    public class mAbout
    {
        public int about_us_id { get; set; }
        public string about_us_img { get; set; }
        public string about_us_exp_one { get; set; }
        public string about_us_exp_two { get; set; }
        public string about_us_title { get; set; }
        public string about_us_img_alt { get; set; }
        public Nullable<int> about_us_type { get; set; }
        public string about_exp_three { get; set; }
        public HttpPostedFileBase img_file { get; set; }
    }
}