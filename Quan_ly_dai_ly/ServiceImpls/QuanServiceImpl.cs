using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Quan_ly_dai_ly.Services;

namespace Quan_ly_dai_ly.ServiceImpls;

public class QuanServiceImpl : IQuanService
{
    private readonly IQuanRepository _quanRepository;
    public QuanServiceImpl(IQuanRepository quanRepository)
    {
        _quanRepository = quanRepository;
    }
    public async Task<IEnumerable<Quan>> GetAllQuansAsync()
    {
        return await _quanRepository.GetAllQuansAsync();
    }
}
