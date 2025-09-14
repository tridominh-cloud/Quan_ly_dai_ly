using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.Services;

public interface IChiTietPhieuXuatService
{
    Task<IEnumerable<ChiTietPhieuXuat>> GetAllChiTietPhieuXuatsAsync();
    Task<int> AddChiTietPhieuXuatAsync(ChiTietPhieuXuat newChiTietPhieuXuat);
    Task<int> GetNextAvailableIdAsync();
}
