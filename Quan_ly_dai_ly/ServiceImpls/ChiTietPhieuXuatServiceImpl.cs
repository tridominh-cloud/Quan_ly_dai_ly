
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Quan_ly_dai_ly.Services;

namespace Quan_ly_dai_ly.ServiceImpls;

public class ChiTietPhieuXuatServiceImpl : IChiTietPhieuXuatService
{
    private readonly IChiTietPhieuXuatRepository _chiTietPhieuXuatRepository;
    public ChiTietPhieuXuatServiceImpl(IChiTietPhieuXuatRepository chiTietPhieuXuatRepository)
    {
        _chiTietPhieuXuatRepository = chiTietPhieuXuatRepository;
    }

    public async Task<IEnumerable<ChiTietPhieuXuat>> GetAllChiTietPhieuXuatsAsync()
    {
        return await _chiTietPhieuXuatRepository.GetAllChiTietPhieuXuatsAsync();
    }
    public async Task<int> AddChiTietPhieuXuatAsync(ChiTietPhieuXuat newChiTietPhieuXuat)
    {
        return await _chiTietPhieuXuatRepository.AddChiTietPhieuXuatAsync(newChiTietPhieuXuat);
    }
    public async Task<int> GetNextAvailableIdAsync()
    {
        return await _chiTietPhieuXuatRepository.GetNextAvailableIdAsync();
    }
}
