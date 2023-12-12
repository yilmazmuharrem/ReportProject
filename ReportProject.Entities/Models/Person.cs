using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportProject.Entities.Models
{
    public class Person : Entity
    {
        public Person()
        {
            Reports = new List<Report>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Report> Reports { get; set; }

    }
}
