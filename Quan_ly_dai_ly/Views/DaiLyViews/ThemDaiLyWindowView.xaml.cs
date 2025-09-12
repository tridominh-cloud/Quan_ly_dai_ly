using CommunityToolkit.Maui.Views;
using Quan_ly_dai_ly.ViewModels.DaiLyViewModels;

namespace Quan_ly_dai_ly.Views.DaiLyViews;

public partial class ThemDaiLyWindowView : Popup
{
	public ThemDaiLyWindowView(ThemDaiLyWindowViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

        vm.SetPopupReference(this);
    }
}