
using System.ComponentModel.DataAnnotations;

namespace Quan_ly_dai_ly.Models;

public class MatHang
{
    [Key]
    public int MaMatHang { get; set; } = 0;
    public string TenMatHang { get; set; } = string.Empty;
    public int MaDonViTinh { get; set; } = 0;  // Khóa ngoại
    public int SoLuongTon { get; set; } = 0;

    public virtual List<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; } = [];
    public virtual DonViTinh DonViTinh { get; set; } = null!;
}
