using Stayzee.Domain.Entities;
using System.Linq.Expressions;

namespace Stayzee.Application.RepositoryContract
{
    public interface IVillaRepository
    {
        Task<IEnumerable<Villa>> GetAllAsync(Expression<Func<Villa, bool>>? filter,string[]? includeProperties = null);
        Task<Villa> GetAsync(Expression<Func<Villa, bool>> filter,string[]? includeProperties = null);
        Task<bool> AddVillaAsync(Villa villa);
        Task<bool> UpdateVillaAsync(Villa villa);
        Task<bool> DeleteVillaAsync(Villa villa);
    }
}
