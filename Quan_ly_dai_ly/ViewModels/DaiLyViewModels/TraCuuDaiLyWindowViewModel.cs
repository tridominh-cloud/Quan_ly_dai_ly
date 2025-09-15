
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging.Abstractions;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.Services;
using Quan_ly_dai_ly.Utils;
using System.Collections.ObjectModel;

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

        _ = LoadDataAsync();
    }

    public void SetPopupReference(Popup popup)
    {
        currentPopup = popup;
    }

    [ObservableProperty] private int? maDaiLy = null;
    [ObservableProperty] private string tenDaiLy = string.Empty;
    [ObservableProperty] private string dienThoai = string.Empty;
    [ObservableProperty] private string diaChi = string.Empty;
    [ObservableProperty] private string email = string.Empty;

    [ObservableProperty] private ObservableCollection<LoaiDaiLy> loaiDaiLies = [];
    [ObservableProperty] private LoaiDaiLy? selectedLoaiDaiLy;
    [ObservableProperty] private ObservableCollection<Quan> quans = [];
    [ObservableProperty] private Quan? selectedQuan;

    [ObservableProperty] private DateTime ngayTiepNhanStart = DateTime.MinValue;
    [ObservableProperty] private DateTime ngayTiepNhanEnd = DateTime.MinValue;

    [ObservableProperty] private double noDaiLyStart = 0;
    [ObservableProperty] private double noDaiLyEnd = 0;

    [ObservableProperty] private double noToiDaStart = 0;
    [ObservableProperty] private double noToiDaEnd = 0;
    
    [ObservableProperty] private int maPhieuXuatStart = 0;
    [ObservableProperty] private int maPhieuXuatEnd = 0;
    
    [ObservableProperty] private DateTime ngayLapPhieuXuatStart = DateTime.MinValue;
    [ObservableProperty] private DateTime ngayLapPhieuXuatEnd = DateTime.MinValue;
    
    [ObservableProperty] private long tongGiaTriPhieuXuatStart = 0;
    [ObservableProperty] private long tongGiaTriPhieuXuatEnd = 0;
    
    [ObservableProperty] private ObservableCollection<MatHang> matHangs = [];
    [ObservableProperty] private MatHang? selectedMatHang;
    
    [ObservableProperty] private ObservableCollection<DonViTinh> donViTinhs = [];
    [ObservableProperty] private DonViTinh? selectedDonViTinh;
    
    [ObservableProperty] private int soLuongXuatStart = 0;
    [ObservableProperty] private int soLuongXuatEnd = 0;
    
    [ObservableProperty] private long donGiaXuatStart = 0;
    [ObservableProperty] private long donGiaXuatEnd = 0;
    
    [ObservableProperty] private long thanhTienStart = 0;
    [ObservableProperty] private long thanhTienEnd = 0;
    
    [ObservableProperty] private int soLuongTonStart = 0;
    [ObservableProperty] private int soLuongTonEnd = 0;
    
    [ObservableProperty] private DateTime ngayLapPhieuThuTienStart = DateTime.MinValue;
    [ObservableProperty] private DateTime ngayLapPhieuThuTienEnd = DateTime.MinValue;
    
    [ObservableProperty] private long tongGiaTriPhieuThuTienStart = 0;
    [ObservableProperty] private long tongGiaTriPhieuThuTienEnd = 0;

    [ObservableProperty] private ObservableCollection<DaiLy> daiLies = [];
    [ObservableProperty] private ObservableCollection<DaiLy> danhSachDaiLy = [];
    [ObservableProperty] private ObservableCollection<DongHienThi> danhSachDongHienThi = [];

    public partial class DongHienThi : ObservableObject
    {
        [ObservableProperty] private int sTT = 0;
        [ObservableProperty] private DaiLy? daiLy;
    }
    private async Task LoadDataAsync()
    {
        var dailies = await _daiLyService.GetAllDaiLiesAsync();
        var loaiDaiLies = await _loaiDaiLyService.GetAllLoaiDaiLiesAsync();
        var quans = await _quanService.GetAllQuansAsync();
        var matHangs = await _matHangService.GetAllMatHangsAsync();
        var donViTinhs = await _donViTinhService.GetAllDonViTinhsAsync();

        DaiLies = new ObservableCollection<DaiLy>(dailies);
        LoaiDaiLies = new ObservableCollection<LoaiDaiLy>(loaiDaiLies);
        Quans = new ObservableCollection<Quan>(quans);
        MatHangs = new ObservableCollection<MatHang>(matHangs);
        DonViTinhs = new ObservableCollection<DonViTinh>(donViTinhs);
    }
    [RelayCommand]
    private async Task TraCuuDaiLyButton()
    {
        try
        {
            if (MaDaiLy == null
                && TenDaiLy == string.Empty
                && DienThoai == string.Empty
                && DiaChi == string.Empty
                && Email == string.Empty
                && SelectedLoaiDaiLy == null
                && SelectedQuan == null
                && NgayTiepNhanStart == DateTime.MinValue && NgayTiepNhanEnd == DateTime.MinValue
                && NoDaiLyStart == 0 && NoDaiLyEnd == 0
                && NoToiDaStart == 0 && NoToiDaEnd == 0
                && MaPhieuXuatStart == 0 && MaPhieuXuatEnd == 0
                && NgayLapPhieuXuatStart == DateTime.MinValue && NgayLapPhieuXuatEnd == DateTime.MinValue
                && TongGiaTriPhieuXuatStart == 0 && TongGiaTriPhieuXuatEnd == 0
                && SelectedMatHang == null && SelectedDonViTinh == null
                && SoLuongXuatStart == 0 && SoLuongXuatEnd == 0
                && DonGiaXuatStart == 0 && DonGiaXuatEnd == 0
                && ThanhTienStart == 0 && ThanhTienEnd == 0
                && SoLuongTonStart == 0 && SoLuongTonEnd == 0
                && NgayLapPhieuThuTienStart == DateTime.MinValue && NgayLapPhieuThuTienEnd == DateTime.MinValue)
            {
                await AlertUtil.ShowInfoAlert($"Bạn chưa chọn điều kiện tìm kiếm");
                return;
            }
            else
            {
                DanhSachDongHienThi.Clear();
                foreach (var dl in DaiLies)
                {
                    if (KiemTraMaDaiLy(dl) == 1
                        && KiemTraTenLoaiDaiLy(dl) == 1
                        && KiemTraTenQuan(dl) == 1
                        && KiemTraTenDaiLy(dl) == 1
                        && KiemtraDienThoai(dl) == 1
                        && KiemTraDiaChi(dl) == 1
                        && KiemTraEmail(dl) == 1
                        && KiemTraNgayTiepNhan(dl) == 1
                        && KiemTraNoDaiLy(dl) == 1
                        && KiemTraMaPhieuXuat(dl) == 1
                        && KiemTraNgayLapPhieuXuat(dl) == 1
                        && KiemTraTongGiaTriPhieuXuat(dl) == 1
                        && KiemTraTenMatHangXuat(dl) == 1
                        && KiemTraTenDonViTinh(dl) == 1
                        && KiemTraSoLuongXuat(dl) == 1
                        && KiemTraDonGiaXuat(dl) == 1)
                    {
                        DanhSachDaiLy.Add(dl);
                    }
                }
                for (int i=0; i<DanhSachDaiLy.Count(); i++)
                {
                    DanhSachDongHienThi.Add(new DongHienThi()
                    {
                        STT = i + 1,
                        DaiLy = DanhSachDaiLy[i]
                    });
                }
            }
        }
        catch(Exception ex)
        {
            await AlertUtil.ShowErrorAlert($"Lỗi: {ex.Message}");
        }
    }
    private int KiemTraMaDaiLy(DaiLy daiLy)
    {        
        var strDieuKien = MaDaiLy.ToString() ?? string.Empty;
        var strMaDaiLy = daiLy.MaDaily.ToString();

        return MaDaiLy == 0 || strMaDaiLy.Contains(strDieuKien) ? 1 : 0;
    }
    private int KiemTraTenLoaiDaiLy(DaiLy daily)
    {
        return SelectedLoaiDaiLy == null || daily.LoaiDaiLy == SelectedLoaiDaiLy ? 1 : 0;
    }
    private int KiemTraTenQuan(DaiLy daiLy)
    {
        return SelectedQuan == null || daiLy.Quan == SelectedQuan ? 1 : 0;
    }
    private int KiemTraTenDaiLy(DaiLy daiLy)
    {
        return TenDaiLy == string.Empty || daiLy.Ten.Contains(TenDaiLy) ? 1 : 0;
    }
    private int KiemtraDienThoai(DaiLy daiLy)
    {
        return DienThoai == string.Empty || daiLy.DienThoai.Contains(DienThoai) ? 1 : 0;
    }
    private int KiemTraDiaChi(DaiLy daily)
    {
        return DiaChi == string.Empty || daily.DiaChi.Contains(DiaChi) ? 1 : 0;
    }
    private int KiemTraEmail(DaiLy daiLy)
    {
        return Email == string.Empty || daiLy.Email.Contains(Email) ? 1 : 0;
    }
    private int KiemTraNgayTiepNhan(DaiLy daily)
    {
        return (NgayTiepNhanStart == DateTime.MinValue && NgayTiepNhanEnd == DateTime.MinValue) 
            || (NgayTiepNhanStart <= daily.NgayTiepNhan && daily.NgayTiepNhan <= NgayTiepNhanEnd) ? 1 : 0;
    }
    private int KiemTraNoDaiLy(DaiLy daiLy)
    {
        return (NoDaiLyStart == 0 && NoDaiLyEnd == 0) || (NoDaiLyStart <= daiLy.NoDaiLy && daiLy.NoDaiLy <= NoDaiLyEnd) ? 1 : 0;
    }
    private int KiemTraMaPhieuXuat(DaiLy daily)
    {
        if (MaPhieuXuatStart == 0 && MaPhieuXuatEnd == 0)
            return 1;

        foreach (var phieu in daily.PhieuXuats)
        {
            if (MaPhieuXuatStart <= phieu.MaPhieuXuat && phieu.MaPhieuXuat <= MaPhieuXuatEnd)
                return 1;
        }
        return 0;
    }

    private int KiemTraNgayLapPhieuXuat(DaiLy daily)
    {
        if (NgayLapPhieuXuatStart == DateTime.MinValue && NgayLapPhieuXuatEnd == DateTime.MinValue)
            return 1;
        foreach (var phieu in daily.PhieuXuats)
        {
            if (NgayLapPhieuXuatStart <= phieu.NgayLap && phieu.NgayLap <= NgayLapPhieuXuatEnd)
                return 1;
        }
        return 0;
    }

    private int KiemTraTongGiaTriPhieuXuat(DaiLy daily)
    {
        if (TongGiaTriPhieuXuatStart == 0 && TongGiaTriPhieuXuatEnd == 0)
            return 1;
        foreach (var phieu in daily.PhieuXuats)
        {
            if (TongGiaTriPhieuXuatStart <= phieu.TongGiaTri && phieu.TongGiaTri <= TongGiaTriPhieuXuatEnd)
                return 1;
        }
        return 0;
    }

    private int KiemTraTenMatHangXuat(DaiLy daily)
    {
        if (SelectedMatHang == null)
            return 1;
        foreach (var phieu in daily.PhieuXuats)
        {
            foreach(var chitiet in phieu.ChiTietPhieuXuats)
            {
                if (chitiet.MatHang == SelectedMatHang)
                    return 1;
            }    
        }    
        return 0;
    }

    private int KiemTraTenDonViTinh(DaiLy daily)
    {
        if (SelectedDonViTinh == null)
            return 1;
        foreach (var phieu in daily.PhieuXuats)
        {
            foreach (var chitiet in phieu.ChiTietPhieuXuats)
            {
                if (chitiet.MatHang.DonViTinh == SelectedDonViTinh)
                    return 1;
            }
        }
        return 0;
    }

    private int KiemTraSoLuongXuat(DaiLy daily)
    {
        if (SelectedMatHang == null || (SoLuongXuatStart == 0 && SoLuongXuatEnd == 0))
            return 1;
        //var tongSoLuongXuat = 0;
        foreach (var phieu in daily.PhieuXuats)
        {
            foreach(var chitiet in phieu.ChiTietPhieuXuats)
            {
                if(chitiet.MatHang == SelectedMatHang && SoLuongXuatStart <= chitiet.SoLuongXuat && chitiet.SoLuongXuat <= SoLuongXuatEnd)
                {
                    return 1;
                    //tongSoLuongXuat += chitiet.SoLuongXuat;
                }    
            }    
        }
        //if (SoLuongXuatStart <= tongSoLuongXuat && tongSoLuongXuat <= SoLuongXuatEnd)
        //    return 1;
        return 0;
    }

    private int KiemTraDonGiaXuat(DaiLy daily)
    {
        if (SelectedMatHang == null || (DonGiaXuatStart == 0 && DonGiaXuatEnd == 0))
            return 1;
        foreach (var phieu in daily.PhieuXuats)
        {
            foreach (var chitiet in phieu.ChiTietPhieuXuats)
            {
                if (chitiet.MatHang == SelectedMatHang && DonGiaXuatStart <= chitiet.DonGiaXuat && chitiet.DonGiaXuat <= DonGiaXuatEnd)
                    return 1;
            }
        }
        return 0;
    }

    //private int KiemTraThanhTienMatHangXuat(DaiLy daily)
    //{
    //}

    //private int KiemTraSoLuongTon(DaiLy daily)
    //{
    //}
    [RelayCommand]
    private void ThoatButton()
    {
        currentPopup?.CloseAsync();
    }

}
