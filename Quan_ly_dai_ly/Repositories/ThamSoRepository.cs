using Microsoft.EntityFrameworkCore;
using Quan_ly_dai_ly.Data;
using Quan_ly_dai_ly.RepositoryInterfaces;

namespace Quan_ly_dai_ly.Repositories;

public class ThamSoRepository : IThamSoRepository
{
    private readonly DataContext _datacontext;
    public ThamSoRepository(DataContext datacontext)
    {
        _datacontext = datacontext;
    }
    public Task<string> GetThamSo(string key)
    {
        return _datacontext.ThamSos
            .Where(ts => ts.TenThamSo == key)
            .Select(ts => ts.GiaTri)
            .FirstOrDefaultAsync();
    }
}