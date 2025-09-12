using Microsoft.EntityFrameworkCore;
using Quan_ly_dai_ly.Data;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;

namespace Quan_ly_dai_ly.Repositories;

public class LoaiDaiLyRepository : ILoaiDaiLyRepository
{
    private readonly DataContext _dataContext;
    public LoaiDaiLyRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<LoaiDaiLy>> GetAllLoaiDaiLiesAsync()
    {
        return await _dataContext.LoaiDaiLies.ToListAsync();
    }

    public async Task<int> CountQuanInLoaiDaiLy(int maLoaiDaiLy)
    {
        return await _dataContext.DaiLies
            .Where(dl => dl.MaLoaiDaiLy == maLoaiDaiLy)
            .Select(dl => dl.MaQuan)
            .Distinct()
            .CountAsync();
    }
}