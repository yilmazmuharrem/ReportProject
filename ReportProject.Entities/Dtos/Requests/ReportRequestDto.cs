

namespace ReportProject.Entities.Dtos.Requests
{
    public class ReportRequestDto
    {
        public Guid PersonId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime BeginningTime { get; set; } = DateTime.UtcNow;
        public DateTime FinishTime { get; set; } = DateTime.UtcNow;
        
    }
}
