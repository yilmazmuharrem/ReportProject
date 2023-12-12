using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportProject.Entities.Models
{
    public class Report : Entity
    {
        public string Description { get; set; } = string.Empty;
        public DateTime BeginningTime { get; set; } = DateTime.UtcNow;
        public DateTime FinishTime { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }

        public Guid PersonId { get; set; }
    }
}
