using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Jarchim.Models;
using Jarchim.Models.database;

namespace Jarchim.da
{
 public class damCategory
 {
        JarchimDb Db = new JarchimDb();
        static int RefNumber = 100;

        public List<mCategory> fCategoryList()
  {
   var vCat = (from c in Db.tbl_category
                 select new mCategory
                 {
                  cat_href = c.cat_href,
                  cat_id = c.cat_id,
                  cat_title = c.cat_title,
                     cat_baner_img = c.cat_baner_img,
                     cat_icon_img = c.cat_icon_img,
                     top_id = c.top_id
                 }).OrderByDescending(b => b.cat_id);
   return vCat.ToList();
  }
      
  public bool InsertCategory(mCategory pCat)
  {
   try
   {
                Random rnd = new Random();
                tbl_category c = new tbl_category();
    c.cat_href = pCat.cat_href;
                c.cat_id = rnd.Next();
    c.cat_title  = pCat.cat_title;
    c.cat_baner_img = pCat.cat_baner_img;
    c.cat_icon_img = pCat.cat_icon_img;
                c.top_id = pCat.top_id;
                Db.tbl_category.Add(c);
    return Convert.ToBoolean(Db.SaveChanges());
   }
   catch (Exception)
   {
    return false;
   }
  }

  public mCategory fGetCategory(mCategory pCat)
  {
   try
   {
    var vCat = (from c in Db.tbl_category
                  where c.cat_id.Equals(pCat.cat_id)
                  select new mCategory
                  {
                   cat_id = c.cat_id,
                   cat_title = c.cat_title,
                   cat_href = c.cat_href,
                      cat_baner_img = c.cat_baner_img,
                      cat_icon_img = c.cat_icon_img,
                      top_id = c.top_id
                  }).FirstOrDefault();
    return vCat;
   }
   catch (Exception)
   {
    return null;
   }
  }

  public bool fUpdateCategory(mCategory pCat)
  {
   try
   {
    tbl_category c = new tbl_category();
    c.cat_id = pCat.cat_id;
    c.cat_title = pCat.cat_title;
    c.cat_href = pCat.cat_href;
    c.cat_baner_img = pCat.cat_baner_img;
    c.cat_icon_img = pCat.cat_icon_img;
                c.top_id = pCat.top_id;
    Db.tbl_category.Attach(c);
    Db.Entry(c).State = System.Data.Entity.EntityState.Modified;
    return Convert.ToBoolean(Db.SaveChanges());
   }
   catch (Exception)
   {
    return false;
   }
  }

  public bool fDeleteCategory(int pId)
  {
   try
   {
    var vCat = (from c in Db.tbl_category
                where c.cat_id.Equals(pId)
                  select c).OrderBy(a => a.cat_id).SingleOrDefault();
    Db.tbl_category.Remove(vCat);
    return Convert.ToBoolean(Db.SaveChanges());
   }
   catch (Exception)
   {
    return false;
   }
  }
 }
}