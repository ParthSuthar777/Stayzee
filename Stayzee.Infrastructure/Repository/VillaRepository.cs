using Microsoft.EntityFrameworkCore;
using Stayzee.Application.RepositoryContract;
using Stayzee.Domain.Entities;
using Stayzee.Infrastructure.Data;
using System.Collections.Immutable;
using System.IO.MemoryMappedFiles;
using System.Linq.Expressions;

namespace Stayzee.Infrastructure.Repository
{
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public VillaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Villa>> GetAllAsync(Expression<Func<Villa, bool>>? filter, string[]? includeProperties = null)
        {
            IQueryable<Villa> query = _dbContext.Villas;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var include in includeProperties)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<Villa> GetAsync(Expression<Func<Villa, bool>> filter, string[]? includeProperties = null)
        {
            IQueryable<Villa> query = _dbContext.Villas;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var include in includeProperties)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync();
        }


        public async Task<bool> AddVillaAsync(Villa villa)
        {
            await _dbContext.Villas.AddAsync(villa);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVillaAsync(Villa villa)
        {
            _dbContext.Villas.Remove(villa);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateVillaAsync(Villa villa)
        {
            _dbContext.Villas.Update(villa);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
