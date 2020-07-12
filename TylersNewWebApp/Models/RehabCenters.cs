using System;
using System.Collections.Generic;

namespace TylersNewWebApp.Models
{
    public class RehabCenters
    {
        public RehabCenters()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set;}
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Specialty { get; set; }
        public string SpecialtyID { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
