
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.Services;
using Quan_ly_dai_ly.Utils;
using System.Collections.ObjectModel;

namespace Quan_ly_dai_ly.ViewModels.PhieuThuViewModels;

public partial class LapPhieuThuTienWindowViewModel : BaseViewModel
{
	private readonly IDaiLyService _daiLyService;
	private readonly IPhieuThuService _phieuThuService;
	private Popup? currentPopup;

	[ObservableProperty] private DateTime ngayThuTien = DateTime.Now;
	[ObservableProperty] private long soTienThu = 0;
	[ObservableProperty] private ObservableCollection<DaiLy> daiLies = [];
	[ObservableProperty] private DaiLy selectedDaiLy = null!;

	public LapPhieuThuTienWindowViewModel(IDaiLyService daiLyService, IPhieuThuService phieuThuService)
	{
		_daiLyService = daiLyService;
		_phieuThuService = phieuThuService;

		_ = LoadDataAsync();
	}
	public void SetReference(Popup popup)
	{
		currentPopup = popup;
	}
	private async Task LoadDataAsync()
	{
		var dailies = await _daiLyService.GetAllDaiLiesAsync();

		DaiLies = new ObservableCollection<DaiLy>(dailies);
	}
	[RelayCommand]
	private async Task LapPhieuThuTienButton()
	{
		try
		{
            var newPhieuThu = new PhieuThu
            {
                MaPhieuThu = await _phieuThuService.GetNextIdAvailable(),
                MaDaiLy = SelectedDaiLy.MaDaiLy,
                NgayThuTien = NgayThuTien,
                SoTienThu = SoTienThu
            };
            await _phieuThuService.AddPhieuThuAsync(newPhieuThu);
			await AlertUtil.ShowSuccessAlert($"Thêm phiếu thu thành công");
        }
		catch(Exception ex)
		{
			await AlertUtil.ShowErrorAlert($"Lỗi: {ex.Message}");
		}


	}
	[RelayCommand]
	private void ThoatButton()
	{
		currentPopup?.CloseAsync();
	}
}