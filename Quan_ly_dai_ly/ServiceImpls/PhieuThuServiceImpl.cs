using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Quan_ly_dai_ly.Services;

namespace Quan_ly_dai_ly.ServiceImpls;

public class PhieuThuServiceImpl : IPhieuThuService
{
	private readonly IPhieuThuRepository _phieuThuRepsitory;
	public PhieuThuServiceImpl(IPhieuThuRepository phieuThuRepsitory)
    {
        _phieuThuRepsitory = phieuThuRepsitory;
    }
    public async Task<IEnumerable<PhieuThu>>GetAllPhieuThusAsync()
    {
        return await _phieuThuRepsitory.GetAllPhieuThusAsync();
    }
    public async Task<int>GetNextIdAvailable()
    {
        return await _phieuThuRepsitory.GetNextIdAvailable();
    }
    public async Task<int> AddPhieuThuAsync(PhieuThu newPhieuThu)
    {
        return await _phieuThuRepsitory.AddPhieuThuAsync(newPhieuThu);
    }
}