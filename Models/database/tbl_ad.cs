//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jarchim.Models.database
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_ad
    {
        public long ad_id { get; set; }
        public string ad_name { get; set; }
        public string ad_price { get; set; }
        public Nullable<long> copen_id { get; set; }
        public string ad_exp_one { get; set; }
        public Nullable<System.DateTime> ad_from_date { get; set; }
        public Nullable<int> ad_visit { get; set; }
        public Nullable<int> ad_like { get; set; }
        public Nullable<int> ad_dislike { get; set; }
        public Nullable<int> user_id { get; set; }
        public string ad_exp_two { get; set; }
        public string ad_summery { get; set; }
        public Nullable<int> ad_buy_count { get; set; }
        public Nullable<int> ad_city { get; set; }
        public int ad_cat { get; set; }
        public string ad_exp_three { get; set; }
        public Nullable<System.DateTime> ad_to_date { get; set; }
        public Nullable<int> ad_save_per { get; set; }
    
        public virtual tbl_ad tbl_ad1 { get; set; }
        public virtual tbl_ad tbl_ad2 { get; set; }
        public virtual tbl_ad tbl_ad11 { get; set; }
        public virtual tbl_ad tbl_ad3 { get; set; }
    }
}