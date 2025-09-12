using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.RepositoryInterfaces;

public interface ILoaiDaiLyRepository
{
    Task<IEnumerable<LoaiDaiLy>> GetAllLoaiDaiLiesAsync();
    Task<int> CountQuanInLoaiDaiLy(int maLoaiDaiLy);
}