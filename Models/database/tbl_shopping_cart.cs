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
    
    public partial class tbl_shopping_cart
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
