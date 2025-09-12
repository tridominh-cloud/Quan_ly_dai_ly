using Quan_ly_dai_ly.ViewModels.DaiLyViewModels;

namespace Quan_ly_dai_ly.Views.DaiLyViews;

public partial class DanhSachDaiLyPageView
{
	public DanhSachDaiLyPageView(DanhSachDaiLyPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}