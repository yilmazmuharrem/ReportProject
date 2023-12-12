
namespace ReportProject.DataService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
 

        public IPersonRepository Persons { get; }

        public IReportRepository Reports { get; }

        public IUserRepository Users { get; }

        Task<bool> CompleteAsync(CancellationToken cancellationToken);
    }
}
