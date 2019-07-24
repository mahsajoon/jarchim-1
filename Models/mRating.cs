using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
 public class mRating
 {
  public int id_rat { get; set; }
  public Nullable<long> ad_id { get; set; }
  public Nullable<int> user_id { get; set; }
  public Nullable<decimal> star_count { get; set; }
 }
}