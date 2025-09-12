using Microsoft.EntityFrameworkCore;
using Quan_ly_dai_ly.Data;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;

namespace Quan_ly_dai_ly.Repositories;

public class QuanRepository : IQuanRepository
{
    private readonly DataContext _dataContext;
    public QuanRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Quan>> GetAllQuansAsync()
    {
        return await _dataContext.Quans.ToListAsync();
    }
}