using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReportProject.DataService.Data;
using ReportProject.DataService.Repositories.Interfaces;
using ReportProject.Entities.Models;


namespace ReportProject.DataService.Repositories.Implementation
{
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {
        private readonly AppDbContext appDbContext;
        public ReportRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
            appDbContext = context;
        }

        public override async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
          var result = await _dbSet.FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
            if (result != null)
            {
                result.UpdatedDate = DateTime.UtcNow;
                result.IsActive = false;
                result.Status = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override async Task<bool> Update(Report report, CancellationToken cancellationToken)
        {

            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == report.Id, cancellationToken);

                if (result == null) return false;


                result.UpdatedDate = DateTime.UtcNow;
                result.Description = report.Description;
                result.BeginningTime = report.BeginningTime;
                result.FinishTime = report.FinishTime;
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Update fonksiyonunda hata var.", typeof(ReportRepository));

                throw;
            }


        }


    }
}
