using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.Services;

public interface IPhieuThuService 
{
	Task<IEnumerable<PhieuThu>> GetAllPhieuThusAsync();
	Task<int> AddPhieuThuAsync(PhieuThu newPhieuThu);
	Task<int> GetNextIdAvailable();
}