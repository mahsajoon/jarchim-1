using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jarchim.da;
using Jarchim.Models;
using Jarchim.Models.database;
using System.IO;
namespace Jarchim.Controllers
{
    public class mAdsController : Controller
    {
        // GET: mAds
        daLogin l = new daLogin();
        daAds n = new daAds();
        JarchimDb Db = new JarchimDb();
        static int pGet = 15;
        static int pSkip = 0;
        // GET: mNews
        public int fUserControl()
        {
            if ((Session["user_email"] != null) && (Session["user_pass"] != null))
            {
                ViewBag.username = Session["user_email"];
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public ActionResult Index(mAd pAd)
        {
            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");

            }
            if (pAd.ad_id > 0)
            {
                ViewBag.IsSearch = "On";
            }
            List<mAd> aAd = new List<mAd>();
            aAd = n.fAdList(pGet, pSkip, pAd);
            ViewBag.title = "فهرست آگهی ها";
            if (pAd.ad_cat > 0)
            {
                return PartialView("_Index", aAd);
            }
            else
            {
                return View(aAd);

            }
        }

        [HttpGet]
        public ActionResult Create()
        {
   DateTime vNowTime = DateTime.Now;
   
   ViewBag.vDefultDate = vNowTime.ToString();
   if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");

            }
            mAd vAds = new mAd();
            ViewBag.title = "آگهی جدید ";
            return View(vAds);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(mAd pAds)
        {
   //pAds.ad_from_date.Value.Hour= DateTime.Now.Hour;
 
   DateTime vNowTime = DateTime.Now;
   DateTime dateWithRightTime1 = pAds.ad_to_date.Value;
   DateTime dateWithRightTime = dateWithRightTime1.Date.Add(vNowTime.TimeOfDay);
   pAds.ad_to_date = dateWithRightTime;
   if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");

            }
            ViewBag.title = "آگهی جدید ";
            if (!(ModelState.IsValid))
            {
                ViewBag.error = "خطا در  اطلاعات ورودی !";
                return View(pAds);

            }
            else
            {
                if (n.InsertAds(pAds))
                {
                    return RedirectToAction("index");
                }
                ViewBag.error = "خطا در انجام عملیات درج ! ";
            }
            return View(pAds);
        }

        [HttpGet]
        public ActionResult Edit(int pId)
        {

            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");
            }
            ViewBag.title = "ویرایش آگهی";
            mAd vAds = new mAd();
            vAds.ad_id = pId;
            vAds = n.fGetmAds(vAds);
            return View(vAds);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(mAd pAds)
        {
   DateTime vNowTime = DateTime.Now;
   DateTime dateWithRightTime1 = pAds.ad_from_date.Value;
   DateTime dateWithRightTime = dateWithRightTime1.Date.Add(vNowTime.TimeOfDay);
   pAds.ad_from_date = dateWithRightTime;

   DateTime dateWithRightTime2 = pAds.ad_to_date.Value;
   DateTime dateWithRightTime3 = dateWithRightTime2.Date.Add(vNowTime.TimeOfDay);
   pAds.ad_to_date = dateWithRightTime3;
   if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");
            }
            ViewBag.title = "ویرایش آگهی";
            if (!(ModelState.IsValid))
            {
                ViewBag.error = "خطا در  اطلاعات ورودی !";
                return View(pAds);

            }
            else
            {
                if (n.fUpdateAds(pAds))
                {
                    return RedirectToAction("index");
                }
                ViewBag.error = "خطا در انجام عملیات ویرایش ! ";
            }
            return View(pAds);
        }

        public ActionResult RemoveAds(int pId)
        {

            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("Login", "LoginForm");
            }
            mAd vNews = new mAd();
            if (n.fDeleteAds(pId))
            {
                return Json(pId, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(pId, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult fGetPage(int pPageNum, string pAction)
        {
            pSkip = (pPageNum - 1) * pGet;
            return RedirectToAction(pAction);
        }
    }
}