using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
    public class mImgAd
    {
        public long img_id { get; set; }
        public Nullable<long> ad_id { get; set; }
        public string ad_img { get; set; }
        public string ad_img_title { get; set; }
    }
}