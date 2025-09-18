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

}