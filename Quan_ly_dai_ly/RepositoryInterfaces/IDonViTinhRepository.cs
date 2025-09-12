
using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.RepositoryInterfaces;

public interface IDonViTinhRepository
{
    Task<IEnumerable<DonViTinh>> GetAllDonViTinhsAsync();
}
