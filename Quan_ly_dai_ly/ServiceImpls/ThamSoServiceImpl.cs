using Quan_ly_dai_ly.RepositoryInterfaces;
using Quan_ly_dai_ly.Services;

namespace Quan_ly_dai_ly.ServiceImpls;

public class ThamSoServiceImpl : IThamSoService
{
    private readonly IThamSoRepository _thamSoRepository;
    public ThamSoServiceImpl(IThamSoRepository thamSoRepository)
    {
        _thamSoRepository = thamSoRepository;
    }
    public async Task<string> GetThamSo(string key)
    {
        return await _thamSoRepository.GetThamSo(key);
    }
}