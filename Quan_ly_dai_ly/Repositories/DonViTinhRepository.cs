
using Quan_ly_dai_ly.Data;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Quan_ly_dai_ly.Repositories;

public class DonViTinhRepository : IDonViTinhRepository
{
    private readonly DataContext _dataContext;
    public DonViTinhRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<IEnumerable<DonViTinh>> GetAllDonViTinhsAsync()
    {
        return await _dataContext.DonViTinhs.ToListAsync();
    }
}
