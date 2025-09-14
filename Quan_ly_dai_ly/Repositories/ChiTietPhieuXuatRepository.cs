using Quan_ly_dai_ly.Data;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Quan_ly_dai_ly.Repositories;

public class ChiTietPhieuXuatRepository : IChiTietPhieuXuatRepository
{
    private readonly DataContext _dataContext;
    public ChiTietPhieuXuatRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<IEnumerable<ChiTietPhieuXuat>> GetAllChiTietPhieuXuatsAsync()
    {
        return await _dataContext.ChiTietPhieuXuats
                        .Include(px => px.PhieuXuat)
                        .Include(mh => mh.MatHang)
                        .ToListAsync();
    }
    public async Task<int> AddChiTietPhieuXuatAsync(ChiTietPhieuXuat newChiTietPhieuXuat)
    {
        await _dataContext.ChiTietPhieuXuats.AddAsync(newChiTietPhieuXuat);
        return _dataContext.SaveChanges();
    }
    public async Task<int> GetNextAvailableIdAsync()
    {
        var maxId =  await _dataContext.ChiTietPhieuXuats.CountAsync();
        return maxId + 1;
    }
}
