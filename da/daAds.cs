using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jarchim.Models;
using Jarchim.Models.database;
namespace Jarchim.da
{
    public class daAds
    {
        JarchimDb Db = new JarchimDb();
        public List<mAd> fAdList(int pGet, int pSkip, mAd pAd)
        {
            if (pAd.ad_cat > 0)
            {
                var vAds = (from n in Db.tbl_ad
                            where n.ad_cat == pAd.ad_cat
                            select new mAd
                            {
                                ad_id = n.ad_id,
                                ad_buy_count = n.ad_buy_count,
                                ad_to_date = n.ad_to_date,
                                //ad_to_time = n.ad_to_time,
                                ad_from_date = n.ad_from_date,
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
                                ad_cat = n.ad_cat,
                                ad_exp_three = n.ad_exp_three,
                                ad_city = n.ad_city
                            }).OrderByDescending(b => b.ad_id).Skip(pSkip).Take(pGet);
                return vAds.ToList();
            }
            else
            {
                var vAds = (from n in Db.tbl_ad
                            select new mAd
                            {
                                ad_id = n.ad_id,
                                ad_buy_count = n.ad_buy_count,
                                ad_to_date = n.ad_to_date,
                                ad_from_date = n.ad_from_date,
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
                                ad_cat = n.ad_cat,
                                ad_exp_three = n.ad_exp_three,
                                ad_city = n.ad_city
                            }).OrderByDescending(b => b.ad_id).Skip(pSkip).Take(pGet);
                return vAds.ToList();
            }

        }

