using RecruitmentSystem.Models;
using System.Web.Mvc;

namespace RecruitmentSystem.Controllers
{
    [Authorize]
    public class VacancyController : Controller
    {

        public VacancyDbContext db;
        public VacancyController() 
        { 
            db = new VacancyDbContext();
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
            return View();
        }

    }
}