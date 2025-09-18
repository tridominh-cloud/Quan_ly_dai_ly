using CommunityToolkit.Maui.Views;
using Quan_ly_dai_ly.ViewModels.PhieuThuViewModels;

namespace Quan_ly_dai_ly.Views.PhieuThuViews;

public partial class LapPhieuThuTienWindowView : Popup
{
	public LapPhieuThuTienWindowView(LapPhieuThuTienWindowViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

		vm.SetReference(this);
	}
}