using Quan_ly_dai_ly.Data;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Quan_ly_dai_ly.Repositories;

public class DaiLyRepository : IDaiLyRepository
{
    private readonly DataContext _dataContext;
    public DaiLyRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<DaiLy>> GetAllDaiLiesAsync()
    {
        return await _dataContext.DaiLies
                        .Include(dl => dl.Quan)
                        .Include(dl => dl.LoaiDaiLy)
                        .ToListAsync();
    }

    public async Task<int> AddDaiLyAsync(DaiLy newDaiLy)
    {
        await _dataContext.DaiLies.AddAsync(newDaiLy);
        return await _dataContext.SaveChangesAsync();
    }

    public async Task<int> GetNextAvailableIdAsync()
    {
        var maxId = await _dataContext.DaiLies.MaxAsync(dl => (int?)dl.MaDaily) ?? 0;
        return maxId + 1;
    }
}