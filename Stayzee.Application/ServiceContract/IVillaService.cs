using Stayzee.Domain.Entities;
using System.Linq.Expressions;

namespace Stayzee.Application.ServiceContract
{
    public interface IVillaService
    {
        Task<IEnumerable<Villa>> GetAllAsync();
        Task<Villa> GetAsync(int villaId);
        Task<bool> AddVillaAsync(Villa villa);
        Task<bool> UpdateVillaAsync(Villa villa);
        Task<bool> DeleteVillaAsync(int villaId);
    }
}
