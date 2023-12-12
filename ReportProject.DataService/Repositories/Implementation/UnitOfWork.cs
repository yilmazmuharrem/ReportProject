using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReportProject.DataService.Data;
using ReportProject.DataService.Repositories.Interfaces;
using ReportProject.Entities.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportProject.DataService.Repositories.Implementation
{
    public class UnitOfWork:IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public IPersonRepository Persons { get; }

        public IReportRepository Reports { get; }

        public IUserRepository Users { get; }
       
        public UnitOfWork(AppDbContext context, ILoggerFactory logger)
        {
            _context = context;
            var _logger = logger.CreateLogger("logs");
            
            
            Persons = new PersonRepository(_logger, _context);
            Reports = new ReportRepository(_logger, _context);
            Users = new UserRepository(_logger, _context);
        }

        public async Task<bool> CompleteAsync(CancellationToken cancellationToken)
        {
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
