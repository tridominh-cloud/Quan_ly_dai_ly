using Quan_ly_dai_ly.Data;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Quan_ly_dai_ly.Repositories;

public class PhieuXuatRepository : IPhieuXuatRepository
{
    private readonly DataContext _dataContext;
    public PhieuXuatRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<IEnumerable<PhieuXuat>> GetAllPhieuXuatsAsync()
    {
        return await _dataContext.PhieuXuats
                        .Include(px => px.DaiLy)
                        .ToListAsync();
    }
    public async Task<int> AddPhieuXuatAsync(PhieuXuat newPhieuXuat)
    {
        await _dataContext.PhieuXuats.AddAsync(newPhieuXuat);
        return await _dataContext.SaveChangesAsync();
    }
    public async Task<int> GetNextAvailableIdAsync()
    {
        var maxId = await _dataContext.PhieuXuats.MaxAsync(px => (int?)px.MaPhieuXuat) ?? 0;
        return maxId + 1;
    }
}
