using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReportProject.DataService.Data;
using ReportProject.DataService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportProject.DataService.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {

        public readonly ILogger logger;
        protected AppDbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(ILogger logger, AppDbContext context)
        {
            this.logger = logger;
            this._context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity, CancellationToken cancellationToken)
        {
          
          await _dbSet.AddAsync(entity, cancellationToken);
          return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
                return   await _dbSet.ToListAsync();
        }

        public virtual async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();

        }

        public virtual async Task<T?> GetById(Guid id)
        {

            return await _dbSet.FindAsync(id);

        }

        public virtual Task<bool> Update(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
