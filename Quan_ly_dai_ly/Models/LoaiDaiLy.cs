using System.ComponentModel.DataAnnotations;

namespace Quan_ly_dai_ly.Models;

public class LoaiDaiLy
{
    [Key]
    public int MaLoaiDaiLy { get; set; } = 0;
    public string TenLoaiDaiLy { get; set; } = "";
    public double NoToiDa { get; set; } = 0;
    public virtual List<DaiLy> DaiLies { get; set; } = [];
}