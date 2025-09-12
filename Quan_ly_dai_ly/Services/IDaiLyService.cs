using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.Services;

public interface IDaiLyService
{
	Task<IEnumerable<DaiLy>> GetAllDaiLiesAsync();
	Task<int> AddDaiLyAsync(DaiLy newDaiLy);
	Task<int> GetNextAvailableIdAsync();
}