using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jarchim.Models.database;

namespace Jarchim.da
{
    public class daLogin
    {
        JarchimDb Db = new JarchimDb();
        public bool CheckLogin(string UserEmail, string Password)
        {
            int vLogin = (from a in Db.tbl_users
                          where a.user_email.Equals(UserEmail) && a.user_pass.Equals(Password)
                          select a).Count();
            return Convert.ToBoolean(vLogin);
        }
    }
}