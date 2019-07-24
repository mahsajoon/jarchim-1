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
    public class mSlideController : Controller
    {
        // GET: mSlide
        daLogin l = new daLogin();
        daSlide s = new daSlide();
        JarchimDb Db = new JarchimDb();
        // GET: mSlide
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
            List<mSlider> aSlider = new List<mSlider>();
            aSlider = s.fSliderList();
            ViewBag.title = "فهرست تصاویر";
            return View(aSlider);

        }

        [HttpGet]
        public ActionResult Create()
        {
            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");
            }
            mSlider vSlider = new mSlider();
            ViewBag.title = "تصویر جدید ";
            return View(vSlider);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(mSlider pSlider)
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
                return View(pSlider);

            }
            else
            {
                if (pSlider.img_file != null && pSlider.img_file.ContentLength > 0)
                {
                    if (pSlider.img_file.ContentLength < 10485760)
                    {
                        Random rnd = new Random();
                        string img = rnd.Next().ToString() + ".jpg";
                        string Path = System.IO.Path.Combine(Server.MapPath("~/images/slider/"));
                        pSlider.img_file.SaveAs(Path + img);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pSlider.img_file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            pSlider.slider_img = img;
                        }
                    }
                    else
                    {
                        ViewBag.error = "حد اکثر اندازه فایل را رعایت نکرده اید !";
                        return View(pSlider);
                    }
                }
                else
                {
                    ViewBag.error = "فایلی جهت آپلود انتخاب نشده است ";
                    return View(pSlider);
                }
                if (s.InsertSlider(pSlider))
                {
                    return RedirectToAction("index");
                }
                ViewBag.error = "خطا در انجام عملیات درج ! ";
            }
            return View(pSlider);
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
            mSlider vSlider = new mSlider();
            vSlider.slider_id = pId;
            vSlider = s.fGetSlider(vSlider);
            return View(vSlider);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(mSlider pSlider)
        {
            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");
            }
            ViewBag.title = "ویرایش فایل";
            if (!(ModelState.IsValid))
            {
                ViewBag.error = "خطا در  اطلاعات ورودی !";
                return View(pSlider);

            }
            else
            {
                if (pSlider.img_file != null && pSlider.img_file.ContentLength > 0)
                {
                    if (pSlider.img_file.ContentLength < 10485760)
                    {
                        Random rnd = new Random();
                        string img = rnd.Next().ToString() + ".jpg";
                        string Path = System.IO.Path.Combine(Server.MapPath("~/images/slider/"));
                        pSlider.img_file.SaveAs(Path + img);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pSlider.img_file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            pSlider.slider_img = img;
                        }
                    }
                    else
                    {
                        ViewBag.error = "حد اکثر اندازه فایل را رعایت نکرده اید !";
                        return View(pSlider);
                    }
                }
                if (s.fUpdateSlider(pSlider))
                {
                    return RedirectToAction("index");
                }
                ViewBag.error = "خطا در انجام عملیات ویرایش ! ";
            }
            return View(pSlider);
        }

        public ActionResult RemoveSlider(int pId)
        {

            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("Login", "LoginForm");
            }
            mSlider vSlider = new mSlider();
            if (s.fDeleteSlider(pId))
            {
                return Json(pId, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(pId, JsonRequestBehavior.AllowGet);
            }
        }
    }
}