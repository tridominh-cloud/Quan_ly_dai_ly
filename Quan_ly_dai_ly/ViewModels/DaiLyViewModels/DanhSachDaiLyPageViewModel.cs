using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.Services;
using Quan_ly_dai_ly.Utils;
using Quan_ly_dai_ly.Views.DaiLyViews;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Quan_ly_dai_ly.ViewModels.DaiLyViewModels;

public partial class DanhSachDaiLyPageViewModel : BaseViewModel
{
	private readonly IDaiLyService _daiLyService;
	private readonly IServiceProvider _serviceProvider;
	public DanhSachDaiLyPageViewModel(IDaiLyService daiLyService, IServiceProvider serviceProvider)
	{
		_daiLyService = daiLyService;
		_serviceProvider = serviceProvider;

		_ = LoadDataAsync();
	}
	private async Task LoadDataAsync()
	{
		IsLoading = true;
        await Task.Yield();
        var list = await Task.Run(async () => await _daiLyService.GetAllDaiLiesAsync() );
		DanhSachDaiLy = new ObservableCollection<DaiLy>(list);
        await Task.Yield();
        IsLoading = false;
	}

	[ObservableProperty]
	private ObservableCollection<DaiLy> danhSachDaiLy = [];

	[RelayCommand]
	private async Task ClickButton()
	{
		await AlertUtil.ShowInfoAlert("Bạn đã click vào button");
	}

	[RelayCommand] private void LoadButton() => _ = LoadDataAsync();

    [RelayCommand]
	private async Task ThemDaiLyButton()
	{
		try
		{
			var themDaiLyView = _serviceProvider.GetRequiredService<ThemDaiLyWindowView>();
			var mainPage = Application.Current?.MainPage;

			if (mainPage is not null)
			{
				await mainPage.ShowPopupAsync(themDaiLyView);
                await LoadDataAsync();
			}
		}
		catch (Exception ex)
		{
			await AlertUtil.ShowErrorAlert($"Không thể mở popup thêm đại lý: {ex.Message}");
		}
	}
	[RelayCommand]
	private async Task TraCuuDaiLyButton()
	{
		try
		{
			var traCuuDaiLyView = _serviceProvider.GetRequiredService<TraCuuDaiLyWindowView>();
			var mainPage = Application.Current?.MainPage;

			if (mainPage is not null)
			{
                await mainPage.ShowPopupAsync(traCuuDaiLyView);
			}
		}
		catch (Exception ex)
		{
			await AlertUtil.ShowErrorAlert($"Không thể mở popup tra cứu đại lý: {ex.Message}");
		}
	}
}
