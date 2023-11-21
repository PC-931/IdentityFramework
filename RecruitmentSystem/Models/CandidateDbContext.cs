using Microsoft.AspNet.Identity.EntityFramework;

namespace RecruitmentSystem.Models
{
    public class CandidateDbContext : IdentityDbContext<Candidate>
    {
        public CandidateDbContext() : base("HireIN")
        {
            
        }
    }
}