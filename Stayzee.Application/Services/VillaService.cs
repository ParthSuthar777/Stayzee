using Stayzee.Application.RepositoryContract;
using Stayzee.Application.ServiceContract;
using Stayzee.Domain.Entities;

namespace Stayzee.Application.Services
{
    public class VillaService : IVillaService
    {
        private readonly IVillaRepository _villaRepository;

        public VillaService(IVillaRepository villaRepository)
        {
            _villaRepository = villaRepository;
        }
        public async Task<IEnumerable<Villa>> GetAllAsync()
        {
            return await _villaRepository.GetAllAsync(null);
        }

        public async Task<Villa> GetAsync(int villaId)
        {
            return await _villaRepository.GetAsync(x => x.Id == villaId, null);
        }
        public async Task<bool> AddVillaAsync(Villa villa)
        {
            return await _villaRepository.AddVillaAsync(villa);
        }

        public async Task<bool> DeleteVillaAsync(int villaId)
        {
            var villa = await _villaRepository.GetAsync(x => x.Id == villaId, null);
            if (villa == null)
            {
                return false;
            }
            return await _villaRepository.DeleteVillaAsync(villa);
        }

        public async Task<bool> UpdateVillaAsync(Villa villa)
        {
            return await _villaRepository.UpdateVillaAsync(villa);
        }
    }
}
