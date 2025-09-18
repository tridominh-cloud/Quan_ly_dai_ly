using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.RepositoryInterfaces;

public interface IPhieuThuRepository 
{
	Task<IEnumerable<PhieuThu>> GetAllPhieuThusAsync();
	Task<int> GetNextIdAvailable();
	Task<int> AddPhieuThuAsync(PhieuThu newPhieuThu);
}