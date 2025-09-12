using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.Repositories;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Quan_ly_dai_ly.Services;

namespace Quan_ly_dai_ly.ServiceImpls;

public class DonViTinhServiceImpl : IDonViTinhService
{
    private readonly IDonViTinhRepository _donViTinhRepository;
    public DonViTinhServiceImpl(IDonViTinhRepository donViTinhRepository)
    {
        _donViTinhRepository = donViTinhRepository;
    }

    public async Task<IEnumerable<DonViTinh>> GetAllDonViTinhsAsync()
    {
        return await _donViTinhRepository.GetAllDonViTinhsAsync();
    }
}
