using CommunityToolkit.Maui.Views;
using Quan_ly_dai_ly.ViewModels.PhieuXuatViewModels;

namespace Quan_ly_dai_ly.Views.PhieuXuatViews;

public partial class LapPhieuXuatHangWindowView : Popup
{
	public LapPhieuXuatHangWindowView(LapPhieuXuatHangWindowViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
	
		vm.SetPopupReference(this);
	}
}