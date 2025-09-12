using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Quan_ly_dai_ly.Services;

namespace Quan_ly_dai_ly.ServiceImpls;

public class MatHangServiceImpl : IMatHangService
{
    private readonly IMatHangRepository _matHangRepository;
    public MatHangServiceImpl(IMatHangRepository matHangRepository)
    {
        _matHangRepository = matHangRepository;
    }
    public async Task<IEnumerable<MatHang>> GetAllMatHangsAsync()
    {
        return await _matHangRepository.GetAllMatHangsAsync();
    }
}
