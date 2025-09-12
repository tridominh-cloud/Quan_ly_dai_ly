using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.RepositoryInterfaces;

public interface IDaiLyRepository 
{
	Task<IEnumerable<DaiLy>> GetAllDaiLiesAsync();
	Task<int> AddDaiLyAsync(DaiLy newDaiLy);
	Task<int> GetNextAvailableIdAsync();

}