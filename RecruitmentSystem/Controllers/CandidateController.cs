using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RecruitmentSystem.Models;
using System;
using System.Web.Mvc;

namespace RecruitmentSystem.Controllers
{
    public class CandidateController : Controller
    {
        CandidateDbContext db;
        UserStore<Candidate> us;
        UserManager<Candidate> um;


        public CandidateController()
        {
            db = new CandidateDbContext();
            us = new UserStore<Candidate>(db);
            um = new UserManager<Candidate>(us);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Candidate c)
        {        
            Candidate exC = um.Find(c.UserName, c.password);
            if (exC != null) 
            {
                //FormsAuthentication.SetAuthCookie(c.UserName, false);
                return RedirectToAction("Dashboard",exC);
            }
            else
            {
                ModelState.AddModelError("UserName", "Username isn't found!!!");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Candidate c)
        {
            try
            {
                IdentityResult res = um.Create(c, c.password);
                if (res.Succeeded)
                {
                    return View("Login");
                }
                else
                {
                    ModelState.AddModelError("UserName", "Username isn't found!!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }

        public ActionResult Dashboard()
        {
            return View() ;
        }
    }
}