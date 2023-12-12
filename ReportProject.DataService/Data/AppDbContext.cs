using Microsoft.EntityFrameworkCore;
using ReportProject.Entities.Models;
using ReportProject.Entities.Models.Authorization;

namespace ReportProject.DataService.Data
{
    public class AppDbContext :DbContext
    {

        public DbSet<Person> Persons { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
