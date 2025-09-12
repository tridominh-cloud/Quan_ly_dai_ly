
using System.ComponentModel.DataAnnotations;

namespace Quan_ly_dai_ly.Models;

public class PhieuXuat
{
    [Key]
    public int MaPhieuXuat { get; set; } = 0;
    public int MaDaiLy { get; set; } = 0; // Khóa ngoại
    public DateTime NgayLap { get; set; } = DateTime.Now;
    public long TongGiaTri { get; set; } = 0;

    public virtual DaiLy DaiLy { get; set; } = null!;
    public virtual List<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; } = [];
}
