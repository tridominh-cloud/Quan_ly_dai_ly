using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Quan_ly_dai_ly.Services;

namespace Quan_ly_dai_ly.ServiceImpls;

public class PhieuXuatServiceImpl : IPhieuXuatService
{
    private readonly IPhieuXuatRepository _phieuXuatRepository;
    public PhieuXuatServiceImpl(IPhieuXuatRepository phieuXuatRepository)
    {
        _phieuXuatRepository = phieuXuatRepository;
    }

    public async Task<IEnumerable<PhieuXuat>> GetAllPhieuXuatsAsync()
    {
        return await _phieuXuatRepository.GetAllPhieuXuatsAsync();
    }

    public async Task<int> AddPhieuXuatAsync(PhieuXuat newPhieuXuat)
    {
        return await _phieuXuatRepository.AddPhieuXuatAsync(newPhieuXuat);
    }
    public async Task<int> GetNextAvailableIdAsync()
    {
        return await _phieuXuatRepository.GetNextAvailableIdAsync();
    }
}
