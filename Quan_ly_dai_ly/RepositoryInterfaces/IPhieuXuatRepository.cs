using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.RepositoryInterfaces;

public interface IPhieuXuatRepository
{
    Task<IEnumerable<PhieuXuat>> GetAllPhieuXuatsAsync();
    Task<int> AddPhieuXuatAsync(PhieuXuat newPhieuXuat);
    Task<int> GetNextAvailableIdAsync();
}
