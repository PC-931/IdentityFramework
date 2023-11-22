using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RecruitmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RecruitmentSystem.Controllers
{
    public class CandidateController : Controller
    {
        CandidateDbContext db;
        UserStore<Candidate> us;
        UserManager<Candidate> um;

        public VacancyDbContext vacDb;
        public ApplicantDbContext appDb;
        public Applicant app;
        public CandidateController()
        {
            db = new CandidateDbContext();
            us = new UserStore<Candidate>(db);
            um = new UserManager<Candidate>(us);

            vacDb = new VacancyDbContext();
            appDb = new ApplicantDbContext();

            app = new Applicant();
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
                Session["cid"] = exC.Id;
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
                    return RedirectToAction("Login");
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

        public ActionResult Dashboard(Candidate c)
        {
            return View(c) ;
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Candidate");
        }

        public ActionResult ShowVacancyToCandidate()
        {
            try
            {
                List<Vacancy> v = new List<Vacancy> ();
                v = vacDb.vacancies.ToList();

                if(v.Count > 0)
                {
                    return View(v);
                }
                else
                {
                    TempData["err"] = "some Error occured!!!";
                }
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public ActionResult CandidateApplied(int id)
        {
            try
            {                
                app.CandidateId = Session["cid"].ToString();
                app.VacancyId = id;
                app.Status = "Applied";

                appDb.applicants.Add(app);
                appDb.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}