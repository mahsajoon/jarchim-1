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
    public class mCategoryController : Controller
    {
        // GET: mCategory
        damCategory c = new damCategory();
        JarchimDb Db = new JarchimDb();
        // GET: mCategory

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
            List<mCategory> aCategory = new List<mCategory>();
            aCategory = c.fCategoryList();
            ViewBag.title = "فهرست  مجموعه ها";
            return View(aCategory);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");

            }
            mCategory vCat = new mCategory();
            ViewBag.title = "مجموعه جدید ";
            return View(vCat);
        }

        //[HttpPost]
        //public ActionResult Create(mCategory pCat)
        //{
        //    if (fUserControl() == 0)
        //    {
        //        ViewBag.Message = "شما وارد سایت نشده اید...";
        //        return RedirectToAction("LoginForm", "Login");

        //    }
        //    ViewBag.title = "مجموعه جدید ";
        //    if (!(ModelState.IsValid))
        //    {
        //        ViewBag.error = "خطا در  اطلاعات ورودی !";
        //        return View(pCat);

        //    }
        //    if (c.InsertCategory(pCat))
        //    {
        //        return RedirectToAction("index");
        //    }
        //    ViewBag.error = "خطا در انجام عملیات درج ! ";
        //    return View(pCat);
        //}

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(mCategory pCat)
        {
            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");

            }
            ViewBag.title = "مجموعه جدید ";
            if (!(ModelState.IsValid))
            {
                ViewBag.error = "خطا در  اطلاعات ورودی !";
                return View(pCat);

            }
            else
            {
                if (pCat.img_file1 != null && pCat.img_file1.ContentLength > 0)
                {
                    if (pCat.img_file1.ContentLength < 10485760)
                    {
                        Random rnd1 = new Random();
                        string img1 = rnd1.Next().ToString() + ".jpg";
                        string Path1 = System.IO.Path.Combine(Server.MapPath("~/images/category/"));
                        pCat.img_file1.SaveAs(Path1 + img1);

                        using (MemoryStream ms1 = new MemoryStream())
                        {
                            pCat.img_file1.InputStream.CopyTo(ms1);
                            byte[] array = ms1.GetBuffer();
                            pCat.cat_baner_img = img1;
                        }

                    }
                    else
                    {
                        ViewBag.error = "حد اکثر اندازه فایل را رعایت نکرده اید !";
                        return View(pCat);
                    }
                }
                if (pCat.img_file2 != null && pCat.img_file2.ContentLength > 0)
                {
                    if (pCat.img_file2.ContentLength < 10485760)
                    {

                        Random rnd2 = new Random();
                        string img2 = rnd2.Next().ToString() + ".svg";
                        string Path2 = System.IO.Path.Combine(Server.MapPath("~/images/category/"));
                        pCat.img_file2.SaveAs(Path2 + img2);
                        using (MemoryStream ms2 = new MemoryStream())
                        {
                            pCat.img_file2.InputStream.CopyTo(ms2);
                            byte[] array = ms2.GetBuffer();
                            pCat.cat_icon_img = img2;
                        }
                    }
                    else
                    {
                        ViewBag.error = "حد اکثر اندازه فایل را رعایت نکرده اید !";
                        return View(pCat);
                    }
                }
                else
                {
                    ViewBag.error = "فایلی جهت آپلود انتخاب نشده است ";
                    return View(pCat);
                }
                if (c.InsertCategory(pCat))
                {
                    return RedirectToAction("index");
                }
                ViewBag.error = "خطا در انجام عملیات درج ! ";
            }
            return View(pCat);
        }


        [HttpGet]
        public ActionResult Edit(int pId)
        {

            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");
            }
            ViewBag.title = "ویرایش مجموعه";
            mCategory vCat = new mCategory();
            vCat.cat_id = pId;
            vCat = c.fGetCategory(vCat);
            return View(vCat);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(mCategory pCat)
        {
            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("LoginForm", "Login");
            }
            ViewBag.title = "ویرایش مجموعه";
            if (!(ModelState.IsValid))
            {
                ViewBag.error = "خطا در  اطلاعات ورودی !";
                return View(pCat);

            }
            else
            {
                if (pCat.img_file1 != null && pCat.img_file1.ContentLength > 0)
                {
                    if (pCat.img_file1.ContentLength < 10485760)
                    {
                        Random rnd1 = new Random();
                        string img1 = rnd1.Next().ToString() + ".jpg";
                        string Path1 = System.IO.Path.Combine(Server.MapPath("~/images/category/"));
                        pCat.img_file1.SaveAs(Path1 + img1);

                        using (MemoryStream ms1 = new MemoryStream())
                        {
                            pCat.img_file1.InputStream.CopyTo(ms1);
                            byte[] array = ms1.GetBuffer();
                            pCat.cat_baner_img = img1;
                        }

                    }
                    else
                    {
                        ViewBag.error = "حد اکثر اندازه فایل را رعایت نکرده اید !";
                        return View(pCat);
                    }
                }
                if (pCat.img_file2 != null && pCat.img_file2.ContentLength > 0)
                {
                    if (pCat.img_file2.ContentLength < 10485760)
                    {

                        Random rnd2 = new Random();
                        string img2 = rnd2.Next().ToString() + ".svg";
                        string Path2 = System.IO.Path.Combine(Server.MapPath("~/images/category/"));
                        pCat.img_file2.SaveAs(Path2 + img2);
                        using (MemoryStream ms2 = new MemoryStream())
                        {
                            pCat.img_file2.InputStream.CopyTo(ms2);
                            byte[] array = ms2.GetBuffer();
                            pCat.cat_icon_img = img2;
                        }
                    }
                    else
                    {
                        ViewBag.error = "حد اکثر اندازه فایل را رعایت نکرده اید !";
                        return View(pCat);
                    }
                }
                //else
                //{
                //    ViewBag.error = "فایلی جهت آپلود انتخاب نشده است ";
                //    return View(pCat);
                //}
                if (c.fUpdateCategory(pCat))
                {
                    return RedirectToAction("index");
                }
                ViewBag.error = "خطا در انجام عملیات ویرایش ! ";
                return View(pCat);
            }
        }

        public ActionResult RemoveCategory(int pId)
        {

            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("Login", "LoginForm");
            }
            if (c.fDeleteCategory(pId))
            {
                return Json(pId, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.Message = "خطا در انجام عملیات حذف...";
                return Json(pId, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
