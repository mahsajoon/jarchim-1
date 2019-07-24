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
  public mHome fGetAdsContent(int pSkip, int pGet, mAd pAd)
  {

   mHome pHome = new mHome();
   {
    var vAd = (from a in Db.tbl_ad
               join c in Db.tbl_category on a.ad_cat equals c.cat_id
               where a.ad_cat == pAd.ad_cat
               select new mAd
               {
                ad_buy_count = a.ad_buy_count,
                ad_to_date = a.ad_to_date,
                //ad_to_time = a.ad_to_time,
                ad_from_date = a.ad_from_date,
                //ad_from_time = a.ad_from_time,
                ad_dislike = a.ad_dislike,
                ad_exp_one = a.ad_exp_one,
                ad_exp_two = a.ad_exp_two,
                ad_id = a.ad_id,
                ad_like = a.ad_like,
                ad_name = a.ad_name,
                ad_price = a.ad_price,
                ad_summery = a.ad_summery,
                ad_visit = a.ad_visit,
                copen_id = a.copen_id,
                user_id = a.user_id,
                ad_cat = a.ad_cat,
                cat_name = c.cat_title,
                
               }).OrderByDescending(b => b.ad_id).Skip(pSkip).Take(pGet);

    var vAdImg = (from a in Db.tbl_ad
                  join b in Db.tbl_img_ad on a.ad_id equals b.img_id
                  join c in Db.tbl_category on a.ad_cat equals c.cat_id
                  where a.ad_cat == pAd.ad_cat
                  select new mAdImg
                  {
                   ad_img = b.ad_img,
                   img_id = b.img_id
                  }).OrderByDescending(b => b.img_id).Skip(pSkip).Take(pGet);

    pHome.aAd = vAd.ToList();
    pHome.aAdImg = vAdImg.ToList();
   }
   return pHome;
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