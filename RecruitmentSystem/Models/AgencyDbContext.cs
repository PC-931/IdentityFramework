using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitmentSystem.Models
{
    public class AgencyDbContext : IdentityDbContext<Agency>
    {
        public AgencyDbContext() : base("NewDB") 
        { 
        
        }
    }
}