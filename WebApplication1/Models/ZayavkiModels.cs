using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Models
{
    public class ZayavkiModels
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FIO { get; set; }
        public string DocFIO { get; set; }

        [DisplayName("Doctor")]
        public string Qualification { get; set; }
        public string Doctor { get; set; }
        public string Recept { get; set; }
        public string Policy_number { get; set; }
        public string EmailZ { get; set; }
        public string EmailQ { get; set; }
        public string Disease { get; set; }
        public SelectList DropDownList { get; set; }
    }
    

}