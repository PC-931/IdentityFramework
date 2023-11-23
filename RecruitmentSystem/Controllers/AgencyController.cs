using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RecruitmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace RecruitmentSystem.Controllers
{
    public class AgencyController : Controller
    {
        private AgencyDbContext db;
        private UserStore<Agency> us;
        private UserManager<Agency> um;
        public ApplicantDbContext appDb;
        public List<Applicant> appList;
        public AgencyController()
        {
            db = new AgencyDbContext();
            us = new UserStore<Agency>(db);
            um = new UserManager<Agency>(us);
            appDb = new ApplicantDbContext();
            appList = new List<Applicant>();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Agency a)
        {
            Agency usr = um.Find(a.UserName, a.password);
            if (usr != null)
            {
                Session["aid"] = a.Id;
                //FormsAuthentication.SetAuthCookie(a.UserName, false);
                return RedirectToAction("Dashboard", a);
            }
            else
            {
                ModelState.AddModelError("UserName", "Error while login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Agency a)
        {
            IdentityResult res = um.Create(a, a.password);
            if(res.Succeeded)
            {
                return View("Login");
            }
            else
            {
                ModelState.AddModelError("UserName", "Error while registering");

            }
            return View();
        }

        //[Authorize]
        [HttpGet]
        public ActionResult Dashboard(Agency a)
        {
            return View(a);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            //FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        

        public ActionResult ShowAllApplicant()
        {
            try
            {
                appList = appDb.applicants.ToList();
                if(appList.Count > 0)
                {
                    return View(appList);
                }
                else
                {
                    TempData["err"] = "error occured";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(appList); ;
        }

        public ActionResult CandidateAccepted(int id)
        {
            try
            {
                Applicant res = appDb.applicants.Find(id);
                if( res != null)
                {
                    res.Status = "Selected";
                    appDb.SaveChanges();
                }
                else
                {
                    TempData["err"] = "Applicant Id isn't found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RedirectToAction("ShowAllApplicant");
        }
    }
}