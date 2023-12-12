

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReportProject.DataService.Data;
using ReportProject.DataService.Repositories.Interfaces;
using ReportProject.Entities.Models;
using ReportProject.Entities.Models.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReportProject.DataService.Repositories.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
    

        public UserRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
           
        }

        public async Task<User> Login(User user, CancellationToken cancellationToken)
        {

            try
            {
                var _user = await _dbSet.FirstOrDefaultAsync(a => a.UserName == user.UserName, cancellationToken);

                return _user;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Login fonksiyonunda hata var.", typeof(UserRepository));
                throw;
            }



            //var _user = await _dbSet.FirstOrDefaultAsync(a => a.UserName == user.UserName, cancellationToken);
            //return _user;



        }

     
    }
}
