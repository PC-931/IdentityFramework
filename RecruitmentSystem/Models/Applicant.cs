using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        public int CandidateId { get; set; }

        public int VacancyId { get; set; }

        public string Status { get; set; }
    }
}