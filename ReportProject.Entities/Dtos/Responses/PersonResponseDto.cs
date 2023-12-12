using ReportProject.Entities.Models;


namespace ReportProject.Entities.Dtos.Responses
{
    public class PersonResponseDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public List<Report>? Reports { get; set; }
    }
}
