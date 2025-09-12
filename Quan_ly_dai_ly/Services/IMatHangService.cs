using Quan_ly_dai_ly.Models;

namespace Quan_ly_dai_ly.Services;

public interface IMatHangService
{
    Task<IEnumerable<MatHang>> GetAllMatHangsAsync();
}
