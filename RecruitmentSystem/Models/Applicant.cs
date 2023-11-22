using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.Models
{
    public class Applicant
    {
        [Key]
        public int id { get; set; }
        public string CandidateId { get; set; }
        public int VacancyId { get; set; }
        public string Status { get; set; }
    }
}