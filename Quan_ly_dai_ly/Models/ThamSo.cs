using System.ComponentModel.DataAnnotations;

namespace Quan_ly_dai_ly.Models;

public class ThamSo
{
    [Key]
    public string TenThamSo { get; set; } = "";
    public string GiaTri { get; set; } = "";
}