using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quan_ly_dai_ly.Models;
using Quan_ly_dai_ly.Services;
using Quan_ly_dai_ly.Utils;
using System.Collections.ObjectModel;
using System.Drawing.Printing;


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
    [ObservableProperty] private MatHang selectedMatHang = null!;

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
			for (int i=0; i<MatHangs.Count();i++)
			{
				DanhSachHienThi.Add(new DongHienThi
				{
					STT = i + 1,
					Item = new MatHang
					{
						MaMatHang = 0,
						TenMatHang = string.Empty,
                        MaDonViTinh = 0,
						SoLuongTon = 0
					},
					SoLuongXuat = 0,
					DonGiaXuat = 0,
				});
			}	
            //if (DaiLies.Any() && MatHangs.Any())
            //{
            //	SelectedDaiLy = DaiLies[0];
            //	SelectedMatHang = MatHangs[0];
            //	NoDaiLy = SelectedDaiLy.NoDaiLy;
            //	NoToiDa = SelectedDaiLy.LoaiDaiLy.NoToiDa;
            //}
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
            await AlertUtil.ShowSuccessAlert("Thêm phiếu xuất thành công");

            currentPopup?.CloseAsync();
        }
		catch (Exception ex)
		{
			await AlertUtil.ShowErrorAlert($"Lỗi: {ex}");
		}
	}

	[RelayCommand]
	private void ThoatButton()
	{
		currentPopup?.CloseAsync();
	}

    public partial class DongHienThi : ObservableObject
    {
        public int STT { get; set; }
		[ObservableProperty]
		private MatHang? item;
        
		[ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ThanhTien))]
        private int? soLuongXuat = 0;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ThanhTien))]
        private int? donGiaXuat = 0;

        public long ThanhTien => (SoLuongXuat ?? 0) * (DonGiaXuat ?? 0);
    }
}