using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Quan_ly_dai_ly.Services;

namespace Quan_ly_dai_ly.ServiceImpls;

public class DaiLyServiceImpl : IDaiLyService
{
    private readonly IDaiLyRepository _daiLyRepository;
    public DaiLyServiceImpl(IDaiLyRepository daiLyRepository)
    {
        _daiLyRepository=daiLyRepository;
    }
    public async Task<IEnumerable<DaiLy>> GetAllDaiLiesAsync()
    {
        return await _daiLyRepository.GetAllDaiLiesAsync();
    }
    public async Task<int> AddDaiLyAsync(DaiLy newDaiLy)
    {
        return await _daiLyRepository.AddDaiLyAsync(newDaiLy);
    }
    public async Task<int> GetNextAvailableIdAsync()
    {
        return await _daiLyRepository.GetNextAvailableIdAsync();
    }
}