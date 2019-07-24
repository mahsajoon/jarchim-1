using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jarchim.da;
using Jarchim.Models;
using mfico.da;
using Jarchim.Models.database;

namespace Jarchim.Controllers
{
    public class PageController : Controller
    {
        daAds a = new daAds();
        daCategory c = new daCategory();
        daPage p = new daPage();
        static int pGet = 18;
        static int pSkip = 0;

        // GET: Page
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Ads(int cat,int page)
        {
            mHome vHome = new mHome();
            vHome.vmAd = new mAd();
            vHome.vmAd.ad_id = page;
            vHome.aLastMoment = a.fAdList(pGet, pSkip, 12,0,0);
            vHome.aSubGroup = c.fGetCatList(cat);
            vHome.aComment = p.fGetCmList(page);
            vHome.vmAd = a.fGetmAds(vHome.vmAd);
            if (vHome.vmAd == null)
            {
                vHome = new mHome();
            }
            vHome.vmAd.ad_visit += 1;
            a.fUpdateAds(vHome.vmAd);            
            return View("Ad", vHome);
        }

        [HttpPost]
        public JsonResult SendComment(mComment pComment)
        {
            mHome vHome = new mHome();

            var vResult = p.InsertComment(pComment);
            if (vResult == true)
            {

                vHome.pSuccess = "دیدگاه شما با موفقیت ارسال شد.";

            }
            else
                vHome.pError = "در ارسال دیدگاه شما خطایی رخ داده است.";

            return Json(vHome, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CommLike(int CmId)
        {
            return Json(p.CommLike(CmId));
        }

        public ActionResult AnsComm(int CmId)
        {
            tbl_comment t = new tbl_comment();
            t.comment_id = CmId;
            return PartialView("_AnsComm", t);
        }
    }
}