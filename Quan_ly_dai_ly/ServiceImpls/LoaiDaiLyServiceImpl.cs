using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.Repositories;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Quan_ly_dai_ly.Services;

namespace Quan_ly_dai_ly.ServiceImpls;

public class LoaiDaiLyServiceImpl : ILoaiDaiLyService
{
    private readonly ILoaiDaiLyRepository _loaiDaiLyRepository;
    public LoaiDaiLyServiceImpl(ILoaiDaiLyRepository loaiDaiLyRepository)
    {
        _loaiDaiLyRepository = loaiDaiLyRepository;
    }
    public async Task<IEnumerable<LoaiDaiLy>> GetAllLoaiDaiLiesAsync()
    {
        return await _loaiDaiLyRepository.GetAllLoaiDaiLiesAsync();
    }
    public async Task<int> CountQuanInLoaiDaiLy(int maLoaiDaiLy)
    {
        return await _loaiDaiLyRepository.CountQuanInLoaiDaiLy(maLoaiDaiLy);
    }
}