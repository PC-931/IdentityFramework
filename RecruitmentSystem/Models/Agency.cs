﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace RecruitmentSystem.Models
{
    public class Agency : IdentityUser
    {
        public string password { get; set; }
    }
}