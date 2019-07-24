using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jarchim.Models;
using Jarchim.Models.database;
using System.Threading;

namespace Jarchim.da
{
    public class daAboutUs
    {
        JarchimDb Db = new JarchimDb();
        //static int RefNumber = 100;
        public List<mAbout> fAboutList(int pGet, int pSkip)
        {
            var vAbout = (from a in Db.tbl_about
                          select new mAbout
                          {
                              about_us_id = a.about_us_id,
                             about_us_img = a.about_us_img,
                              about_us_img_alt = a.about_us_img_alt,
                              about_us_title = a.about_us_title,
                              about_exp_three = a.about_exp_three,
                              about_us_exp_one = a.about_us_exp_one,
                               about_us_exp_two = a.about_us_exp_two,
                              about_us_type = a.about_us_type
                          }).OrderByDescending(b => b.about_us_id).Skip(pSkip).Take(pGet);
            return vAbout.ToList();
        }

        public mAbout fGetAboutUs(mAbout pAboutUs)
        {
            try
            {

                var vAboutUs = (from n in Db.tbl_about
                                where n.about_us_id.Equals(pAboutUs.about_us_id)
                                select new mAbout
                                {
                                    about_us_id = n.about_us_id,
                                    about_us_img = n.about_us_img,
                                    about_us_img_alt = n.about_us_img_alt,
                                    about_us_title = n.about_us_title,
                                    about_exp_three = n.about_exp_three,
                                    about_us_exp_one = n.about_us_exp_one,
                                    about_us_exp_two = n.about_us_exp_two,
                                   about_us_type = n.about_us_type
                                }).FirstOrDefault();
                return vAboutUs;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool InsertAbout(mAbout pAboutUs)
        {
            try
            {
                Random rnd = new Random();
                tbl_about a = new tbl_about();
                a.about_us_img = pAboutUs.about_us_img;
                a.about_us_img_alt = pAboutUs.about_us_img_alt;
                a.about_us_title = pAboutUs.about_us_title;
                a.about_exp_three = pAboutUs.about_exp_three;
                a.about_us_exp_one = pAboutUs.about_us_exp_one;
                a.about_us_exp_two = pAboutUs.about_us_exp_two;
                a.about_us_id = rnd.Next();
                Db.tbl_about.Add(a);
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool fUpdatemficoStory(mAbout pAboutUs)
        {
            try
            {
                tbl_about a = new tbl_about();
                a.about_us_id = pAboutUs.about_us_id;
                a.about_us_img = pAboutUs.about_us_img;
                a.about_us_img_alt = pAboutUs.about_us_img_alt;
                a.about_us_title = pAboutUs.about_us_title;
                a.about_exp_three = pAboutUs.about_exp_three;
                a.about_us_exp_one = pAboutUs.about_us_exp_one;
                a.about_us_exp_two = pAboutUs.about_us_exp_two;
                Db.tbl_about.Attach(a);
                Db.Entry(a).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}