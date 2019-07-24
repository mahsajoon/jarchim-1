using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jarchim.da;
using Jarchim.Models;
using Jarchim.Models.database;

namespace Jarchim.Controllers
{
    public class mContactController : Controller
    {
        // GET: mContact
        daContactUs c = new daContactUs();
        JarchimDb Db = new JarchimDb();
        static int pSkip = 0;
        static int pGet = 10;
        // GET: mContactUs
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
            mContact vContact = new mContact();
            List<mContact> aContact = new List<mContact>();
            aContact = c.fAboutUsList(pGet, pSkip);
            return View(aContact);
        }
        public ActionResult fGetPage(int pPageNum, string pAction)
        {
            pSkip = (pPageNum - 1) * pGet;
            return RedirectToAction(pAction);
        }

        public ActionResult RemoveContact(int pId)
        {

            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("Login", "LoginForm");
            }
            if (c.fDeleteContact(pId))
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