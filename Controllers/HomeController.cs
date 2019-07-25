using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jarchim.da;
using Jarchim.Models;
namespace Jarchim.Controllers
{
    public class HomeController : Controller
    {
        static int pGet = 5;
        static int pSkip = 0;
   int pCityId = 0;
  int pAdSavePer = 0;
  daHome h = new daHome();
        daAds a = new daAds();
  daCategory c = new daCategory();
  Models.database.JarchimDb JarchimDb = new Models.database.JarchimDb();
  public ActionResult Index()

  {

            mHome vHome = new mHome();
            vHome = h.fGetHomeContent();
            vHome.aSpecialOffer = a.fAdList(5, pSkip, 1, pAdSavePer, pCityId);
            vHome.aRestaurantCofes = a.fAdList(pGet, pSkip, 2, pAdSavePer, pCityId);
   vHome.aArtTheater = a.fAdList(pGet, pSkip, 3, pAdSavePer, pCityId);
   vHome.aSportRecreation = a.fAdList(pGet, pSkip, 4, pAdSavePer, pCityId);
   vHome.aEducational = a.fAdList(pGet, pSkip, 5, pAdSavePer, pCityId);
   vHome.aHealthMedicine = a.fAdList(pGet, pSkip, 6, pAdSavePer, pCityId);
   vHome.aBeautyCosmetics = a.fAdList(pGet, pSkip, 7, pAdSavePer, pCityId);
   vHome.aServices = a.fAdList(pGet, pSkip, 8, pAdSavePer, pCityId);
   vHome.aTourTravel = a.fAdList(pGet, pSkip, 9, pAdSavePer, pCityId);
   vHome.aCommodity = a.fAdList(pGet, pSkip, 10, pAdSavePer, pCityId);
   //pCat= 12 یعنی برو پیشنهادات  لحاظات اخر رو بیار 
   vHome.aLastMoment = a.fAdList(pGet, pSkip, 12, pAdSavePer, pCityId);
   //pCat= 13 یعنی برو پیشنهادات امروز رو بیار
   vHome.aTodayOffer = a.fAdList(pGet, pSkip, 13, pAdSavePer, pCityId);
   //pCat= 14 یعنی برو پربازدیدترین ها  رو بیار
   vHome.aMostVisit = a.fAdList(pGet, pSkip, 14, pAdSavePer, pCityId);
   //vHome.RatingAvg = q.TblRaiting.Count == 0 ? "0" : (q.TblRaiting.Sum(a => a.Star) / q.TblRaiting.Count()).ToString() + " از " + q.TblRaiting.Count();

   vHome.aCity = a.fCityList();
   vHome.aCategory = c.fGetCatList(0);
   if (vHome.aCity == null)
   {
    vHome.aCity = new List<mCity>();
   }
   if (vHome == null)
            {
                vHome = new mHome();
            }
            return View(vHome);
        }

  #region "13980412"
  public ActionResult SearchAds(mAd pAd)
  {
   mHome vHome = new mHome();
   mAd vAd = new mAd();
   //vHome = c.fGetAdsContent(pSkip, pGet, pAd);
   vHome.aAd = new List<mAd>();
   vHome.aAd = a.fAdList(pGet, pSkip, pAd.ad_cat, pAd.ad_save_per, pAd.ad_city);
   vHome.vmAd = new mAd();
   //vHome.vmAd.ad_cat = 2;
   vHome.aSubGroup = c.fGetCatList(pAd.ad_cat);
   return(PartialView("_SearchAds", vHome));
  }
  #endregion
  public ActionResult blog()
  {
   return View();
  }
  public ActionResult about()
        {
            return View();
        }
        public ActionResult changePassword()
        {

            return View();
        }
        public ActionResult contact()
        {

            return View();
        }
        public ActionResult properties()
        {

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(mUser pUser)
        {
            mHome vHome = new mHome();
            if (ModelState.IsValid)
            {
                if (h.CheckLogin(pUser.user_email, pUser.user_pass))
                {
                    if (h.RegisterUser(pUser))
                    {
                        vHome.pSuccess = "اطلاعات با موفقیت ثبت شد.";
                    }
                }

                else
                {
                    vHome.pError = "متاسفانه اطلاعات ثبت نشد.";
                }
            }
            else
            {
                vHome.pError = "اطلاعات را با دقت پر نمایید.";
            }

            return Json(vHome, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Login()
        {
            return View("LogIn");
        }
        [HttpPost]
        public ActionResult Login(mUser pUsers)
        {
            mHome vHome = new mHome();
            ViewBag.title = "فرم ورود";
            if (pUsers.user_email == "" || pUsers.user_pass == "")
            {
                vHome.pError = "تکمیل فیلد ها الزامی است !";
                return View("Index", pUsers);
            }
            else
            {
                if (h.CheckLogin(pUsers.user_email, pUsers.user_pass))
                {
                    Session["user_email"] = pUsers.user_email;
                    Session["user_pass"] = pUsers.user_pass;
                    vHome.pSuccess = "کاربر عزیز خوش آمدید...";
                    return Json(vHome, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    vHome.pError = "نام کاربری یا کلمه عبور اشتباه است.";
                    return Json(vHome, JsonRequestBehavior.AllowGet);
                }
            }
        }
        [HttpPost]
        public JsonResult DupUserName(string first_name)
        {
            var q = JarchimDb.tbl_users.Where(a => a.first_name == first_name).SingleOrDefault();
            if (q == null)
            {
                return Json(true);
            }
            else
            {
                return Json(true);
            }
        }

        [HttpPost]
        public JsonResult DupEmail(mNewsletter pNewsLetter)
        {
            var q = JarchimDb.tbl_newsletter.Where(a => a.newsletter_email == pNewsLetter.newsletter_email).SingleOrDefault();
            mHome vHome = new mHome();
            mNewsletter vNewsLetter = new mNewsletter();
            vNewsLetter.newsletter_email = pNewsLetter.newsletter_email;
            if (q == null)
            {

                h.InsertNewsLetterEmail(vNewsLetter);
                vHome.pSuccess = "ایمیل شما با موفقیت ثبت شد.";

            }
            else
                vHome.pError = "این ایمیل قبلا ثبت شده است.";

            return Json(vHome, JsonRequestBehavior.AllowGet);
        }

    }
}