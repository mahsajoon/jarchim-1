using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jarchim.Models;
using Jarchim.Models.database;

namespace Jarchim.da
{
    public class daAdImg
    {
        JarchimDb Db = new JarchimDb();
        public List<mAdImg> fAdImgList(int pGet, int pSkip, mAdImg pAdImg)
        {

            if(pAdImg.ad_id>0 && pAdImg.ad_cat>0 && pAdImg.ad_city > 0)
            {
                var vAds = (from n in Db.tbl_img_ad
                            join a in Db.tbl_ad on n.img_id equals a.ad_id
                            join ca in Db.tbl_category on a.ad_cat equals ca.cat_id
                            join ci in Db.tbl_city on a.ad_city equals ci.city_id
                            where n.img_id == pAdImg.ad_id && a.ad_city == pAdImg.ad_city && a.ad_cat == pAdImg.ad_cat
                            select new mAdImg
                            {
                                ad_img = n.ad_img,
                                ad_img_title = n.ad_img_title,
                                img_id = n.img_id,
                                ad_city = a.ad_city,
                                ad_cat = a.ad_cat,
                                ad_id = a.ad_id
                            }).OrderByDescending(b => b.ad_img).Skip(pSkip).Take(pGet);
                return vAds.ToList();
            }
            else
            {
                var vAds = (from n in Db.tbl_img_ad
                            select new mAdImg
                            {
                                ad_img = n.ad_img,
                                ad_img_title = n.ad_img_title,
                                img_id = n.img_id
                            }).OrderByDescending(b => b.ad_img).Skip(pSkip).Take(pGet);
                return vAds.ToList();
            }
           
        }

        public bool InsertAdImg(mAdImg pAdImg)
        {
            Random rnd = new Random();
            tbl_img_ad n = new tbl_img_ad();
                n.ad_img_title = pAdImg.ad_img_title;
                n.ad_img = pAdImg.ad_img;
                n.ad_id = pAdImg.ad_id;
                n.img_id = rnd.Next();
                Db.tbl_img_ad.Add(n);
                return Convert.ToBoolean(Db.SaveChanges());
           
        }

        public mAdImg fGetAdImg(mAdImg pAds)
        {
            try
            {

                var vAds = (from n in Db.tbl_img_ad
                            where n.img_id.Equals(pAds.img_id)
                            select new mAdImg
                            {
                                ad_img = n.ad_img,
                                ad_img_title = n.ad_img_title,
                                ad_id = n.ad_id,
                                img_id = n.img_id
                            }).FirstOrDefault();
                return vAds;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool fUpdateAdImg(mAdImg pAdImg)
        {
           
                tbl_img_ad n = new tbl_img_ad();
                n.ad_img_title = pAdImg.ad_img_title;
                n.ad_img = pAdImg.ad_img;
                n.ad_id = pAdImg.ad_id;
                n.img_id = pAdImg.img_id;
                Db.tbl_img_ad.Attach(n);
                Db.Entry(n).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(Db.SaveChanges());
         
        }

        public bool fDeleteAdImg(int pId)
        {
           
                var vAds = (from a in Db.tbl_img_ad
                            where a.img_id.Equals(pId)
                            select a).OrderBy(a => a.ad_id).SingleOrDefault();
                Db.tbl_img_ad.Remove(vAds);
                return Convert.ToBoolean(Db.SaveChanges());
           
        }
    }
}