using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.Services;
using System.Collections.ObjectModel;

namespace Quan_ly_dai_ly.ViewModels.PhieuThuViewModels;

public partial class LapPhieuThuTienWindowViewModel : BaseViewModel
{
	private readonly IDaiLyService _daiLyService;
	private Popup? currentPopup;

	[ObservableProperty] private ObservableCollection<DaiLy> daiLies = [];
	[ObservableProperty] private DaiLy selectedDaiLy = null!;

	public LapPhieuThuTienWindowViewModel(IDaiLyService daiLyService)
	{
		_daiLyService = daiLyService;

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
	private async Task LapPhieuThuButton()
	{

	}
	[RelayCommand]
	private void ThoatButton()
	{
		currentPopup?.CloseAsync();
	}
}