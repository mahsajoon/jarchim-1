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
    public class mCommentstController : Controller
    {
        // GET: mContact
        daComments c = new daComments();
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
            List<mComment> aComment = new List<mComment>();
            aComment = c.fCommentList(pGet, pSkip);
            return View(aComment);
        }
        public ActionResult fGetPage(int pPageNum, string pAction)
        {
            pSkip = (pPageNum - 1) * pGet;
            return RedirectToAction(pAction);
        }

        public ActionResult RemoveComment(int pId)
        {

            if (fUserControl() == 0)
            {
                ViewBag.Message = "شما وارد سایت نشده اید...";
                return RedirectToAction("Login", "LoginForm");
            }
            if (c.fDeleteComment(pId))
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