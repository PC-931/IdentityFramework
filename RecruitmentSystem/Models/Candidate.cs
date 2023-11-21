using Microsoft.AspNet.Identity.EntityFramework;

namespace RecruitmentSystem.Models
{
    public class Candidate : IdentityUser
    {
        public string password { get; set; }
    }
}