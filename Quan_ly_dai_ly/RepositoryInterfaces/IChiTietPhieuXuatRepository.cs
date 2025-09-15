
using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.RepositoryInterfaces;

public interface IChiTietPhieuXuatRepository
{
    Task<IEnumerable<ChiTietPhieuXuat>> GetAllChiTietPhieuXuatsAsync();
    Task<int> AddChiTietPhieuXuatAsync(ChiTietPhieuXuat newChiTietPhieuXuat);
    Task<int> GetNextAvailableIdAsync();
}
