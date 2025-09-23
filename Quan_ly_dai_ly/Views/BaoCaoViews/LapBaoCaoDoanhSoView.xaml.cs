using Quan_ly_dai_ly.ViewModels.BaoCaoViewModels;

namespace Quan_ly_dai_ly.Views.BaoCaoViews;

public partial class LapBaoCaoDoanhSoView : ContentPage
{
	public LapBaoCaoDoanhSoView(LapBaoCaoDoanhSoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}