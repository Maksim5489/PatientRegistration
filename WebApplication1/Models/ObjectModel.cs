using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ObjectModel
    {
        public IEnumerable<ZayavkiModels> ZayavkiModels { get; set; }

        public IEnumerable<DoctorModels> DoctorModels { get; set; }
    }
}