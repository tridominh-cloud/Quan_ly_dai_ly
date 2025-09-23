using CommunityToolkit.Mvvm.ComponentModel;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Quan_ly_dai_ly.Services;
using System.Collections.ObjectModel;

namespace Quan_ly_dai_ly.ViewModels.BaoCaoViewModels;

public partial class LapBaoCaoDoanhSoViewModel : BaseViewModel
{
	private readonly IDaiLyService _daiLyService;
	private readonly IPhieuXuatService _phieuXuatService;

	[ObservableProperty] private int namLapBaoCao = 0;
	[ObservableProperty] private int thangLapBaoCao = 0;
	[ObservableProperty] private long tongDoanhSo = 0;
	[ObservableProperty] private ObservableCollection<DongHienThi> danhSachDongHienThi = [];
	[ObservableProperty] private ObservableCollection<DaiLy> danhSachDaiLy = [];

	public partial class DongHienThi : ObservableObject
	{
		[ObservableProperty] private int sTT = 0;
		[ObservableProperty] private DaiLy daiLy = null!;
		[ObservableProperty] private int soLuongPhieuXuat = 0;
		[ObservableProperty] private long tongGiaTri = 0;
		[ObservableProperty] private double tiLe = 0;
	}

    public LapBaoCaoDoanhSoViewModel(IPhieuXuatService phieuXuatService,
									 IDaiLyService daiLyService)
    {
        _daiLyService = daiLyService;
        _phieuXuatService = phieuXuatService;

		ThangLapBaoCao = 12;
		NamLapBaoCao = 2022;


		_ = LoadDataAsync();
		LoadDongHienThi();
    }

	private async Task LoadDataAsync()
	{
		var dailies = await _daiLyService.GetAllDaiLiesAsync();
		DanhSachDaiLy = new ObservableCollection<DaiLy>(dailies);
	}
    private void LoadDongHienThi()
	{
		var dsDaiLy = DanhSachDaiLy
								.Where(dsdl=>dsdl.PhieuXuats.Any(px=>px.NgayLap.Month == ThangLapBaoCao && 
																	 px.NgayLap.Year == NamLapBaoCao))
								.ToList();

		DanhSachDongHienThi.Clear();
		
		foreach(var dsdl in dsDaiLy)
		{
			TongDoanhSo += dsdl.PhieuXuats.Sum(px => px.TongGiaTri);
		}	

		for (int i = 0; i<dsDaiLy.Count(); i++)
		{
			var tongGiaTri = dsDaiLy[i].PhieuXuats.Sum(px => px.TongGiaTri);

			DanhSachDongHienThi.Add(new DongHienThi
			{
				STT = i + 1,
				DaiLy = dsDaiLy[i],
				SoLuongPhieuXuat = dsDaiLy[i].PhieuXuats.Count(),
				TongGiaTri = tongGiaTri,
				TiLe = (double)tongGiaTri / TongDoanhSo
			});
		}	
	}

}