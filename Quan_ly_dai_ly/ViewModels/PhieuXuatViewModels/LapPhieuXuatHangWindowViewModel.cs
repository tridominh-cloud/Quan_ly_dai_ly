using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.Services;
using Quan_ly_dai_ly.Utils;
using System.Collections.ObjectModel;


namespace Quan_ly_dai_ly.ViewModels.PhieuXuatViewModels;

public partial class LapPhieuXuatHangWindowViewModel : BaseViewModel
{
	private readonly IDaiLyService _daiLyService;
	private readonly ILoaiDaiLyService _loaiDaiLyService;
	private readonly IPhieuXuatService _phieuXuatService;
	private readonly IChiTietPhieuXuatService _chiTietPhieuXuatService;
	private readonly IMatHangService _matHangService;
	private readonly IDonViTinhService _donViTinhService;

	private Popup? currentPopup;
    public LapPhieuXuatHangWindowViewModel(IDaiLyService daiLyService,
										   ILoaiDaiLyService loaiDaiLyService,
										   IPhieuXuatService phieuXuatService,
										   IChiTietPhieuXuatService chiTietPhieuXuatService,
										   IMatHangService matHangService,
										   IDonViTinhService donViTinhService)
	{
		_daiLyService = daiLyService;
		_loaiDaiLyService = loaiDaiLyService;
		_phieuXuatService = phieuXuatService;
		_chiTietPhieuXuatService = chiTietPhieuXuatService;
		_matHangService = matHangService;
		_donViTinhService = donViTinhService;

		_ = LoadDataAsync();
	}
	public void SetPopupReference(Popup popup)
	{
		currentPopup = popup;
	}

	[ObservableProperty] private int maPhieuXuat =0;
	[ObservableProperty] private double noDaiLy;
	[ObservableProperty] private double noToiDa = 0;
    [ObservableProperty] private DateTime ngayLap = DateTime.Now;

	[ObservableProperty] private int sTT = 0;
	[ObservableProperty] private string tenDonViTinh = string.Empty;
	[ObservableProperty] private int soLuongTon = 0;
	
    [ObservableProperty] private ObservableCollection<DaiLy> daiLies = [];
    [ObservableProperty] private DaiLy selectedDaiLy = null!;

    [ObservableProperty] private ObservableCollection<MatHang> matHangs = [];

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(TongTien))]
	private ObservableCollection<DongHienThi> danhSachHienThi = [];
    public long TongTien => DanhSachHienThi.Sum(x => x.ThanhTien);
    private async Task LoadDataAsync()
	{
		try
		{
			var dailies = await _daiLyService.GetAllDaiLiesAsync();
			var mathangs = await _matHangService.GetAllMatHangsAsync();

			DaiLies = new ObservableCollection<DaiLy>(dailies);
			MatHangs = new ObservableCollection<MatHang>(mathangs);

			MaPhieuXuat = await _phieuXuatService.GetNextAvailableIdAsync();

			DanhSachHienThi.Clear();

            for (int i = 0; i < MatHangs.Count(); i++)
            {
                var dong = CreateDongHienThi(i + 1);
				SubscribeThanhTien_TongTien(dong);
                DanhSachHienThi.Add(dong);
            }
        }
		catch (Exception ex) 
		{
			await AlertUtil.ShowErrorAlert($"Lỗi: {ex}");
		}
	}

    [RelayCommand]
	private async Task LapPhieuXuatButton()
	{
		try
		{
            var newPhieuXuat = new PhieuXuat
            {
                MaPhieuXuat = MaPhieuXuat,
                MaDaiLy = SelectedDaiLy.MaDaily,
                NgayLap = NgayLap,
                TongGiaTri = TongTien
            };
            await _phieuXuatService.AddPhieuXuatAsync(newPhieuXuat);
			
			foreach(var ct in DanhSachHienThi.Where(x => x.SelectedMatHang?.MaMatHang != 0))
			{
				var chiTiet = new ChiTietPhieuXuat
				{
					MaChiTietPhieuXuat = await _chiTietPhieuXuatService.GetNextAvailableIdAsync(),
					MaPhieuXuat = newPhieuXuat.MaPhieuXuat,
					MaMatHang = ct.SelectedMatHang?.MaMatHang ?? 0,
					SoLuongXuat = ct.SoLuongXuat ?? 0,
					DonGiaXuat = ct.DonGiaXuat ?? 0
				};
                await _chiTietPhieuXuatService.AddChiTietPhieuXuatAsync(chiTiet);
            }	

            await AlertUtil.ShowSuccessAlert("Thêm phiếu xuất thành công");
            currentPopup?.CloseAsync();
        }
		catch (Exception ex)
		{
			await AlertUtil.ShowErrorAlert($"Lỗi: {ex}");
		}
	}
	[RelayCommand]
	private void PhieuXuatMoiButton()
	{
		foreach (var ht in DanhSachHienThi)
		{
			ht.SelectedMatHang = null;
			ht.SoLuongXuat = 0;
			ht.DonGiaXuat = 0;
		}	
	}
	[RelayCommand]
	private void ThoatButton()
	{
		currentPopup?.CloseAsync();
	}
	private DongHienThi CreateDongHienThi(int stt)
	{
		var donghienthi = new DongHienThi
		{
			STT = stt,
			SelectedMatHang = new MatHang
			{
				MaMatHang = 0,
				TenMatHang = string.Empty,
				MaDonViTinh = 0,
				SoLuongTon = 0
			},
			SoLuongXuat = 0,
			DonGiaXuat = 0
		};
		return donghienthi;
	}
	private void SubscribeThanhTien_TongTien(DongHienThi dongHienThi)
    {
        dongHienThi.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(DongHienThi.ThanhTien))
                OnPropertyChanged(nameof(TongTien));
        };
    }
    public partial class DongHienThi : ObservableObject
    {
		[ObservableProperty]
		public int sTT = 0;
		[ObservableProperty]
		private MatHang? selectedMatHang;
        
		[ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ThanhTien))]
        private int? soLuongXuat = 0;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ThanhTien))]
        private int? donGiaXuat = 0;

        public long ThanhTien => (SoLuongXuat ?? 0) * (DonGiaXuat ?? 0);
    }
}
//hiện tại tôi muốn lấy mã mặt hàng từ picker mặt hàng, mà picker đó nằm trong collectionview nên sẽ có nhiều picker, làm sao để lấy 1 mã mặt hành cụ thể
