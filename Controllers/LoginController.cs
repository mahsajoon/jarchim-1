using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jarchim.da;
using Jarchim.Models;
namespace Jarchim.Controllers
{
    public class LoginController : Controller
    {
        daLogin l = new daLogin();
        // GET: Login
        public ActionResult LoginForm()
        {
            ViewBag.error = "";
            return View("Index");
        }

        public ActionResult CheckLogin(mUser pUsers)
        {
            ViewBag.title = "فرم ورود";
            if (pUsers.user_email == "" || pUsers.user_pass == "")
            {
                ViewBag.error = "تکمیل فیلد ها الزامی است !";
                return View("Index", pUsers);
            }
            else
            {
                if (l.CheckLogin(pUsers.user_email, pUsers.user_pass))
                {
                    Session["user_email"] = pUsers.user_email;
                    Session["user_pass"] = pUsers.user_pass;
                    return RedirectToAction("welcome", "Admin");
                }
                else
                {
                    ViewBag.Message = "نام کاربری یا کلمه عبور اشتباه است.";
                    return View("LoginForm");
                }
            }
        }
    }
}