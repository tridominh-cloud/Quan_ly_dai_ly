using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.Services;

public interface IDonViTinhService
{
    Task<IEnumerable<DonViTinh>> GetAllDonViTinhsAsync();
}
