using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jarchim.da;
using Jarchim.Models;
namespace Jarchim.Controllers
{
    public class CategoryController : Controller
    {
        daCategory c = new daCategory();
        daAds a = new daAds();
  static int pGet = 18;
  static int pSkip = 0;
  // GET: Category
  public ActionResult Ads(int cat, int page,string title)
        {
            mHome vHome = new mHome();
            mAd vAd = new mAd();
            vHome.aAd = c.fGetAdsContent(pSkip, pGet, cat);
            vHome.aTodayOffer = a.fAdList(pGet, pSkip, 13,0,0);
            vHome.vmAd = new mAd();
            vHome.vmAd.ad_cat = 2;
   vHome.aSubGroup = c.fGetCatList(page);
   return View(vHome);
  }
        public ActionResult Contact()
        {
            ViewBag.mainbc = "تماس با ما";
            ViewBag.detailbc = "تماس";
            mHome vHome = new mHome();
            return View();
        }
        [HttpPost]
        public ActionResult Contact(mContact pContact)
        {
            ViewBag.mainbc = "تماس با ما";
            ViewBag.detailbc = "تماس";
            if (ModelState.IsValid)
            {
                if (c.InsertContact(pContact))
                {
                    ViewBag.Message = "اطلاعات با موفقیت ثبت شد.";
                }

                else
                {
                    ViewBag.Message = "متاسفانه اطلاعات ثبت نشد.";
                }
            }
            else
            {
                ViewBag.Message = "اطلاعات را با دقت پر نمایید.";
            }

            return View("Contact");
        }

  public ActionResult fGetPage(int pPageNum, string pAction)
  {
   pSkip = (pPageNum - 1) * pGet;
   return RedirectToAction(pAction);
  }
 }
}