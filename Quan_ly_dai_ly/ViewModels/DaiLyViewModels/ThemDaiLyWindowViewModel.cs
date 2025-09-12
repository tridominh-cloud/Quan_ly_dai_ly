using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.Services;
using Quan_ly_dai_ly.Utils;
using System.Collections.ObjectModel;

namespace Quan_ly_dai_ly.ViewModels.DaiLyViewModels;

public partial class ThemDaiLyWindowViewModel : BaseViewModel
{
    private readonly IDaiLyService _daiLyService;
    private readonly ILoaiDaiLyService _loaiDaiLyService;
    private readonly IQuanService _quanService;
    private readonly IThamSoService _thamSoService;

    [ObservableProperty] private int maDaiLy = 0;
    [ObservableProperty] private string ten = string.Empty;
    [ObservableProperty] private string diaChi = string.Empty;
    [ObservableProperty] private string email = string.Empty;
    [ObservableProperty] private string soDienThoai = string.Empty;
    [ObservableProperty] private DateTime ngayTiepNhan = DateTime.Now;
    [ObservableProperty] private double noDaiLy = 0;
    [ObservableProperty] private ObservableCollection<LoaiDaiLy> loaiDaiLies = [];
    [ObservableProperty] private ObservableCollection<Quan> quans = [];
    [ObservableProperty] private LoaiDaiLy? selectedLoaiDaiLy;
    [ObservableProperty] private Quan? selectedQuan;

    private Popup? currentPopup;

    public ThemDaiLyWindowViewModel(IDaiLyService daiLyService, ILoaiDaiLyService loaiDaiLyService, IQuanService quanService, IThamSoService thamSoService)
    {
        _daiLyService = daiLyService;
        _loaiDaiLyService = loaiDaiLyService;
        _quanService = quanService;
        _thamSoService = thamSoService;

        _ = LoadDataAsync();
    }

    public void SetPopupReference(Popup popup)
    {
        currentPopup = popup;
    }

    private async Task LoadDataAsync()
    {
        try
        {
            IsLoading = true;

            var loaiDaiLies = await _loaiDaiLyService.GetAllLoaiDaiLiesAsync();
            var quans = await _quanService.GetAllQuansAsync();

            LoaiDaiLies = new ObservableCollection<LoaiDaiLy>(loaiDaiLies);
            Quans = new ObservableCollection<Quan>(quans);

            MaDaiLy = await _daiLyService.GetNextAvailableIdAsync();

            if (LoaiDaiLies.Any())
                SelectedLoaiDaiLy = LoaiDaiLies[0];

            if (Quans.Any())
            {
                SelectedQuan = Quans[0];
            }

        }
        catch (Exception ex)
        {
            await AlertUtil.ShowErrorAlert($"Lỗi khi tải dữ liệu: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }

    }

    [RelayCommand]
    private async Task TiepNhanButton()
    {
        try
        {
            if (SelectedLoaiDaiLy == null)
            {
                await AlertUtil.ShowErrorAlert("Vui lòng chọn loại đại lý");
                return;
            }
            else if (SelectedQuan == null)
            {
                await AlertUtil.ShowErrorAlert("Vui lòng chọn quận");
                return;
            }
            var newDaiLy = new DaiLy
            {
                Ten = Ten,
                DiaChi = DiaChi,
                Email = Email,
                NgayTiepNhan = NgayTiepNhan,
                MaLoaiDaiLy = SelectedLoaiDaiLy!.MaLoaiDaiLy,
                MaQuan = SelectedQuan!.MaQuan,
                NoDaiLy = 0
            };
            await _daiLyService.AddDaiLyAsync(newDaiLy);
            await AlertUtil.ShowSuccessAlert("Them đại lý thành công");

            currentPopup?.CloseAsync();
        }
        catch (Exception ex)
        {
            await AlertUtil.ShowErrorAlert($"Lỗi khi thêm đại lí: {ex.Message}");
        }
    }

    [RelayCommand]
    private async Task LamMoiButton()
    {
        try
        {
            Ten = string.Empty;
            DiaChi = string.Empty;
            Email = string.Empty;
            NgayTiepNhan = DateTime.Now;
            soDienThoai = string.Empty;
            if (LoaiDaiLies.Any())
                SelectedLoaiDaiLy = LoaiDaiLies[0];
            if (Quans.Any())
                SelectedQuan = Quans[0];

            MaDaiLy = await _daiLyService.GetNextAvailableIdAsync();
        }
        catch (Exception ex)
        {
            await AlertUtil.ShowErrorAlert($"Lỗi làm mới đại lý: {ex.Message}");
        }
    }

    [RelayCommand]
    private void ThoatButton()
    {
        currentPopup?.CloseAsync();
    }
}