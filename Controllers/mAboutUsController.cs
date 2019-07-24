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
    public class mAboutUsController : Controller
    {
        static int pGet = 15;
        static int pSkip = 0;
        daAboutUs a = new daAboutUs();
        JarchimDb Db = new JarchimDb();
        // GET: mAboutUs
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
        public ActionResult Index()
        {
            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");

            }
            List<mAbout> aAboutUs = new List<mAbout>();
            aAboutUs = a.fAboutList(pGet, pSkip);
            ViewBag.title = "";
            return View(aAboutUs);
        }

        [HttpGet]
        public ActionResult Create()
        {

            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");
            }
            ViewBag.title = "";
            mAbout vAboutUs = new mAbout();
            return View(vAboutUs);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(mAbout pAboutUs)
        {

            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");
            }
            ViewBag.title = "";
            if (!(ModelState.IsValid))
            {
                ViewBag.error = "خطا در  اطلاعات ورودی !";
                return View(pAboutUs);
            }
            else
            {
                if (pAboutUs.img_file != null && pAboutUs.img_file.ContentLength > 0)
                {
                    if (pAboutUs.img_file.ContentLength < 10485760)
                    {
                        Random rnd = new Random();
                        string img = rnd.Next().ToString() + ".jpg";
                        string Path = System.IO.Path.Combine(Server.MapPath("~/images/about/"));
                        pAboutUs.img_file.SaveAs(Path + img);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pAboutUs.img_file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            pAboutUs.about_us_img = img;
                        }
                    }
                    else
                    {
                        ViewBag.error = "حد اکثر اندازه فایل را رعایت نکرده اید !";
                        return View(pAboutUs);
                    }
                }
                else
                {
                    ViewBag.error = "فایلی جهت آپلود انتخاب نشده است ";
                    return View(pAboutUs);
                }
                if (a.InsertAbout(pAboutUs))
                {
                    return View(pAboutUs);
                }
                ViewBag.error = "خطا در انجام عملیات ویرایش ! ";
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult AboutUs(int pId)
        {

            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");
            }
            ViewBag.title = "ویرایش ";
            mAbout vAboutUs = new mAbout();
            vAboutUs.about_us_id = pId;
            vAboutUs = a.fGetAboutUs(vAboutUs);
            return View(vAboutUs);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AboutUs(mAbout pAboutUs)
        {
            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");
            }
            ViewBag.title = "";
            if (!(ModelState.IsValid))
            {
                ViewBag.error = "خطا در  اطلاعات ورودی !";
                return View(pAboutUs);
            }
            else
            {
                if (pAboutUs.img_file != null && pAboutUs.img_file.ContentLength > 0)
                {
                    if (pAboutUs.img_file.ContentLength < 10485760)
                    {
                        Random rnd = new Random();
                        string img = rnd.Next().ToString() + ".jpg";
                        string Path = System.IO.Path.Combine(Server.MapPath("~/images/about/"));
                        pAboutUs.img_file.SaveAs(Path + img);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pAboutUs.img_file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            pAboutUs.about_us_img = img;
                        }
                    }
                    else
                    {
                        ViewBag.error = "حد اکثر اندازه فایل را رعایت نکرده اید !";
                        return View(pAboutUs);
                    }
                }
                //else
                //{
                //    ViewBag.error = "فایلی جهت آپلود انتخاب نشده است ";
                //    return View(pAboutUs);
                //}
                if (a.fUpdatemficoStory(pAboutUs))
                {
                    return View(pAboutUs);
                }
                ViewBag.error = "خطا در انجام عملیات ویرایش ! ";
            }
            return View(pAboutUs);
        }

    }
}