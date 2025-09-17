
using System.ComponentModel.DataAnnotations;


namespace Quan_ly_dai_ly.Models;

public class PhieuThu
{
    [Key]
    public int MaPhieuThu { get; set; } = 0;
    public int MaDaiLy { get; set; } = 0;
    public DateTime NgayThuTien { get; set; } = DateTime.Now;
    public long SoTienThu { get; set; } = 0;

    public DaiLy DaiLy { get; set; } = null!;
}
