﻿using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.Models
{
    public class Vacancy
    {
        [Key]
        public int id {  get; set; }
        public string AgentId {  get; set; } 
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobLocation { get; set; }
        public decimal Salary { get; set; }

    }
}