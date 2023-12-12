

namespace ReportProject.Entities.Dtos.Requests
{
    public class UpdateReportDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Description { get; set; } = string.Empty;
        public DateTime BeginningTime { get; set; } = DateTime.UtcNow;
        public DateTime FinishTime { get; set; } = DateTime.UtcNow;
    }
}
