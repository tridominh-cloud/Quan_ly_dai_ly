using Quan_ly_dai_ly.Data;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Quan_ly_dai_ly.Repositories;

public class MatHangRepository : IMatHangRepository
{
    private readonly DataContext _dataContext;
    public MatHangRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<IEnumerable<MatHang>>GetAllMatHangsAsync()
    {
        return await _dataContext.MatHangs
                        .Include(mh => mh.DonViTinh)
                        .ToListAsync();
    }
}
