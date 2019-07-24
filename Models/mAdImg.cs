using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
    public class mAdImg
    {
        public long img_id { get; set; }
        public long ad_id { get; set; }
        public Nullable<int> ad_cat { get; set; }
        public Nullable<int> ad_city { get; set; }
        public string ad_img { get; set; }
        public string ad_img_title { get; set; }
        public HttpPostedFileBase img_file { get; set; }
  public string ad_img_alt { get; set; }
 }
}