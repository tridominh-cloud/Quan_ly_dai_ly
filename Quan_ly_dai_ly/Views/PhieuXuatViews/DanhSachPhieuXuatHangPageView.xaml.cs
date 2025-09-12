using Quan_ly_dai_ly.ViewModels.PhieuXuatViewModels;

namespace Quan_ly_dai_ly.Views.PhieuXuatViews;

public partial class DanhSachPhieuXuatHangPageView : ContentPage
{
	public DanhSachPhieuXuatHangPageView(DanhSachPhieuXuatHangPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}