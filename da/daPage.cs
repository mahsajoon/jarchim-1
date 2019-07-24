using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jarchim.Models;
using Jarchim.Models.database;

namespace mfico.da
{
    public class daPage
    {
        JarchimDb Db = new JarchimDb();

        public List<mComment> fGetCmList(int pAdId)
        {

            List<tbl_comment> vComment = new List<tbl_comment>();
            var query = from c in Db.tbl_comment
                        where c.top_id == 0 && c.ad_id == pAdId
                        orderby c.comment_id descending
                        select c;
            vComment = query.ToList();

            List<mComment> aComment = new List<mComment>();
            mComment pComment = new mComment();
            foreach (var item in vComment)
            {
                pComment = new mComment();
                pComment.comment_date = item.comment_date;
                pComment.ad_id = item.ad_id;
                pComment.user_name = item.user_name;
                pComment.user_text = item.user_text;
                pComment.top_id = item.top_id;
                pComment.comment_id = item.comment_id;
                pComment.c_like = item.c_like;
                pComment.aComment = fGetCmChild(pComment.comment_id);
                aComment.Add(pComment);
            }
            return aComment;
        }
        public List<mComment> fGetCmChild(int? vTopId)
        {
            mComment pComment = new mComment();

            var vComment = (from c in Db.tbl_comment
                            where c.top_id == vTopId
                            select new mComment
                            {
                                ad_id = c.ad_id,
                                comment_date = c.comment_date,
                                comment_id = c.comment_id,
                                user_text = c.user_text,
                                user_name = c.user_name,
                                top_id = c.top_id
                            }).OrderBy(c => c.comment_id).ToList();
            return vComment;
        }

        public bool InsertComment(mComment pComment)
        {
            try
            {
                PersianDateTime now = PersianDateTime.Now;
                //string vPersianDate = now.ToString(PersianDateTimeFormat.Date);
                //int vNowDate = vPersianDate.Replace("/", String.Empty);
                DateTime vNowDate = DateTime.Now;
                Random rnd = new Random();
                tbl_comment cu = new tbl_comment();
                cu.comment_id = rnd.Next();
                cu.ad_id = pComment.ad_id;
                cu.user_text = pComment.user_text;
                cu.user_email = pComment.user_email;
                cu.user_name = pComment.user_name;
                cu.top_id = 0;
                cu.comment_date = vNowDate;
                Db.tbl_comment.Add(cu);
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int CommLike(int CmId)
        {
            var q = (from a in Db.tbl_comment
                     where a.comment_id.Equals(CmId)
                     select a).SingleOrDefault();

            q.c_like++;

            Db.tbl_comment.Attach(q);
            Db.Entry(q).State = System.Data.Entity.EntityState.Modified;

            if (Convert.ToBoolean(Db.SaveChanges()))
            {
                return q.c_like.Value;
            }
            else
            {
                return q.c_like.Value - 1;
            }
        }
    }
}