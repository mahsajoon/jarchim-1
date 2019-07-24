using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jarchim.Models;
using Jarchim.Models.database;
namespace Jarchim.da
{
    public class daComments
    {
        JarchimDb Db = new JarchimDb();
        public List<mComment> fCommentList(int pGet, int pSkip)
        {

            var vComments = (from n in Db.tbl_comment
                              select new mComment
                              {
                                  ad_id = n.ad_id,
                                  comment_date = n.comment_date,
                                  comment_id = n.comment_id,
                                  c_confirm = n.c_confirm,
                                  c_dislike = n.c_dislike,
                                  c_like = n.c_like,
                                  top_id = n.top_id,
                                  user_email = n.user_email,
                                  user_ip_addr = n.user_ip_addr,
                                  user_name = n.user_name,
                                  user_text = n.user_text,
                                  c_read = n.c_read
                              }).OrderBy(b => b.comment_id).Skip(pSkip).Take(pGet);
            return vComments.ToList();

        }
        public bool fDeleteComment(int pId)
        {
            try
            {
                var vComments = (from a in Db.tbl_comment
                                 where a.comment_id.Equals(pId)
                                select a).OrderBy(a => a.comment_id).SingleOrDefault();
                Db.tbl_comment.Remove(vComments);
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}