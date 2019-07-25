using Jarchim.Models;
using Jarchim.Models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarchim.da
{
 public class daCategory
 {
  JarchimDb Db = new JarchimDb();
  public List<mAd> fGetAdsContent(int pSkip, int pGet, int pCat)
  {

            List<mAd> aAdList = new List<mAd>();
            List<mAdImg> aAdImg = new List<mAdImg>();
            List<tbl_ad> vAds = new List<tbl_ad>();
            mAd pAd = new mAd();
            
                var query = from n in Db.tbl_ad
                            join c in Db.tbl_category on n.ad_cat equals c.cat_id
                            where n.ad_cat == pCat
                            orderby n.ad_id descending
                            select n;
                vAds = query.Skip(pSkip).Take(pGet).ToList();
            
            foreach (var item in vAds)
            {
                pAd = new mAd();
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
                pAd.ad_exp_three = item.ad_exp_three;
                pAd.ad_city = item.ad_city;
                pAd.cat_name = fGetCatTitle(pCat).cat_title;
                aAdList.Add(pAd);
            }
            return aAdList;
        }
        public mCategory fGetCatTitle(int pCatId)
        {
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

        public bool InsertContact(mContact pContact)
  {
   try
   {
    Random rnd = new Random();
    tbl_contact cu = new tbl_contact();
    cu.contact_id = rnd.Next();
    cu.contact_phone = pContact.contact_phone;
    cu.contact_name = pContact.contact_name;
    cu.contact_email = pContact.contact_email;
    cu.contact_text = pContact.contact_text;
    cu.contact_is_read = pContact.contact_is_read;
    Db.tbl_contact.Add(cu);
    return Convert.ToBoolean(Db.SaveChanges());
   }
   catch (Exception)
   {
    return false;
   }
  }
  public List<mCategory> fGetCatList()
  {
   mCategory pCategory = new mCategory();

   var vCategory = (from c in Db.tbl_category
                    where c.top_id == 0
                    select new mCategory
                    {
                     cat_id = c.cat_id,
                     cat_title = c.cat_title,
                     cat_href = c.cat_href,
                     top_id = c.top_id
                    }).OrderBy(c => c.cat_id).ToList();
   return vCategory;

  }
  public List<mCategory> fGetCatList(int vTopId)
  {
   mCategory pCategory = new mCategory();

   var vCategory = (from c in Db.tbl_category
                    where c.top_id == vTopId
                    select new mCategory
                    {
                     cat_id = c.cat_id,
                     cat_title = c.cat_title,
                     cat_icon_img = c.cat_icon_img,
                     cat_baner_img = c.cat_baner_img,
                     cat_href = c.cat_href,
                     top_id = c.top_id
                    }).OrderBy(c => c.cat_id).ToList();
   return vCategory;
  }
  //public List<mCategory> fGetSubCatList(int pCatId)
  //{
  // mCategory pCategory = new mCategory();

  // var vCategory = (from c in Db.tbl_category
  //                  where c.top_id == pCatId
  //                  select new mCategory
  //                  {
  //                   cat_id = c.cat_id,
  //                   cat_title = c.cat_title,
  //                   cat_href = c.cat_href,
  //                   top_id = c.top_id
  //                  }).OrderBy(c => c.cat_id).ToList();
  // return vCategory;
  //}
  #region "13980412"

  #endregion
  public bool IsDecimal(decimal pNum)
  {
   string pNumStr = pNum.ToString();
   if (pNumStr.Contains('.'))
   {
    return true;
   }
   else
   {
    return false;
   }
  }
 }
}