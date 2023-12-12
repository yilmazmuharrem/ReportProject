using ReportProject.Entities.Models.Authorization;


namespace ReportProject.DataService.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {

        Task<User> Login(User user,CancellationToken cancellationToken);
    }
}
