using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
 public class mAd
 {
  public long ad_id { get; set; }
  public string ad_name { get; set; }
  public string ad_price { get; set; }
  public Nullable<long> copen_id { get; set; }
  public string ad_exp_one { get; set; }
  public Nullable<System.DateTime> ad_from_date { get; set; }
  public Nullable<System.DateTime> ad_to_date { get; set; }
  public string ad_from_date_str { get; set; }
  public string ad_to_time_str { get; set; }
  public string ad_from_time_str { get; set; }
  public string ad_to_date_str { get; set; }
  public Nullable<int> ad_visit { get; set; }
  public Nullable<int> ad_like { get; set; }
  public Nullable<int> ad_dislike { get; set; }
  public Nullable<int> user_id { get; set; }
  public Nullable<long> img_id { get; set; }
  public string ad_exp_two { get; set; }
  public string ad_exp_three { get; set; }
  public string ad_summery { get; set; }
  public string ad_img { get; set; }
  public string cat_name { get; set; }
  public string timer_string { get; set; }
  public Nullable<int> ad_buy_count { get; set; }
  public Nullable<int> ad_save_per { get; set; }
  public int ad_cat { get; set; }
  public Nullable<int> ad_city { get; set; }
  public Nullable<int> ad_top_id { get; set; }
  public Nullable<int> is_search { get; set; }
  public HttpPostedFileBase img_file { get; set; }
  public List<mAdImg> aAdImg { get; set; }
        public decimal rating_avg { get; set; }

    }
}