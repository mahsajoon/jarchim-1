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
    public class mAdImgController : Controller
    {
        daLogin l = new daLogin();
        daAdImg n = new daAdImg();
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
        public ActionResult Index(mAdImg pAdImg)
        {
            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");

            }
            if (pAdImg.ad_id > 0)
            {
                ViewBag.IsSearch = "On";
            }
            List<mAdImg> aAdImg = new List<mAdImg>();
            aAdImg = n.fAdImgList(pGet, pSkip,pAdImg);
            ViewBag.title = "فهرست تصاویر";
            if (pAdImg.ad_id > 0)
            {
                return PartialView("_Index",aAdImg);
            }
            else
            {
                return View(aAdImg);

            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");

            }
            mAdImg vAdImg = new mAdImg();
            ViewBag.title = "تصویر جدید ";
            return View(vAdImg);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(mAdImg pAdImg)
        {
            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");

            }
            ViewBag.title = "تصویر جدید ";
            if (!(ModelState.IsValid))
            {
                ViewBag.error = "خطا در  اطلاعات ورودی !";
                return View(pAdImg);

            }
            else
            {
                if (pAdImg.img_file != null && pAdImg.img_file.ContentLength > 0)
                {
                    if (pAdImg.img_file.ContentLength < 10485760)
                    {
                        Random rnd = new Random();
                        string img = rnd.Next().ToString() + ".jpg";
                        string Path = System.IO.Path.Combine(Server.MapPath("~/images/ads/"));
                        pAdImg.img_file.SaveAs(Path + img);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pAdImg.img_file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            pAdImg.ad_img = img;
                        }
                    }
                    else
                    {
                        ViewBag.error = "حد اکثر اندازه فایل را رعایت نکرده اید !";
                        return View(pAdImg);
                    }
                }
                else
                {
                    ViewBag.error = "فایلی جهت آپلود انتخاب نشده است ";
                    return View(pAdImg);
                }
                if (n.InsertAdImg(pAdImg))
                {
                    return RedirectToAction("index");
                }
                ViewBag.error = "خطا در انجام عملیات درج ! ";
            }
            return View(pAdImg);
        }

        [HttpGet]
        public ActionResult Edit(int pId)
        {

            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");
            }
            ViewBag.title = "ویرایش تصویر";
            mAdImg vAdImg = new mAdImg();
            vAdImg.img_id = pId;
            vAdImg = n.fGetAdImg(vAdImg);
            return View(vAdImg);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(mAdImg pAdImg)
        {
            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");
            }
            ViewBag.title = "ویرایش تصویر";
            if (!(ModelState.IsValid))
            {
                ViewBag.error = "خطا در  اطلاعات ورودی !";
                return View(pAdImg);

            }
            else
            {
                if (pAdImg.img_file != null && pAdImg.img_file.ContentLength > 0)
                {
                    if (pAdImg.img_file.ContentLength < 10485760)
                    {
                        Random rnd = new Random();
                        string img = rnd.Next().ToString() + ".jpg";
                        string Path = System.IO.Path.Combine(Server.MapPath("~/images/ads/"));
                        pAdImg.img_file.SaveAs(Path + img);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pAdImg.img_file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            pAdImg.ad_img = img;
                        }
                    }
                    else
                    {
                        ViewBag.error = "حد اکثر اندازه فایل را رعایت نکرده اید !";
                        return View(pAdImg);
                    }
                }
                if (n.fUpdateAdImg(pAdImg))
                {
                    return RedirectToAction("index");
                }
                ViewBag.error = "خطا در انجام عملیات ویرایش ! ";
            }
            return View(pAdImg);
        }

        public ActionResult RemoveAdImg(int pId)
        {

            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("Login", "LoginForm");
            }
            mAdImg vAdImg = new mAdImg();
            if (n.fDeleteAdImg(pId))
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