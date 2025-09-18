using Quan_ly_dai_ly.ViewModels.DaiLyViewModels;

namespace Quan_ly_dai_ly.Views.PhieuThuViews;

public partial class DanhSachPhieuThuPageView : ContentPage
{
	public DanhSachPhieuThuPageView(DanhSachDaiLyPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}