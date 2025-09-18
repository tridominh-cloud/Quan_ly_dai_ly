using System.ComponentModel.DataAnnotations;

namespace Quan_ly_dai_ly.Models;

public class DaiLy
{
    [Key]
    public int MaDaily { get; set; }
    public string Ten { get; set; } = "";
    public string DienThoai { get; set; } = string.Empty;
    public string DiaChi { get; set; } = "";
    public string Email { get; set; } = "";
    public int MaLoaiDaiLy { get; set; } = 0; // Khóa ngoại
    public int MaQuan { get; set; } = 0;      // Khóa ngoại
    public DateTime NgayTiepNhan { get; set; } = DateTime.Now;
    public double NoDaiLy { get; set; } = 0;

    //Khóa ngoại
    public virtual LoaiDaiLy LoaiDaiLy { get; set; } = null!;
    public virtual Quan Quan { get; set; } = null!;
    public virtual List<PhieuXuat> PhieuXuats { get; set; } = null!;
    public virtual List<PhieuThu> PhieuThus { get; set; } = null!;
}