using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.Services;
using Quan_ly_dai_ly.Utils;
using Quan_ly_dai_ly.Views.PhieuXuatViews;
using System.Collections.ObjectModel;

namespace Quan_ly_dai_ly.ViewModels.PhieuXuatViewModels;

public partial class DanhSachPhieuXuatHangPageViewModel : BaseViewModel
{
	private readonly IServiceProvider _serviceProvider;
	private readonly IPhieuXuatService _phieuXuatService;
	public DanhSachPhieuXuatHangPageViewModel(IServiceProvider serviceProvider, IPhieuXuatService phieuXuatService)
	{
		_serviceProvider = serviceProvider;
		_phieuXuatService = phieuXuatService;

		_ = LoadDataAsync();
	}
	public async Task LoadDataAsync()
	{
		IsLoading = true;
		var list = await _phieuXuatService.GetAllPhieuXuatsAsync();
        DanhSachPhieuXuat = new ObservableCollection<PhieuXuat>(list);
		IsLoading = false;
	}
	[ObservableProperty]
	private ObservableCollection<PhieuXuat> danhSachPhieuXuat = [];

	[RelayCommand]
	public async Task ThemPhieuXuatButton()
	{
		try
		{
			var themPhieuXuatView = _serviceProvider.GetRequiredService<LapPhieuXuatHangWindowView>();
			var mainPage = Application.Current?.MainPage;

			if (mainPage is not null)
			{
                await mainPage.ShowPopupAsync(themPhieuXuatView);
				await LoadDataAsync();
			}
		}
		catch (Exception ex)
		{
			await AlertUtil.ShowErrorAlert($"Lỗi: {ex}");
		}
	}
}