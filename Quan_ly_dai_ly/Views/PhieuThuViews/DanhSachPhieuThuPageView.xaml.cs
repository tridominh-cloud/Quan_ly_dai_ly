using Quan_ly_dai_ly.ViewModels.DaiLyViewModels;
using Quan_ly_dai_ly.ViewModels.PhieuThuViewModels;

namespace Quan_ly_dai_ly.Views.PhieuThuViews;

public partial class DanhSachPhieuThuPageView : ContentPage
{
	public DanhSachPhieuThuPageView(DanhSachPhieuThuPageViewModels vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}