using RecruitmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace RecruitmentSystem.Controllers
{
    public class VacancyController : Controller
    {
        List<Vacancy> vacancyList;
        Vacancy v;
        public VacancyDbContext db;

        public VacancyController() 
        { 
            db = new VacancyDbContext();
            vacancyList = new List<Vacancy>();
            v = new Vacancy();
        }

        [HttpGet]
        public ActionResult AddVacancy()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddVacancy(Vacancy v)
        {
            db.vacancies.Add(v);
            db.SaveChanges();
            return RedirectToAction("ShowAllVacancy");
        }

        public ActionResult ShowAllVacancy()
        {
            try
            {
                vacancyList = db.vacancies.ToList();
                if(vacancyList.Count > 0 )
                {
                    return View(vacancyList);
                }
                else
                {
                    return RedirectToAction("Dashboard","Agency");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        [HttpGet]
        public ActionResult EditVacancy(int id)
        {
            try
            {
                v = db.vacancies.Find(id);
                if( v!=null)
                {
                    return View(v);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditVacancy(Vacancy updVacancy)
        {
            try
            {
                v = db.vacancies.Find(updVacancy.id);
                if (v != null)
                {
                    db.vacancies.AddOrUpdate(updVacancy);
                    db.SaveChanges();
                    return View("ShowAllVacancy");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            return View();
        }

        public ActionResult DetailsOfVacancy(int id)
        {
            try
            {
                v = db.vacancies.Find(id);
                if( v!=null )
                {
                    return View(v);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }
        
        public ActionResult DeleteVacancy(int id)
        {
            try
            {
                v = db.vacancies.Find(id);
                if(v!=null )
                {
                    db.vacancies.Remove(v);
                    db.SaveChanges();
                    return RedirectToAction("ShowAllVacancy");
                }
            }
            catch(Exception e)
            {
                throw new Exception (e.Message);
            }
            return RedirectToAction("ShowAllVacancy");
        }
    }
}