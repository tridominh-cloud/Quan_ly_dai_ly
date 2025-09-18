using Quan_ly_dai_ly.Data;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Quan_ly_dai_ly.Repositories;

public class PhieuThuRepository : IPhieuThuRepository
{
	private readonly DataContext _dataContext;
	public PhieuThuRepository(DataContext dataContext)
	{
		_dataContext = dataContext;
	}
	public async Task<IEnumerable<PhieuThu>>GetAllPhieuThusAsync()
	{
		return await _dataContext.PhieuThus
						.Include(pt => pt.DaiLy)
						.ToListAsync();
	}
	public async Task<int> GetNextIdAvailable()
	{
		var maxId = await _dataContext.PhieuThus.MaxAsync(pt => (int?)pt.MaPhieuThu) ?? 0;
        return maxId + 1;
	}
	public async Task<int>AddPhieuThuAsync(PhieuThu newPhieuThu)
	{
		await _dataContext.PhieuThus.AddAsync(newPhieuThu);
		return await _dataContext.SaveChangesAsync();
	}
}