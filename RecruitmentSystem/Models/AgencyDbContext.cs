using Microsoft.AspNet.Identity.EntityFramework;

namespace RecruitmentSystem.Models
{
    public class AgencyDbContext : IdentityDbContext<Agency>
    {
        public AgencyDbContext() : base("HireIN") 
        { 
        
        }
    }
}