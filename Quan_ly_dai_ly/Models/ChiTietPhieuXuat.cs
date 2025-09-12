
using System.ComponentModel.DataAnnotations;

namespace Quan_ly_dai_ly.Models;

public class ChiTietPhieuXuat
{
    [Key]
    public int MaChiTietPhieuXuat { get; set; } = 0;

    // Khóa chính
    public int MaPhieuXuat { get; set; } = 0; // Khóa Ngoại
    public int MaMatHang { get; set; } = 0;   // Khóa Ngoại

    public int SoLuongXuat { get; set; } = 0;
    public long DonGiaXuat { get; set; } = 0;
    public long ThanhTien { get; set; } = 0;


    public virtual PhieuXuat PhieuXuat { get; set; } = null!;
    public virtual MatHang MatHang { get; set; } = null!;
}
