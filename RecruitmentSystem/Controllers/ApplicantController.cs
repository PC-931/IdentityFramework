﻿using RecruitmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitmentSystem.Controllers
{
    public class ApplicantController : Controller
    {
        private ApplicantDbContext db;
        List<Applicant> applicants;
        Applicant a;


        public ApplicantController()
        {
            db = new ApplicantDbContext();
            applicants = new List<Applicant>();
            a = new Applicant();
        }

        public ActionResult ShowAllApplicant()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult AppliedByCandidate(int cid)
        //{
        //    try
        //    {

        //        return View();
        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return View(cid);
        //}
    }
}