
using CommunityToolkit.Maui.Views;
using Quan_ly_dai_ly.Services;

namespace Quan_ly_dai_ly.ViewModels.DaiLyViewModels;

public partial class TraCuuDaiLyWindowViewModel : BaseViewModel
{
    private readonly IDaiLyService _daiLyService;
    private readonly IQuanService _quanService;
    private readonly ILoaiDaiLyService _loaiDaiLyService;
    private readonly IMatHangService _matHangService;
    private readonly IPhieuXuatService _phieuXuatService;
    private readonly IDonViTinhService _donViTinhService;

    private Popup? currentPopup;
    public TraCuuDaiLyWindowViewModel(IDaiLyService daiLyService,
                                      IQuanService quanService, 
                                      ILoaiDaiLyService loaiDaiLyService, 
                                      IMatHangService matHangService, 
                                      IPhieuXuatService phieuXuatService, 
                                      IDonViTinhService donViTinhService)
    {
        _daiLyService = daiLyService;
        _quanService = quanService;
        _loaiDaiLyService = loaiDaiLyService;
        _matHangService = matHangService;
        _phieuXuatService = phieuXuatService;
        _donViTinhService = donViTinhService;
    }

    public void SetPopupReference(Popup popup)
    {
        currentPopup = popup;
    }
}
