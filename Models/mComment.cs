using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.Models
{
    public class mComment
    {
        public int comment_id { get; set; }
        public Nullable<int> ad_id { get; set; }
        public Nullable<int> top_id { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
        public string user_text { get; set; }
        public string user_ip_addr { get; set; }
  public Nullable<System.DateTime> comment_date { get; set; }
  public Nullable<bool> c_confirm { get; set; }
        public Nullable<bool> c_read { get; set; }
        public Nullable<int> c_like { get; set; }
        public Nullable<int> c_dislike { get; set; }
        public List<mComment> aComment;
    }
}