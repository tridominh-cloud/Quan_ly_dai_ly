using System.ComponentModel.DataAnnotations;

namespace Quan_ly_dai_ly.Models;

public class DonViTinh
{
    [Key]
    public int MaDonViTinh { get; set; } = 0;
    public string TenDonViTinh { get; set; } = string.Empty;
    public virtual List<MatHang> MatHangs { get; set; } = [];
}
