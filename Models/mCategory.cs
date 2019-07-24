using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
    public class mCategory
    {
        public int cat_id { get; set; }
        public string cat_title { get; set; }
        public Nullable<int> top_id { get; set; }
        public string cat_href { get; set; }
        public string cat_baner_img { get; set; }
        public string cat_icon_img { get; set; }
        public HttpPostedFileBase img_file1 { get; set; }
        public HttpPostedFileBase img_file2 { get; set; }
    }
}