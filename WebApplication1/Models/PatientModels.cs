using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PatientModels
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string FIO { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string Policy_number { get; set; }
        public string PassportID { get; set; }
        public string Job { get; set; }
        public string Disability { get; set; }
        public string Chronic_diseases { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
    }
}