using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jarchim.Models;
using Jarchim.Models.database;

namespace Jarchim.da
{
    public class daHome
    {
        JarchimDb Db = new JarchimDb();
        mHome pHome = new mHome();

        public mHome fGetHomeContent()
        {
            var vSlider = (from s in Db.tbl_slider
                           select new mSlider
                           {
                               slider_id = s.slider_id,
                               slider_img = s.slider_img,
                               slider_link = s.slider_link,
                               slider_sort = s.slider_sort
                           }).OrderBy(b => b.slider_id);
            pHome.aSlider = vSlider.ToList();

            var vAds = (from n in Db.tbl_ad
                        join i in Db.tbl_img_ad on n.ad_id equals i.img_id
                        where n.ad_id.Equals(i.img_id)
                        select new mAd
                        {
                            ad_id = n.ad_id,
                            ad_buy_count = n.ad_buy_count,
                            ad_to_date = n.ad_to_date,
                            //ad_to_time = n.ad_to_time,
                            ad_from_date = n.ad_from_date,
                            //ad_from_time = n.ad_from_time,
                            ad_dislike = n.ad_dislike,
                            ad_exp_one = n.ad_exp_one,
                            ad_exp_two = n.ad_exp_two,
                            ad_like = n.ad_like,
                            ad_name = n.ad_name,
                            ad_price = n.ad_price,
                            ad_summery = n.ad_summery,
                            ad_visit = n.ad_visit,
                            copen_id = n.copen_id,
                            user_id = n.user_id,
                            ad_img = i.ad_img
                        }).OrderByDescending(b => b.ad_id).Take(18);

            pHome.aAd = vAds.ToList();

            return pHome;
        }

        public bool CheckLogin(string UserEmail, string Password)
        {
            int vLogin = (from a in Db.tbl_users
                          where a.user_email.Equals(UserEmail) && a.user_pass.Equals(Password)
                          select a).Count();
            return Convert.ToBoolean(vLogin);
        }

        public bool RegisterUser(mUser pUser)
        {
            try
            {
                Random rnd = new Random();
                tbl_users cu = new tbl_users();
                cu.user_id = rnd.Next();
                cu.user_email = pUser.user_email;
                cu.user_pass = pUser.user_pass;
                cu.user_access = pUser.user_access;
                Db.tbl_users.Add(cu);
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool InsertNewsLetterEmail(mNewsletter pNewsletter)
        {
            try
            {
                Random rnd = new Random();
                tbl_newsletter nu = new tbl_newsletter();
                nu.newsletter_id = rnd.Next();
                nu.newsletter_email = pNewsletter.newsletter_email;
                Db.tbl_newsletter.Add(nu);
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}