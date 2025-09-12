using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.Services;

public interface IPhieuXuatService
{
    Task<IEnumerable<PhieuXuat>> GetAllPhieuXuatsAsync();
    Task<int> AddPhieuXuatAsync(PhieuXuat newPhieuXuat);
    Task<int> GetNextAvailableIdAsync();
}
