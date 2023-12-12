using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReportProject.DataService.Data;
using ReportProject.DataService.Repositories.Interfaces;
using ReportProject.Entities.Models;


namespace ReportProject.DataService.Repositories.Implementation
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }


        public override async Task<IEnumerable<Person>> All()
        {
            try
            {
                return await _dbSet
                    .Include(x => x.Reports.Where(a=>a.Status==1 && a.IsActive==true)) 
                    .Where(x => x.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e, "All fonksiyonunda hata var.", typeof(PersonRepository));
                throw;
            }
        }


        public override async Task<bool> Update(Person person, CancellationToken cancellationToken)
        {

            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == person.Id, cancellationToken);

                if (result == null) return false;


                result.UpdatedDate = DateTime.UtcNow;
                result.Name = person.Name;
                result.Surname = person.Surname;
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Update fonksiyonunda hata var.", typeof(PersonRepository));

                throw;
            }


        }


        public override async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
                if (result == null) return false;

                result.Status = 0;
                result.UpdatedDate = DateTime.UtcNow;
                return true;

            }
            catch (Exception e)
            {
                logger.LogError(e, "Delete fonksiyonunda hata var.", typeof(PersonRepository));

                throw;
            }
        }


    }
}
