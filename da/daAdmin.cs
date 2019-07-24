using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Jarchim.Models;
using Jarchim.Models.database;
namespace Jarchim.da
{
    public class daAdmin
    {
        static int RefNumber=100;
        JarchimDb Db = new JarchimDb();

        public List<mUser> fGetAdminusers()
        {
            var vUsers = (from a in Db.tbl_users
                          select new mUser
                          {
                              user_id = a.user_id,
                              user_email = a.user_email,
                              first_name = a.first_name,
                              last_name = a.last_name,
                              user_pass = a.user_pass
                          }).OrderByDescending(b => b.user_id);
            return vUsers.ToList();
        }

        public bool InsertUsers(mUser pUsers)
        {
            try
            {
                tbl_users u = new tbl_users();
                u.user_email = pUsers.user_email;
                u.first_name = pUsers.first_name;
                u.last_name = pUsers.last_name;
                u.user_pass = pUsers.user_pass;
                u.user_id = Interlocked.Increment(ref RefNumber);
                Db.tbl_users.Add(u);
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool checkAdminuserExists(string pEmail, long pId)
        {
            try
            {
                int vUser = (from a in Db.tbl_users
                             where a.user_id != pId && a.user_email.Equals(pEmail)
                             select a).Count();
                if (vUser > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

               return false;
            }
          
        }


        public mUser fGetUsers(mUser pAdminUsers)
        {
            try
            {
              
                var vUsers = (from a in Db.tbl_users
                              where a.user_id.Equals(pAdminUsers.user_id)
                                select new mUser
                                {
                                    user_id = a.user_id,
                                    user_email = a.user_email,
                                    first_name = a.first_name,
                                    last_name = a.last_name,
                                    user_pass = a.user_pass
                                }).FirstOrDefault();
                return vUsers;
            }
            catch (Exception)
            {
                return null;
            }
        }

        
       public bool fUpdateAdminuser(mUser pUsers)
        {
            try
            {
                tbl_users u = new tbl_users();
                u.user_email = pUsers.user_email;
                u.first_name = pUsers.first_name;
                u.last_name = pUsers.last_name;
                u.user_pass = pUsers.user_pass;
                u.user_id = pUsers.user_id;
                Db.tbl_users.Attach(u);
                Db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
        
               public bool fDeleteAdminuser(long pId)
        {
            try
            {
                var q = (from a in Db.tbl_users
                         where a.user_id.Equals(pId)
                         select a).OrderBy(a => a.user_id).SingleOrDefault();
                Db.tbl_users.Remove(q);
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}