using CommunityToolkit.Mvvm.ComponentModel;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.Services;
using System.Collections.ObjectModel;

namespace Quan_ly_dai_ly.ViewModels.PhieuThuViewModels;

public partial class DanhSachPhieuThuPageViewModels : BaseViewModel
{
	private readonly IServiceProvider _serviceProvider;
	private readonly IPhieuThuService _phieuService;

    public partial class DongHienThi : ObservableObject
    {
        [ObservableProperty]
        private int sTT = 0;
        [ObservableProperty]
        private PhieuThu phieuThu = null!;
    }

    [ObservableProperty] ObservableCollection<DongHienThi> danhSachDongHienThi = [];
    [ObservableProperty] ObservableCollection<PhieuThu> danhSachPhieuThu = [];
    public DanhSachPhieuThuPageViewModels(IServiceProvider serviceProvider, IPhieuThuService phieuService)
    {
        _serviceProvider = serviceProvider;
        _phieuService = phieuService;

        _ = LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var phieuthus = await _phieuService.GetAllPhieuThusAsync();
        DanhSachPhieuThu = new ObservableCollection<PhieuThu>(phieuthus);

        for (int i = 0; i<DanhSachPhieuThu.Count(); i++)
        {
            DanhSachDongHienThi.Add(new DongHienThi
            {
                STT = i + 1,
                PhieuThu = DanhSachPhieuThu[i]
            });
        }    
    }
}