        public bool InsertAds(mAd pAds)
        {
            //pAds.ad_from_date = int.Parse(pAds.ad_from_date_str.Replace("/", String.Empty));
            //pAds.ad_to_date = int.Parse(pAds.ad_to_date_str.Replace("/", String.Empty));
            //pAds.ad_from_time = int.Parse(pAds.ad_from_time_str.Replace(":", String.Empty));
            //pAds.ad_to_time = int.Parse(pAds.ad_to_time_str.Replace(":", String.Empty));
            Random rnd = new Random();
                tbl_ad n = new tbl_ad();
            n.ad_buy_count = pAds.ad_buy_count;
            n.ad_from_date = pAds.ad_from_date;
            n.ad_to_date = pAds.ad_to_date;
            n.ad_dislike = pAds.ad_dislike;
            n.ad_exp_one = pAds.ad_exp_one;
            n.ad_exp_two = pAds.ad_exp_two;
            n.ad_like = pAds.ad_like;
            n.ad_name = pAds.ad_name;
            n.ad_price = pAds.ad_price;
            n.ad_summery = pAds.ad_summery;
            n.ad_visit = pAds.ad_visit;
            n.ad_city = pAds.ad_city;
            n.ad_cat = pAds.ad_cat;
            n.ad_exp_three = pAds.ad_exp_three;
            n.ad_id = rnd.Next();
                Db.tbl_ad.Add(n);
                return Convert.ToBoolean(Db.SaveChanges());
        
        }
        public mAd fGetmAds(mAd pAds)
        {
            try
            {
    DateTime vNowTime = DateTime.Now;
    //TimeSpan ts = (item.ad_to_date - vNowTime).Value;
    //var vTotalDays = ts.TotalDays;
    //var vTotalHours = ts.TotalHours;
    //var vTotalMinutes = ts.TotalMinutes;
    //var vDays = ts.Days;
    //var vHours = ts.Hours;
    //var vMinutes = ts.Minutes;
    //var vSeconds = ts.Seconds;
    //var deadline = new Date(Date.parse(new Date()) + 16 * 24 * 60 * 60 * 1000);
    var vAds = (from n in Db.tbl_ad
                             where n.ad_id.Equals(pAds.ad_id)
                             select new mAd
                             {
                                 ad_id = n.ad_id,
                                 ad_buy_count = n.ad_buy_count,
                                 ad_to_date = n.ad_to_date,
                                 ad_from_date = n.ad_from_date,
                                 ad_dislike = n.ad_dislike,
                                 ad_visit = n.ad_visit,
                                 ad_summery = n.ad_summery,
                                 ad_exp_one = n.ad_exp_one,
                                 ad_exp_two = n.ad_exp_two,
                                 ad_like = n.ad_like,
                                 ad_name = n.ad_name,
                                 ad_price = n.ad_price,
                                 ad_cat = n.ad_cat,
                                 ad_exp_three = n.ad_exp_three,
                                  ad_city = n.ad_city
                             }).FirstOrDefault();
    TimeSpan ts = (vAds.ad_to_date - vNowTime).Value;
    var vTotalDays = ts.TotalDays;
    var vTotalHours = ts.TotalHours;
    var vTotalMinutes = ts.TotalMinutes;
    var vDays = ts.Days;
    var vHours = ts.Hours;
    var vMinutes = ts.Minutes;
    var vSeconds = ts.Seconds;
    //var deadline = new Date(Date.parse(new Date()) + 16 * 24 * 60 * 60 * 1000);
    vAds.timer_string = "" + vDays + " * " + vHours + " * " + vMinutes + " * " + vSeconds + " * 1000 " + "";
    var vAdImg = (from i in Db.tbl_img_ad
                              where i.ad_id.Equals(pAds.ad_id)
                              select new mAdImg
                              {
                                  ad_img = i.ad_img,
                                  ad_img_title = i.ad_img_title,
                                  img_id = i.img_id
                              }).OrderByDescending(b => b.ad_img);
                vAds.aAdImg = vAdImg.ToList();
                return vAds;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool fUpdateAds(mAd pAds)
        {
           //if(pAds.ad_from_date_str != null)
           // {
           //     pAds.ad_from_date = int.Parse(pAds.ad_from_date_str.Replace("/", String.Empty));
           //     pAds.ad_to_date = int.Parse(pAds.ad_to_date_str.Replace("/", String.Empty));
           // }
           // if (pAds.ad_from_time_str != null) { 
           //     pAds.ad_from_time = int.Parse(pAds.ad_from_time_str.Replace(":", String.Empty));
           //     pAds.ad_to_time = int.Parse(pAds.ad_to_time_str.Replace(":", String.Empty));
           // }

            try
            {
                tbl_ad n = new tbl_ad();
                n.ad_id = pAds.ad_id;
                n.ad_buy_count = pAds.ad_buy_count;
               
                n.ad_from_date = pAds.ad_from_date;
                n.ad_to_date = pAds.ad_to_date;
     
                n.ad_dislike = pAds.ad_dislike;
                n.ad_exp_one = pAds.ad_exp_one;
                n.ad_exp_two = pAds.ad_exp_two;
                n.ad_like = pAds.ad_like;
                n.ad_name = pAds.ad_name;
                n.ad_price = pAds.ad_price;
                n.ad_summery = pAds.ad_summery;
                n.ad_city = pAds.ad_city;
                n.ad_cat = pAds.ad_cat;
                n.ad_visit = pAds.ad_visit;
                n.ad_exp_three = pAds.ad_exp_three;
                Db.tbl_ad.Attach(n);
                Db.Entry(n).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool fDeleteAds(int pId)
        {
            try
            {
                List<tbl_img_ad> vAdsimg = new List<tbl_img_ad>();
                var query = from i in Db.tbl_img_ad
                            where i.ad_id.Equals(pId)
                            select i;
                vAdsimg = query.ToList();

                foreach (var item in vAdsimg)
                {
                    var vAdsimgs = (from a in Db.tbl_img_ad
                                    where a.ad_id.Equals(item.ad_id)
                                    select a).OrderBy(a => a.ad_id).SingleOrDefault();
                    Db.tbl_img_ad.Remove(vAdsimgs);
                    Convert.ToBoolean(Db.SaveChanges());
                }


                var vAds = (from a in Db.tbl_ad
                            where a.ad_id.Equals(pId)
                            select a).OrderBy(a => a.ad_id).SingleOrDefault();
                Db.tbl_ad.Remove(vAds);
                return Convert.ToBoolean(Db.SaveChanges());

            }
            catch (Exception)
            {
                return false;
            }
        }

        #region "mahsa"      
        public List<mAd> fAdList(int pGet, int pSkip, int pCat , int? pSavePer, int? pCityId)
  {
   if (pSavePer==null )
   {
    pSavePer = 0;

   }
   if  ( pCityId == null)
   {
    pCityId = 0;

   }
  
   PersianDateTime now = PersianDateTime.Now;
   List<tbl_ad> vAds = new List<tbl_ad>();
   DateTime vNowTime = DateTime.Now;
   var targetDate = DateTime.Now.AddHours(1);
   TimeSpan persianTime = now.TimeOfDay; // 23:37:57.4641984
   TimeSpan persianTime1 = vNowTime.TimeOfDay;
   //پیشنهادات امروز
   if (pCat == 13)
   {
    //var query = from n in Db.tbl_ad
    //            join c in Db.tbl_category on n.ad_cat equals c.cat_id
    //            where n.ad_from_date == vNowTime
    //            orderby n.ad_id descending
    //            select n;
    //vAds = query.Skip(pSkip).Take(pGet).ToList();
  vAds = Db.tbl_ad
                  .Where(
                x => x.ad_from_date.Value.Year == vNowTime.Year
                && x.ad_from_date.Value.Month == vNowTime.Month
                        && x.ad_from_date.Value.Day == vNowTime.Day
                          )
                         .Where(x => x.ad_to_date >= vNowTime)
                        .OrderByDescending(x => x.ad_id )
                        .Skip(pSkip)
                        .Take(pGet)
                        .ToList();


   }
   // پربازدیدترین ها
   else if (pCat == 14)
   {
    var query = from n in Db.tbl_ad
                where n.ad_from_date <= vNowTime
                where n.ad_to_date >= vNowTime
                orderby n.ad_visit descending
                select n;
    vAds = query.Skip(pSkip).Take(pGet).ToList();
   }
   //پیشنهادات لحظه ی اخری
   else if (pCat == 12)
            {
    //var query = Db.tbl_ad
    //                  .Where(a =>  a.ad_from_date.Date == vNowTime.Date)
    //                  .First();
    vAds = Db.tbl_ad
                      .Where(
                    x => x.ad_to_date.Value.Year == vNowTime.Year
                    && x.ad_to_date.Value.Month == vNowTime.Month
                            && x.ad_to_date.Value.Day == vNowTime.Day 
                            && x.ad_to_date.Value.Hour== vNowTime.Hour
                          && x.ad_to_date.Value.Minute > vNowTime.Minute )
                            .OrderByDescending(x=>x.ad_id)
                            .Skip(pSkip)
                            .Take(pGet)
                            .ToList();

    //var query = from n in Db.tbl_ad
    //                        join c in Db.tbl_category on n.ad_cat equals c.cat_id
    //                        //where n.ad_to_date == vNowTime
    //                        where DateTime.Compare(n.ad_to_date.Value.Date, vNowTime) == 0
    //                        orderby n.ad_id descending
    //                        select n;
    //            vAds = query.Skip(pSkip).Take(pGet).ToList();
/*    vAds = entity.ToString()*/;

            }
   //آگهی هایی با CAT_ID خاص
   else if (pCat == 1 || pCat == 2 || pCat == 3 || pCat == 4 || pCat == 5 || pCat == 6 || pCat == 7 || pCat == 8 || pCat == 9 || pCat == 10)
   {
    if (pCityId > 0 && pSavePer > 0)
    {
     var query = from n in Db.tbl_ad
                 join c in Db.tbl_category on n.ad_cat equals c.cat_id
                 where n.ad_cat == pCat
                 where n.ad_city == pCityId
                 where n.ad_from_date <= vNowTime
                 where n.ad_to_date >= vNowTime
                 where n.ad_save_per <= pSavePer
                 orderby n.ad_id descending
                 select n;
     vAds = query.Skip(pSkip).Take(pGet).ToList();
    }
    else if (pSavePer > 0 && pCityId == 0)
    {
     var query = from n in Db.tbl_ad
                 join c in Db.tbl_category on n.ad_cat equals c.cat_id
                 where  n.ad_cat == pCat
                 where n.ad_save_per <= pSavePer
                 where n.ad_from_date <= vNowTime
                 where n.ad_to_date >= vNowTime
                 orderby n.ad_id descending
                 select n;
     vAds = query.Skip(pSkip).Take(pGet).ToList();
    }
    else if (pCityId > 0 && pSavePer == 0)
    {
     var query = from n in Db.tbl_ad
                 join c in Db.tbl_category on n.ad_cat equals c.cat_id
                 where n.ad_cat == pCat
                 where n.ad_city == pCityId
                 orderby n.ad_id descending
                 select n;
     vAds = query.Skip(pSkip).Take(pGet).ToList();
    }
    else
    {
     var query = from n in Db.tbl_ad
                 join c in Db.tbl_category on n.ad_cat equals c.cat_id
                 where n.ad_cat == pCat
                 where n.ad_from_date <= vNowTime
                 where n.ad_to_date >= vNowTime
                 orderby n.ad_id descending
                 select n;
     vAds = query.Skip(pSkip).Take(pGet).ToList();
    }

   }
   List<mAd> aAdList = new List<mAd>();
   List<mAdImg> aAdImg = new List<mAdImg>();
   mAd pAd = new mAd();
   //pAd.timer_string=  ""
   //var deadline = new Date(Date.parse(new Date()) + 16 * 24 * 60 * 60 * 1000);

   foreach (var item in vAds)
   {

    pAd = new mAd();
    TimeSpan ts = (item.ad_to_date - vNowTime).Value;
    var vTotalDays = ts.TotalDays;
    var vTotalHours = ts.TotalHours;
    var vTotalMinutes = ts.TotalMinutes;
    var vDays = ts.Days;
    var vHours = ts.Hours;
    var vMinutes = ts.Minutes;
    var vSeconds = ts.Seconds;
    //var deadline = new Date(Date.parse(new Date()) + 16 * 24 * 60 * 60 * 1000);
    pAd.timer_string = "" + vDays + " * " + vHours + " * " + vMinutes + " * "+ vSeconds + " * 1000 " + "";
    pAd.ad_id = item.ad_id;
    pAd.aAdImg = fAdImgList(item.ad_id);
    pAd.ad_buy_count = item.ad_buy_count;
    pAd.ad_to_date = item.ad_to_date;

    pAd.ad_from_date = item.ad_from_date;

    pAd.ad_dislike = item.ad_dislike;
    pAd.ad_exp_one = item.ad_exp_one;
    pAd.ad_exp_two = item.ad_exp_two;
    pAd.ad_like = item.ad_like;
    pAd.ad_name = item.ad_name;
    pAd.ad_price = item.ad_price;
    pAd.ad_summery = item.ad_summery;
 
    pAd.ad_visit = item.ad_visit;
    pAd.copen_id = item.copen_id;
    pAd.user_id = item.user_id;
    pAd.ad_cat = item.ad_cat;
    pAd.cat_name = fGetCatTitle(pCat).cat_title;
    pAd.ad_exp_three = item.ad_exp_three;
    pAd.ad_city = item.ad_city;
                //var vDay = item.ad_to_date - item.ad_from_date;
                pAd.rating_avg = fGetAvgRating(item.ad_id);
    aAdList.Add(pAd);
   }


   return aAdList;
  }
  public mCategory fGetCatTitle(int pCatId)
  {
   //pCatId = 0;
   //if (pCatId==null)
   //{
   // pCatId = 0;
   //}
   mCategory vCategory = new mCategory();
   vCategory = (from a in Db.tbl_category
                where a.cat_id == pCatId
                select new mCategory
                {
                 cat_title = a.cat_title
                }).FirstOrDefault();

   return vCategory;
  }
  public List<mAdImg> fAdImgList(long pAdId)
        {
            List<mAdImg> vListImg = new List<mAdImg>();
            var vAdImg = (from a in Db.tbl_img_ad
                          where a.ad_id == pAdId
                          select new mAdImg
                          {
                              ad_img = a.ad_img,
                              img_id = a.img_id,
                           ad_id = a.ad_id,
                           ad_img_title = a.ad_img_title,
                            ad_img_alt = a.ad_img_alt
                          }).OrderByDescending(b => b.img_id);
            if (vAdImg == null)
            {
                return vListImg;
            }
            else
            {
                return vAdImg.ToList();
            }
        }

        public decimal fGetAvgRating(long pAdId)
        {
            //pCatId = 0;
            //if (pCatId==null)
            //{
            // pCatId = 0;
            //}
            List<tbl_rating> vRating = new List<tbl_rating>();
            var  query = from a in Db.tbl_rating
                      where a.ad_id == pAdId
                      select a;
            decimal pStar = 0;
            vRating = query.ToList();
   decimal pAvg = 0;
            foreach (var item in vRating)
            {
                //vmp.RatingAvg = q.TblRaiting.Count == 0 ? "0" : (q.TblRaiting.Sum(a => a.Star) / q.TblRaiting.Count()).ToString() + " از " + q.TblRaiting.Count();

                pStar = item.star_count == 0 ? 0 +pStar  : (item.star_count + pStar).Value;
                
            }
   if (vRating.Count()>0)
   {
     pAvg = pStar / vRating.Count();

   }
   return pAvg;
        }

        #region "13980412"
        public List<mCity> fCityList()
  {
   mCity pCity = new mCity();
   var vCity = (from c in Db.tbl_city
                select new mCity
                {
                 city_id = c.city_id,
                 city_title = c.city_title,
                }).OrderBy(c => c.city_title).ToList();
   return vCity;

  }
  #endregion
 }

 #endregion

}
