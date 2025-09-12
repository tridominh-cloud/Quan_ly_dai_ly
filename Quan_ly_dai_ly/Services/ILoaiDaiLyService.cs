using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.Services;

public interface ILoaiDaiLyService
{
	Task<IEnumerable<LoaiDaiLy>> GetAllLoaiDaiLiesAsync();
	Task<int> CountQuanInLoaiDaiLy(int maLoaiDaiLy);
}