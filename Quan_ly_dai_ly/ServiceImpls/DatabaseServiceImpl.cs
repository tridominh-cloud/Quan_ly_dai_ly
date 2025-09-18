using Quan_ly_dai_ly.Configs;
using Quan_ly_dai_ly.Services;
using Quan_ly_dai_ly.Models;
using System.Diagnostics;
using System.Net.WebSockets;
namespace Quan_ly_dai_ly.ServiceImpls;

public class DatabaseServiceImpl : DatabaseService
{
    private readonly DataBaseConfig databaseConfig;
    public DatabaseServiceImpl(DataBaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
    }

    public async Task InitializeAsync()
    {
        await databaseConfig.Initialize();
        await SeedData();
    }
    private async Task SeedData()
    {
        var context = databaseConfig.DataContext;
        Debug.WriteLine("Begin");
        if (context.Quans.Any() || context.LoaiDaiLies.Any() || context.DaiLies.Any() || context.ThamSos.Any())
        {
            return;
        }
        Debug.WriteLine("Init db");

        var quans = new List<Quan>
        {
            new Quan { TenQuan = "Quan 1", MaQuan = 1},
            new Quan { TenQuan = "Quan 3", MaQuan = 3},
            new Quan { TenQuan = "Quan 5", MaQuan = 5},
            new Quan { TenQuan = "Quan 7", MaQuan = 7}
        };
        context.Quans.AddRange(quans);
        await context.SaveChangesAsync();

        var loaiDaiLies = new List<LoaiDaiLy>
        {
            new LoaiDaiLy {TenLoaiDaiLy = "Loai I", NoToiDa = 5000000, MaLoaiDaiLy = 1},
            new LoaiDaiLy {TenLoaiDaiLy = "Loai II", NoToiDa = 5000000, MaLoaiDaiLy = 2}
        };
        context.LoaiDaiLies.AddRange(loaiDaiLies);
        await context.SaveChangesAsync();

        var seedDate = new DateTime(2023, 1, 1);
        var dailies = new List<DaiLy>
        {
            new DaiLy { MaDaily = 1, Ten = "Minh Phát", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "12 Nguyễn Huệ", DienThoai = "0900000000", Email = "MinhPhát@gmail.com", NgayTiepNhan = seedDate.AddMonths(-1), NoDaiLy = 1000000L },
            new DaiLy { MaDaily = 2, Ten = "Hoàng Gia", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "45 Lê Lợi", DienThoai = "0900000001", Email = "HoàngGia@gmail.com", NgayTiepNhan = seedDate.AddMonths(-2), NoDaiLy = 2000000L },
            new DaiLy { MaDaily = 3, Ten = "Thịnh Vượng", MaLoaiDaiLy = 1, MaQuan = 5, DiaChi = "78 Nguyễn Trãi", DienThoai = "0900000002", Email = "ThịnhVượng@gmail.com", NgayTiepNhan = seedDate.AddMonths(-3), NoDaiLy = 3000000L },
            new DaiLy { MaDaily = 4, Ten = "Thành Công", MaLoaiDaiLy = 2, MaQuan = 7, DiaChi = "32 Lý Tự Trọng", DienThoai = "0900000003", Email = "ThànhCông@gmail.com", NgayTiepNhan = seedDate.AddMonths(-4), NoDaiLy = 4000000L },
            new DaiLy { MaDaily = 5, Ten = "Phú Quý", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "90 Trần Hưng Đạo", DienThoai = "0900000004", Email = "PhúQuý@gmail.com", NgayTiepNhan = seedDate.AddMonths(-5), NoDaiLy = 5000000L },
            new DaiLy { MaDaily = 6, Ten = "Hưng Thịnh", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "56 Pasteur", DienThoai = "0900000005", Email = "HưngThịnh@gmail.com", NgayTiepNhan = seedDate.AddMonths(-6), NoDaiLy = 6000000L },
            new DaiLy { MaDaily = 7, Ten = "An Khang", MaLoaiDaiLy = 1, MaQuan = 5, DiaChi = "88 Cách Mạng Tháng 8", DienThoai = "0900000006", Email = "AnKhang@gmail.com", NgayTiepNhan = seedDate.AddMonths(-1), NoDaiLy = 7000000L },
            new DaiLy { MaDaily = 8, Ten = "Đại Phát", MaLoaiDaiLy = 2, MaQuan = 7, DiaChi = "101 Hai Bà Trưng", DienThoai = "0900000007", Email = "ĐạiPhát@gmail.com", NgayTiepNhan = seedDate.AddMonths(-2), NoDaiLy = 8000000L },
            new DaiLy { MaDaily = 9, Ten = "Gia Hưng", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "67 Điện Biên Phủ", DienThoai = "0900000008", Email = "GiaHưng@gmail.com", NgayTiepNhan = seedDate.AddMonths(-3), NoDaiLy = 9000000L },
            new DaiLy { MaDaily = 10, Ten = "Kim Long", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "22 Nguyễn Thị Minh Khai", DienThoai = "0900000009", Email = "KimLong@gmail.com", NgayTiepNhan = seedDate.AddMonths(-4), NoDaiLy = 10000000L },
            
            new DaiLy { MaDaily = 11, Ten = "Ngọc Bảo", MaLoaiDaiLy = 1, MaQuan = 5, DiaChi = "134 Võ Văn Tần", DienThoai = "0900000010", Email = "NgọcBảo@gmail.com", NgayTiepNhan = seedDate.AddMonths(-5), NoDaiLy = 11000000L },
            new DaiLy { MaDaily = 12, Ten = "Tấn Tài", MaLoaiDaiLy = 2, MaQuan = 7, DiaChi = "76 Phan Đình Phùng", DienThoai = "0900000011", Email = "TấnTài@gmail.com", NgayTiepNhan = seedDate.AddMonths(-6), NoDaiLy = 12000000L },
            new DaiLy { MaDaily = 13, Ten = "Đức Phát", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "55 Lý Thường Kiệt", DienThoai = "0900000012", Email = "ĐứcPhát@gmail.com", NgayTiepNhan = seedDate.AddMonths(-1), NoDaiLy = 13000000L },
            new DaiLy { MaDaily = 14, Ten = "Lộc Phát", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "98 Nguyễn Văn Cừ", DienThoai = "0900000013", Email = "LộcPhát@gmail.com", NgayTiepNhan = seedDate.AddMonths(-2), NoDaiLy = 14000000L },
            new DaiLy { MaDaily = 15, Ten = "Hòa Bình", MaLoaiDaiLy = 1, MaQuan = 5, DiaChi = "41 Nguyễn Đình Chiểu", DienThoai = "0900000014", Email = "HòaBình@gmail.com", NgayTiepNhan = seedDate.AddMonths(-3), NoDaiLy = 15000000L },
            new DaiLy { MaDaily = 16, Ten = "Thái Bình", MaLoaiDaiLy = 2, MaQuan = 7, DiaChi = "72 Bùi Thị Xuân", DienThoai = "0900000015", Email = "TháiBình@gmail.com", NgayTiepNhan = seedDate.AddMonths(-4), NoDaiLy = 16000000L },
            new DaiLy { MaDaily = 17, Ten = "Thanh Hưng", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "25 Trần Quốc Thảo", DienThoai = "0900000016", Email = "ThanhHưng@gmail.com", NgayTiepNhan = seedDate.AddMonths(-5), NoDaiLy = 17000000L },
            new DaiLy { MaDaily = 18, Ten = "Quang Minh", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "63 Nguyễn Thái Học", DienThoai = "0900000017", Email = "QuangMinh@gmail.com", NgayTiepNhan = seedDate.AddMonths(-6), NoDaiLy = 18000000L },
            new DaiLy { MaDaily = 19, Ten = "Phát Đạt", MaLoaiDaiLy = 1, MaQuan = 5, DiaChi = "11 Cách Mạng Tháng 8", DienThoai = "0900000018", Email = "PhátĐạt@gmail.com", NgayTiepNhan = seedDate.AddMonths(-1), NoDaiLy = 19000000L },
            new DaiLy { MaDaily = 20, Ten = "Tân Tiến", MaLoaiDaiLy = 2, MaQuan = 7, DiaChi = "84 Tôn Đức Thắng", DienThoai = "0900000019", Email = "TânTiến@gmail.com", NgayTiepNhan = seedDate.AddMonths(-2), NoDaiLy = 20000000L },
            
            new DaiLy { MaDaily = 21, Ten = "Đại Lộc", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "109 Võ Văn Kiệt", DienThoai = "0900000020", Email = "ĐạiLộc@gmail.com", NgayTiepNhan = seedDate.AddMonths(-3), NoDaiLy = 21000000L },
            new DaiLy { MaDaily = 22, Ten = "Vĩnh Phát", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "44 Nguyễn Văn Linh", DienThoai = "0900000021", Email = "VĩnhPhát@gmail.com", NgayTiepNhan = seedDate.AddMonths(-4), NoDaiLy = 22000000L },
            new DaiLy { MaDaily = 23, Ten = "Thái Hưng", MaLoaiDaiLy = 1, MaQuan = 5, DiaChi = "58 Điện Biên Phủ", DienThoai = "0900000022", Email = "TháiHưng@gmail.com", NgayTiepNhan = seedDate.AddMonths(-5), NoDaiLy = 23000000L },
            new DaiLy { MaDaily = 24, Ten = "Ngọc Thịnh", MaLoaiDaiLy = 2, MaQuan = 7, DiaChi = "92 Phạm Văn Đồng", DienThoai = "0900000023", Email = "NgọcThịnh@gmail.com", NgayTiepNhan = seedDate.AddMonths(-6), NoDaiLy = 24000000L },
            new DaiLy { MaDaily = 25, Ten = "Hoàng Phát", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "33 Lê Văn Sỹ", DienThoai = "0900000024", Email = "HoàngPhát@gmail.com", NgayTiepNhan = seedDate.AddMonths(-1), NoDaiLy = 25000000L },
            new DaiLy { MaDaily = 26, Ten = "Thành Đạt", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "77 Nguyễn Hữu Cảnh", DienThoai = "0900000025", Email = "ThànhĐạt@gmail.com", NgayTiepNhan = seedDate.AddMonths(-2), NoDaiLy = 26000000L },
            new DaiLy { MaDaily = 27, Ten = "An Phú", MaLoaiDaiLy = 1, MaQuan = 5, DiaChi = "12 Phạm Hồng Thái", DienThoai = "0900000026", Email = "AnPhú@gmail.com", NgayTiepNhan = seedDate.AddMonths(-3), NoDaiLy = 27000000L },
            new DaiLy { MaDaily = 28, Ten = "Phú Thịnh", MaLoaiDaiLy = 2, MaQuan = 7, DiaChi = "60 Nguyễn Trãi", DienThoai = "0900000027", Email = "PhúThịnh@gmail.com", NgayTiepNhan = seedDate.AddMonths(-4), NoDaiLy = 28000000L },
            new DaiLy { MaDaily = 29, Ten = "Thịnh An", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "26 Trường Chinh", DienThoai = "0900000028", Email = "ThịnhAn@gmail.com", NgayTiepNhan = seedDate.AddMonths(-5), NoDaiLy = 29000000L },
            new DaiLy { MaDaily = 30, Ten = "Kim Phát", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "39 Hoàng Văn Thụ", DienThoai = "0900000029", Email = "KimPhát@gmail.com", NgayTiepNhan = seedDate.AddMonths(-6), NoDaiLy = 30000000L },
            
            new DaiLy { MaDaily = 31, Ten = "Ngọc An", MaLoaiDaiLy = 1, MaQuan = 5, DiaChi = "81 Lý Thái Tổ", DienThoai = "0900000030", Email = "NgọcAn@gmail.com", NgayTiepNhan = seedDate.AddMonths(-1), NoDaiLy = 31000000L },
            new DaiLy { MaDaily = 32, Ten = "Đức Hòa", MaLoaiDaiLy = 2, MaQuan = 7, DiaChi = "54 Nguyễn Văn Cừ", DienThoai = "0900000031", Email = "ĐứcHòa@gmail.com", NgayTiepNhan = seedDate.AddMonths(-2), NoDaiLy = 32000000L },
            new DaiLy { MaDaily = 33, Ten = "Tân Hòa", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "18 Tôn Thất Tùng", DienThoai = "0900000032", Email = "TânHòa@gmail.com", NgayTiepNhan = seedDate.AddMonths(-3), NoDaiLy = 33000000L },
            new DaiLy { MaDaily = 34, Ten = "Quang Huy", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "69 Võ Thị Sáu", DienThoai = "0900000033", Email = "QuangHuy@gmail.com", NgayTiepNhan = seedDate.AddMonths(-4), NoDaiLy = 34000000L },
            new DaiLy { MaDaily = 35, Ten = "An Hưng", MaLoaiDaiLy = 1, MaQuan = 5, DiaChi = "24 Nam Kỳ Khởi Nghĩa", DienThoai = "0900000034", Email = "AnHưng@gmail.com", NgayTiepNhan = seedDate.AddMonths(-5), NoDaiLy = 35000000L },
            new DaiLy { MaDaily = 36, Ten = "Gia Phát", MaLoaiDaiLy = 2, MaQuan = 7, DiaChi = "91 Nguyễn Thái Bình", DienThoai = "0900000035", Email = "GiaPhát@gmail.com", NgayTiepNhan = seedDate.AddMonths(-6), NoDaiLy = 36000000L },
            new DaiLy { MaDaily = 37, Ten = "Lộc Tài", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "36 Bạch Đằng", DienThoai = "0900000036", Email = "LộcTài@gmail.com", NgayTiepNhan = seedDate.AddMonths(-1), NoDaiLy = 37000000L },
            new DaiLy { MaDaily = 38, Ten = "Phú Mỹ", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "73 Nguyễn Khắc Nhu", DienThoai = "0900000037", Email = "PhúMỹ@gmail.com", NgayTiepNhan = seedDate.AddMonths(-2), NoDaiLy = 38000000L },
            new DaiLy { MaDaily = 39, Ten = "Đại An", MaLoaiDaiLy = 1, MaQuan = 5, DiaChi = "42 Nguyễn Tri Phương", DienThoai = "0900000038", Email = "ĐạiAn@gmail.com", NgayTiepNhan = seedDate.AddMonths(-3), NoDaiLy = 39000000L },
            new DaiLy { MaDaily = 40, Ten = "Hòa Phát", MaLoaiDaiLy = 2, MaQuan = 7, DiaChi = "65 Nguyễn Chí Thanh", DienThoai = "0900000039", Email = "HòaPhát@gmail.com", NgayTiepNhan = seedDate.AddMonths(-4), NoDaiLy = 40000000L },
            
            new DaiLy { MaDaily = 41, Ten = "Kim Thịnh", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "13 Lê Quang Định", DienThoai = "0900000040", Email = "KimThịnh@gmail.com", NgayTiepNhan = seedDate.AddMonths(-5), NoDaiLy = 41000000L },
            new DaiLy { MaDaily = 42, Ten = "Ngọc Minh", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "29 Cộng Hòa", DienThoai = "0900000041", Email = "NgọcMinh@gmail.com", NgayTiepNhan = seedDate.AddMonths(-6), NoDaiLy = 42000000L },
            new DaiLy { MaDaily = 43, Ten = "Tân Thành", MaLoaiDaiLy = 1, MaQuan = 5, DiaChi = "47 Trần Văn Đang", DienThoai = "0900000042", Email = "TânThành@gmail.com", NgayTiepNhan = seedDate.AddMonths(-1), NoDaiLy = 43000000L },
            new DaiLy { MaDaily = 44, Ten = "Phát Hưng", MaLoaiDaiLy = 2, MaQuan = 7, DiaChi = "85 Nguyễn Kiệm", DienThoai = "0900000043", Email = "PhátHưng@gmail.com", NgayTiepNhan = seedDate.AddMonths(-2), NoDaiLy = 44000000L },
            new DaiLy { MaDaily = 45, Ten = "Minh Tâm", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "20 Ung Văn Khiêm", DienThoai = "0900000044", Email = "MinhTâm@gmail.com", NgayTiepNhan = seedDate.AddMonths(-3), NoDaiLy = 45000000L },
            new DaiLy { MaDaily = 46, Ten = "Đại Thành", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "31 Xô Viết Nghệ Tĩnh", DienThoai = "0900000045", Email = "ĐạiThành@gmail.com", NgayTiepNhan = seedDate.AddMonths(-4), NoDaiLy = 46000000L },
            new DaiLy { MaDaily = 47, Ten = "Hưng Phú", MaLoaiDaiLy = 1, MaQuan = 5, DiaChi = "57 Phan Xích Long", DienThoai = "0900000046", Email = "HưngPhú@gmail.com", NgayTiepNhan = seedDate.AddMonths(-5), NoDaiLy = 47000000L },
            new DaiLy { MaDaily = 48, Ten = "An Lộc", MaLoaiDaiLy = 2, MaQuan = 7, DiaChi = "14 Hoàng Hoa Thám", DienThoai = "0900000047", Email = "AnLộc@gmail.com", NgayTiepNhan = seedDate.AddMonths(-6), NoDaiLy = 48000000L },
            new DaiLy { MaDaily = 49, Ten = "Thành Phú", MaLoaiDaiLy = 1, MaQuan = 1, DiaChi = "99 Nguyễn Văn Nghi", DienThoai = "0900000048", Email = "ThànhPhú@gmail.com", NgayTiepNhan = seedDate.AddMonths(-1), NoDaiLy = 49000000L },
            new DaiLy { MaDaily = 50, Ten = "Hoàng Hưng", MaLoaiDaiLy = 2, MaQuan = 3, DiaChi = "71 Tô Hiến Thành", DienThoai = "0900000049", Email = "HoàngHưng@gmail.com", NgayTiepNhan = seedDate.AddMonths(-2), NoDaiLy = 50000000L }
        };
        context.DaiLies.AddRange(dailies);
        await context.SaveChangesAsync();

        var thamSo = new ThamSo
        {
            TenThamSo = "SoLuongDaiLyToiDa",
            GiaTri = "50"
        };
        context.ThamSos.Add(thamSo);
        await context.SaveChangesAsync();

        var phieuxuats = new List<PhieuXuat>
        {
            new PhieuXuat { MaPhieuXuat = 1, MaDaiLy = 1, NgayLap = seedDate.AddDays(-1), TongGiaTri = 100000 },
            new PhieuXuat { MaPhieuXuat = 2, MaDaiLy = 2, NgayLap = seedDate.AddDays(-2), TongGiaTri = 200000 },
            new PhieuXuat { MaPhieuXuat = 3, MaDaiLy = 3, NgayLap = seedDate.AddDays(-3), TongGiaTri = 300000 },
            new PhieuXuat { MaPhieuXuat = 4, MaDaiLy = 4, NgayLap = seedDate.AddDays(-4), TongGiaTri = 400000 },
            new PhieuXuat { MaPhieuXuat = 5, MaDaiLy = 5, NgayLap = seedDate.AddDays(-5), TongGiaTri = 500000 },
            new PhieuXuat { MaPhieuXuat = 6, MaDaiLy = 6, NgayLap = seedDate.AddDays(-6), TongGiaTri = 600000 },
            new PhieuXuat { MaPhieuXuat = 7, MaDaiLy = 7, NgayLap = seedDate.AddDays(-7), TongGiaTri = 700000 },
            new PhieuXuat { MaPhieuXuat = 8, MaDaiLy = 8, NgayLap = seedDate.AddDays(-8), TongGiaTri = 800000 },
            new PhieuXuat { MaPhieuXuat = 9, MaDaiLy = 9, NgayLap = seedDate.AddDays(-9), TongGiaTri = 900000 },
            new PhieuXuat { MaPhieuXuat = 10, MaDaiLy = 10, NgayLap = seedDate.AddDays(-10), TongGiaTri = 1000000 },

            new PhieuXuat { MaPhieuXuat = 11, MaDaiLy = 11, NgayLap = seedDate.AddDays(-11), TongGiaTri = 1100000 },
            new PhieuXuat { MaPhieuXuat = 12, MaDaiLy = 12, NgayLap = seedDate.AddDays(-12), TongGiaTri = 1200000 },
            new PhieuXuat { MaPhieuXuat = 13, MaDaiLy = 13, NgayLap = seedDate.AddDays(-13), TongGiaTri = 1300000 },
            new PhieuXuat { MaPhieuXuat = 14, MaDaiLy = 14, NgayLap = seedDate.AddDays(-14), TongGiaTri = 1400000 },
            new PhieuXuat { MaPhieuXuat = 15, MaDaiLy = 15, NgayLap = seedDate.AddDays(-15), TongGiaTri = 1500000 },
            new PhieuXuat { MaPhieuXuat = 16, MaDaiLy = 16, NgayLap = seedDate.AddDays(-16), TongGiaTri = 1600000 },
            new PhieuXuat { MaPhieuXuat = 17, MaDaiLy = 17, NgayLap = seedDate.AddDays(-17), TongGiaTri = 1700000 },
            new PhieuXuat { MaPhieuXuat = 18, MaDaiLy = 18, NgayLap = seedDate.AddDays(-18), TongGiaTri = 1800000 },
            new PhieuXuat { MaPhieuXuat = 19, MaDaiLy = 19, NgayLap = seedDate.AddDays(-19), TongGiaTri = 1900000 },
            new PhieuXuat { MaPhieuXuat = 20, MaDaiLy = 20, NgayLap = seedDate.AddDays(-20), TongGiaTri = 2000000 },

            new PhieuXuat { MaPhieuXuat = 21, MaDaiLy = 21, NgayLap = seedDate.AddDays(-21), TongGiaTri = 2100000 },
            new PhieuXuat { MaPhieuXuat = 22, MaDaiLy = 22, NgayLap = seedDate.AddDays(-22), TongGiaTri = 2200000 },
            new PhieuXuat { MaPhieuXuat = 23, MaDaiLy = 23, NgayLap = seedDate.AddDays(-23), TongGiaTri = 2300000 },
            new PhieuXuat { MaPhieuXuat = 24, MaDaiLy = 24, NgayLap = seedDate.AddDays(-24), TongGiaTri = 2400000 },
            new PhieuXuat { MaPhieuXuat = 25, MaDaiLy = 25, NgayLap = seedDate.AddDays(-25), TongGiaTri = 2500000 },
            new PhieuXuat { MaPhieuXuat = 26, MaDaiLy = 26, NgayLap = seedDate.AddDays(-26), TongGiaTri = 2600000 },
            new PhieuXuat { MaPhieuXuat = 27, MaDaiLy = 27, NgayLap = seedDate.AddDays(-27), TongGiaTri = 2700000 },
            new PhieuXuat { MaPhieuXuat = 28, MaDaiLy = 28, NgayLap = seedDate.AddDays(-28), TongGiaTri = 2800000 },
            new PhieuXuat { MaPhieuXuat = 29, MaDaiLy = 29, NgayLap = seedDate.AddDays(-29), TongGiaTri = 2900000 },
            new PhieuXuat { MaPhieuXuat = 30, MaDaiLy = 30, NgayLap = seedDate.AddDays(-30), TongGiaTri = 3000000 },

            new PhieuXuat { MaPhieuXuat = 31, MaDaiLy = 31, NgayLap = seedDate.AddDays(-31), TongGiaTri = 3100000 },
            new PhieuXuat { MaPhieuXuat = 32, MaDaiLy = 32, NgayLap = seedDate.AddDays(-32), TongGiaTri = 3200000 },
            new PhieuXuat { MaPhieuXuat = 33, MaDaiLy = 33, NgayLap = seedDate.AddDays(-33), TongGiaTri = 3300000 },
            new PhieuXuat { MaPhieuXuat = 34, MaDaiLy = 34, NgayLap = seedDate.AddDays(-34), TongGiaTri = 3400000 },
            new PhieuXuat { MaPhieuXuat = 35, MaDaiLy = 35, NgayLap = seedDate.AddDays(-35), TongGiaTri = 3500000 },
            new PhieuXuat { MaPhieuXuat = 36, MaDaiLy = 36, NgayLap = seedDate.AddDays(-36), TongGiaTri = 3600000 },
            new PhieuXuat { MaPhieuXuat = 37, MaDaiLy = 37, NgayLap = seedDate.AddDays(-37), TongGiaTri = 3700000 },
            new PhieuXuat { MaPhieuXuat = 38, MaDaiLy = 38, NgayLap = seedDate.AddDays(-38), TongGiaTri = 3800000 },
            new PhieuXuat { MaPhieuXuat = 39, MaDaiLy = 39, NgayLap = seedDate.AddDays(-39), TongGiaTri = 3900000 },
            new PhieuXuat { MaPhieuXuat = 40, MaDaiLy = 40, NgayLap = seedDate.AddDays(-40), TongGiaTri = 4000000 },

            new PhieuXuat { MaPhieuXuat = 41, MaDaiLy = 41, NgayLap = seedDate.AddDays(-41), TongGiaTri = 4100000 },
            new PhieuXuat { MaPhieuXuat = 42, MaDaiLy = 42, NgayLap = seedDate.AddDays(-42), TongGiaTri = 4200000 },
            new PhieuXuat { MaPhieuXuat = 43, MaDaiLy = 43, NgayLap = seedDate.AddDays(-43), TongGiaTri = 4300000 },
            new PhieuXuat { MaPhieuXuat = 44, MaDaiLy = 44, NgayLap = seedDate.AddDays(-44), TongGiaTri = 4400000 },
            new PhieuXuat { MaPhieuXuat = 45, MaDaiLy = 45, NgayLap = seedDate.AddDays(-45), TongGiaTri = 4500000 },
            new PhieuXuat { MaPhieuXuat = 46, MaDaiLy = 46, NgayLap = seedDate.AddDays(-46), TongGiaTri = 4600000 },
            new PhieuXuat { MaPhieuXuat = 47, MaDaiLy = 47, NgayLap = seedDate.AddDays(-47), TongGiaTri = 4700000 },
            new PhieuXuat { MaPhieuXuat = 48, MaDaiLy = 48, NgayLap = seedDate.AddDays(-48), TongGiaTri = 4800000 },
            new PhieuXuat { MaPhieuXuat = 49, MaDaiLy = 49, NgayLap = seedDate.AddDays(-49), TongGiaTri = 4900000 },
            new PhieuXuat { MaPhieuXuat = 50, MaDaiLy = 50, NgayLap = seedDate.AddDays(-50), TongGiaTri = 5000000 },

            new PhieuXuat { MaPhieuXuat = 51, MaDaiLy = 1, NgayLap = seedDate.AddDays(-51), TongGiaTri = 5100000 },
            new PhieuXuat { MaPhieuXuat = 52, MaDaiLy = 2, NgayLap = seedDate.AddDays(-52), TongGiaTri = 5200000 },
            new PhieuXuat { MaPhieuXuat = 53, MaDaiLy = 3, NgayLap = seedDate.AddDays(-53), TongGiaTri = 5300000 },
            new PhieuXuat { MaPhieuXuat = 54, MaDaiLy = 4, NgayLap = seedDate.AddDays(-54), TongGiaTri = 5400000 },
            new PhieuXuat { MaPhieuXuat = 55, MaDaiLy = 5, NgayLap = seedDate.AddDays(-55), TongGiaTri = 5500000 },
            new PhieuXuat { MaPhieuXuat = 56, MaDaiLy = 6, NgayLap = seedDate.AddDays(-56), TongGiaTri = 5600000 },
            new PhieuXuat { MaPhieuXuat = 57, MaDaiLy = 7, NgayLap = seedDate.AddDays(-57), TongGiaTri = 5700000 },
            new PhieuXuat { MaPhieuXuat = 58, MaDaiLy = 8, NgayLap = seedDate.AddDays(-58), TongGiaTri = 5800000 },
            new PhieuXuat { MaPhieuXuat = 59, MaDaiLy = 9, NgayLap = seedDate.AddDays(-59), TongGiaTri = 5900000 },
            new PhieuXuat { MaPhieuXuat = 60, MaDaiLy = 10, NgayLap = seedDate.AddDays(-60), TongGiaTri = 6000000 },

            new PhieuXuat { MaPhieuXuat = 61, MaDaiLy = 11, NgayLap = seedDate.AddDays(-61), TongGiaTri = 6100000 },
            new PhieuXuat { MaPhieuXuat = 62, MaDaiLy = 12, NgayLap = seedDate.AddDays(-62), TongGiaTri = 6200000 },
            new PhieuXuat { MaPhieuXuat = 63, MaDaiLy = 13, NgayLap = seedDate.AddDays(-63), TongGiaTri = 6300000 },
            new PhieuXuat { MaPhieuXuat = 64, MaDaiLy = 14, NgayLap = seedDate.AddDays(-64), TongGiaTri = 6400000 },
            new PhieuXuat { MaPhieuXuat = 65, MaDaiLy = 15, NgayLap = seedDate.AddDays(-65), TongGiaTri = 6500000 },
            new PhieuXuat { MaPhieuXuat = 66, MaDaiLy = 16, NgayLap = seedDate.AddDays(-66), TongGiaTri = 6600000 },
            new PhieuXuat { MaPhieuXuat = 67, MaDaiLy = 17, NgayLap = seedDate.AddDays(-67), TongGiaTri = 6700000 },
            new PhieuXuat { MaPhieuXuat = 68, MaDaiLy = 18, NgayLap = seedDate.AddDays(-68), TongGiaTri = 6800000 },
            new PhieuXuat { MaPhieuXuat = 69, MaDaiLy = 19, NgayLap = seedDate.AddDays(-69), TongGiaTri = 6900000 },
            new PhieuXuat { MaPhieuXuat = 70, MaDaiLy = 20, NgayLap = seedDate.AddDays(-70), TongGiaTri = 7000000 },

            new PhieuXuat { MaPhieuXuat = 71, MaDaiLy = 21, NgayLap = seedDate.AddDays(-71), TongGiaTri = 7100000 },
            new PhieuXuat { MaPhieuXuat = 72, MaDaiLy = 22, NgayLap = seedDate.AddDays(-72), TongGiaTri = 7200000 },
            new PhieuXuat { MaPhieuXuat = 73, MaDaiLy = 23, NgayLap = seedDate.AddDays(-73), TongGiaTri = 7300000 },
            new PhieuXuat { MaPhieuXuat = 74, MaDaiLy = 24, NgayLap = seedDate.AddDays(-74), TongGiaTri = 7400000 },
            new PhieuXuat { MaPhieuXuat = 75, MaDaiLy = 25, NgayLap = seedDate.AddDays(-75), TongGiaTri = 7500000 },
            new PhieuXuat { MaPhieuXuat = 76, MaDaiLy = 26, NgayLap = seedDate.AddDays(-76), TongGiaTri = 7600000 },
            new PhieuXuat { MaPhieuXuat = 77, MaDaiLy = 27, NgayLap = seedDate.AddDays(-77), TongGiaTri = 7700000 },
            new PhieuXuat { MaPhieuXuat = 78, MaDaiLy = 28, NgayLap = seedDate.AddDays(-78), TongGiaTri = 7800000 },
            new PhieuXuat { MaPhieuXuat = 79, MaDaiLy = 29, NgayLap = seedDate.AddDays(-79), TongGiaTri = 7900000 },
            new PhieuXuat { MaPhieuXuat = 80, MaDaiLy = 30, NgayLap = seedDate.AddDays(-80), TongGiaTri = 8000000 },

            new PhieuXuat { MaPhieuXuat = 81, MaDaiLy = 31, NgayLap = seedDate.AddDays(-81), TongGiaTri = 8100000 },
            new PhieuXuat { MaPhieuXuat = 82, MaDaiLy = 32, NgayLap = seedDate.AddDays(-82), TongGiaTri = 8200000 },
            new PhieuXuat { MaPhieuXuat = 83, MaDaiLy = 33, NgayLap = seedDate.AddDays(-83), TongGiaTri = 8300000 },
            new PhieuXuat { MaPhieuXuat = 84, MaDaiLy = 34, NgayLap = seedDate.AddDays(-84), TongGiaTri = 8400000 },
            new PhieuXuat { MaPhieuXuat = 85, MaDaiLy = 35, NgayLap = seedDate.AddDays(-85), TongGiaTri = 8500000 },
            new PhieuXuat { MaPhieuXuat = 86, MaDaiLy = 36, NgayLap = seedDate.AddDays(-86), TongGiaTri = 8600000 },
            new PhieuXuat { MaPhieuXuat = 87, MaDaiLy = 37, NgayLap = seedDate.AddDays(-87), TongGiaTri = 8700000 },
            new PhieuXuat { MaPhieuXuat = 88, MaDaiLy = 38, NgayLap = seedDate.AddDays(-88), TongGiaTri = 8800000 },
            new PhieuXuat { MaPhieuXuat = 89, MaDaiLy = 39, NgayLap = seedDate.AddDays(-89), TongGiaTri = 8900000 },
            new PhieuXuat { MaPhieuXuat = 90, MaDaiLy = 40, NgayLap = seedDate.AddDays(-90), TongGiaTri = 9000000 },

            new PhieuXuat { MaPhieuXuat = 91, MaDaiLy = 41, NgayLap = seedDate.AddDays(-91), TongGiaTri = 9100000 },
            new PhieuXuat { MaPhieuXuat = 92, MaDaiLy = 42, NgayLap = seedDate.AddDays(-92), TongGiaTri = 9200000 },
            new PhieuXuat { MaPhieuXuat = 93, MaDaiLy = 43, NgayLap = seedDate.AddDays(-93), TongGiaTri = 9300000 },
            new PhieuXuat { MaPhieuXuat = 94, MaDaiLy = 44, NgayLap = seedDate.AddDays(-94), TongGiaTri = 9400000 },
            new PhieuXuat { MaPhieuXuat = 95, MaDaiLy = 45, NgayLap = seedDate.AddDays(-95), TongGiaTri = 9500000 },
            new PhieuXuat { MaPhieuXuat = 96, MaDaiLy = 46, NgayLap = seedDate.AddDays(-96), TongGiaTri = 9600000 },
            new PhieuXuat { MaPhieuXuat = 97, MaDaiLy = 47, NgayLap = seedDate.AddDays(-97), TongGiaTri = 9700000 },
            new PhieuXuat { MaPhieuXuat = 98, MaDaiLy = 48, NgayLap = seedDate.AddDays(-98), TongGiaTri = 9800000 },
            new PhieuXuat { MaPhieuXuat = 99, MaDaiLy = 49, NgayLap = seedDate.AddDays(-99), TongGiaTri = 9900000 },
            new PhieuXuat { MaPhieuXuat = 100, MaDaiLy = 50, NgayLap = seedDate.AddDays(-100), TongGiaTri = 10000000 }
        };
        context.PhieuXuats.AddRange(phieuxuats);
        await context.SaveChangesAsync();

        var phieuthus = new List<PhieuThu>
        {
            new PhieuThu { MaPhieuThu = 1, MaDaiLy = 1, NgayThuTien = seedDate.AddDays(-1), SoTienThu = 100000 },
            new PhieuThu { MaPhieuThu = 2, MaDaiLy = 2, NgayThuTien = seedDate.AddDays(-2), SoTienThu = 200000 },
            new PhieuThu { MaPhieuThu = 3, MaDaiLy = 3, NgayThuTien = seedDate.AddDays(-3), SoTienThu = 300000 },
            new PhieuThu { MaPhieuThu = 4, MaDaiLy = 4, NgayThuTien = seedDate.AddDays(-4), SoTienThu = 400000 },
            new PhieuThu { MaPhieuThu = 5, MaDaiLy = 5, NgayThuTien = seedDate.AddDays(-5), SoTienThu = 500000 },
            new PhieuThu { MaPhieuThu = 6, MaDaiLy = 6, NgayThuTien = seedDate.AddDays(-6), SoTienThu = 600000 },
            new PhieuThu { MaPhieuThu = 7, MaDaiLy = 7, NgayThuTien = seedDate.AddDays(-7), SoTienThu = 700000 },
            new PhieuThu { MaPhieuThu = 8, MaDaiLy = 8, NgayThuTien = seedDate.AddDays(-8), SoTienThu = 800000 },
            new PhieuThu { MaPhieuThu = 9, MaDaiLy = 9, NgayThuTien = seedDate.AddDays(-9), SoTienThu = 900000 },
            new PhieuThu { MaPhieuThu = 10, MaDaiLy = 10, NgayThuTien = seedDate.AddDays(-10), SoTienThu = 1000000 },

            new PhieuThu { MaPhieuThu = 11, MaDaiLy = 11, NgayThuTien = seedDate.AddDays(-11), SoTienThu = 1100000 },
            new PhieuThu { MaPhieuThu = 12, MaDaiLy = 12, NgayThuTien = seedDate.AddDays(-12), SoTienThu = 1200000 },
            new PhieuThu { MaPhieuThu = 13, MaDaiLy = 13, NgayThuTien = seedDate.AddDays(-13), SoTienThu = 1300000 },
            new PhieuThu { MaPhieuThu = 14, MaDaiLy = 14, NgayThuTien = seedDate.AddDays(-14), SoTienThu = 1400000 },
            new PhieuThu { MaPhieuThu = 15, MaDaiLy = 15, NgayThuTien = seedDate.AddDays(-15), SoTienThu = 1500000 },
            new PhieuThu { MaPhieuThu = 16, MaDaiLy = 16, NgayThuTien = seedDate.AddDays(-16), SoTienThu = 1600000 },
            new PhieuThu { MaPhieuThu = 17, MaDaiLy = 17, NgayThuTien = seedDate.AddDays(-17), SoTienThu = 1700000 },
            new PhieuThu { MaPhieuThu = 18, MaDaiLy = 18, NgayThuTien = seedDate.AddDays(-18), SoTienThu = 1800000 },
            new PhieuThu { MaPhieuThu = 19, MaDaiLy = 19, NgayThuTien = seedDate.AddDays(-19), SoTienThu = 1900000 },
            new PhieuThu { MaPhieuThu = 20, MaDaiLy = 20, NgayThuTien = seedDate.AddDays(-20), SoTienThu = 2000000 },

            new PhieuThu { MaPhieuThu = 21, MaDaiLy = 21, NgayThuTien = seedDate.AddDays(-21), SoTienThu = 2100000 },
            new PhieuThu { MaPhieuThu = 22, MaDaiLy = 22, NgayThuTien = seedDate.AddDays(-22), SoTienThu = 2200000 },
            new PhieuThu { MaPhieuThu = 23, MaDaiLy = 23, NgayThuTien = seedDate.AddDays(-23), SoTienThu = 2300000 },
            new PhieuThu { MaPhieuThu = 24, MaDaiLy = 24, NgayThuTien = seedDate.AddDays(-24), SoTienThu = 2400000 },
            new PhieuThu { MaPhieuThu = 25, MaDaiLy = 25, NgayThuTien = seedDate.AddDays(-25), SoTienThu = 2500000 },
            new PhieuThu { MaPhieuThu = 26, MaDaiLy = 26, NgayThuTien = seedDate.AddDays(-26), SoTienThu = 2600000 },
            new PhieuThu { MaPhieuThu = 27, MaDaiLy = 27, NgayThuTien = seedDate.AddDays(-27), SoTienThu = 2700000 },
            new PhieuThu { MaPhieuThu = 28, MaDaiLy = 28, NgayThuTien = seedDate.AddDays(-28), SoTienThu = 2800000 },
            new PhieuThu { MaPhieuThu = 29, MaDaiLy = 29, NgayThuTien = seedDate.AddDays(-29), SoTienThu = 2900000 },
            new PhieuThu { MaPhieuThu = 30, MaDaiLy = 30, NgayThuTien = seedDate.AddDays(-30), SoTienThu = 3000000 },

            new PhieuThu { MaPhieuThu = 31, MaDaiLy = 31, NgayThuTien = seedDate.AddDays(-31), SoTienThu = 3100000 },
            new PhieuThu { MaPhieuThu = 32, MaDaiLy = 32, NgayThuTien = seedDate.AddDays(-32), SoTienThu = 3200000 },
            new PhieuThu { MaPhieuThu = 33, MaDaiLy = 33, NgayThuTien = seedDate.AddDays(-33), SoTienThu = 3300000 },
            new PhieuThu { MaPhieuThu = 34, MaDaiLy = 34, NgayThuTien = seedDate.AddDays(-34), SoTienThu = 3400000 },
            new PhieuThu { MaPhieuThu = 35, MaDaiLy = 35, NgayThuTien = seedDate.AddDays(-35), SoTienThu = 3500000 },
            new PhieuThu { MaPhieuThu = 36, MaDaiLy = 36, NgayThuTien = seedDate.AddDays(-36), SoTienThu = 3600000 },
            new PhieuThu { MaPhieuThu = 37, MaDaiLy = 37, NgayThuTien = seedDate.AddDays(-37), SoTienThu = 3700000 },
            new PhieuThu { MaPhieuThu = 38, MaDaiLy = 38, NgayThuTien = seedDate.AddDays(-38), SoTienThu = 3800000 },
            new PhieuThu { MaPhieuThu = 39, MaDaiLy = 39, NgayThuTien = seedDate.AddDays(-39), SoTienThu = 3900000 },
            new PhieuThu { MaPhieuThu = 40, MaDaiLy = 40, NgayThuTien = seedDate.AddDays(-40), SoTienThu = 4000000 },

            new PhieuThu { MaPhieuThu = 41, MaDaiLy = 41, NgayThuTien = seedDate.AddDays(-41), SoTienThu = 4100000 },
            new PhieuThu { MaPhieuThu = 42, MaDaiLy = 42, NgayThuTien = seedDate.AddDays(-42), SoTienThu = 4200000 },
            new PhieuThu { MaPhieuThu = 43, MaDaiLy = 43, NgayThuTien = seedDate.AddDays(-43), SoTienThu = 4300000 },
            new PhieuThu { MaPhieuThu = 44, MaDaiLy = 44, NgayThuTien = seedDate.AddDays(-44), SoTienThu = 4400000 },
            new PhieuThu { MaPhieuThu = 45, MaDaiLy = 45, NgayThuTien = seedDate.AddDays(-45), SoTienThu = 4500000 },
            new PhieuThu { MaPhieuThu = 46, MaDaiLy = 46, NgayThuTien = seedDate.AddDays(-46), SoTienThu = 4600000 },
            new PhieuThu { MaPhieuThu = 47, MaDaiLy = 47, NgayThuTien = seedDate.AddDays(-47), SoTienThu = 4700000 },
            new PhieuThu { MaPhieuThu = 48, MaDaiLy = 48, NgayThuTien = seedDate.AddDays(-48), SoTienThu = 4800000 },
            new PhieuThu { MaPhieuThu = 49, MaDaiLy = 49, NgayThuTien = seedDate.AddDays(-49), SoTienThu = 4900000 },
            new PhieuThu { MaPhieuThu = 50, MaDaiLy = 50, NgayThuTien = seedDate.AddDays(-50), SoTienThu = 5000000 },

            new PhieuThu { MaPhieuThu = 51, MaDaiLy = 1, NgayThuTien = seedDate.AddDays(-51), SoTienThu = 5100000 },
            new PhieuThu { MaPhieuThu = 52, MaDaiLy = 2, NgayThuTien = seedDate.AddDays(-52), SoTienThu = 5200000 },
            new PhieuThu { MaPhieuThu = 53, MaDaiLy = 3, NgayThuTien = seedDate.AddDays(-53), SoTienThu = 5300000 },
            new PhieuThu { MaPhieuThu = 54, MaDaiLy = 4, NgayThuTien = seedDate.AddDays(-54), SoTienThu = 5400000 },
            new PhieuThu { MaPhieuThu = 55, MaDaiLy = 5, NgayThuTien = seedDate.AddDays(-55), SoTienThu = 5500000 },
            new PhieuThu { MaPhieuThu = 56, MaDaiLy = 6, NgayThuTien = seedDate.AddDays(-56), SoTienThu = 5600000 },
            new PhieuThu { MaPhieuThu = 57, MaDaiLy = 7, NgayThuTien = seedDate.AddDays(-57), SoTienThu = 5700000 },
            new PhieuThu { MaPhieuThu = 58, MaDaiLy = 8, NgayThuTien = seedDate.AddDays(-58), SoTienThu = 5800000 },
            new PhieuThu { MaPhieuThu = 59, MaDaiLy = 9, NgayThuTien = seedDate.AddDays(-59), SoTienThu = 5900000 },
            new PhieuThu { MaPhieuThu = 60, MaDaiLy = 10, NgayThuTien = seedDate.AddDays(-60), SoTienThu = 6000000 },

            new PhieuThu { MaPhieuThu = 61, MaDaiLy = 11, NgayThuTien = seedDate.AddDays(-61), SoTienThu = 6100000 },
            new PhieuThu { MaPhieuThu = 62, MaDaiLy = 12, NgayThuTien = seedDate.AddDays(-62), SoTienThu = 6200000 },
            new PhieuThu { MaPhieuThu = 63, MaDaiLy = 13, NgayThuTien = seedDate.AddDays(-63), SoTienThu = 6300000 },
            new PhieuThu { MaPhieuThu = 64, MaDaiLy = 14, NgayThuTien = seedDate.AddDays(-64), SoTienThu = 6400000 },
            new PhieuThu { MaPhieuThu = 65, MaDaiLy = 15, NgayThuTien = seedDate.AddDays(-65), SoTienThu = 6500000 },
            new PhieuThu { MaPhieuThu = 66, MaDaiLy = 16, NgayThuTien = seedDate.AddDays(-66), SoTienThu = 6600000 },
            new PhieuThu { MaPhieuThu = 67, MaDaiLy = 17, NgayThuTien = seedDate.AddDays(-67), SoTienThu = 6700000 },
            new PhieuThu { MaPhieuThu = 68, MaDaiLy = 18, NgayThuTien = seedDate.AddDays(-68), SoTienThu = 6800000 },
            new PhieuThu { MaPhieuThu = 69, MaDaiLy = 19, NgayThuTien = seedDate.AddDays(-69), SoTienThu = 6900000 },
            new PhieuThu { MaPhieuThu = 70, MaDaiLy = 20, NgayThuTien = seedDate.AddDays(-70), SoTienThu = 7000000 },

            new PhieuThu { MaPhieuThu = 71, MaDaiLy = 21, NgayThuTien = seedDate.AddDays(-71), SoTienThu = 7100000 },
            new PhieuThu { MaPhieuThu = 72, MaDaiLy = 22, NgayThuTien = seedDate.AddDays(-72), SoTienThu = 7200000 },
            new PhieuThu { MaPhieuThu = 73, MaDaiLy = 23, NgayThuTien = seedDate.AddDays(-73), SoTienThu = 7300000 },
            new PhieuThu { MaPhieuThu = 74, MaDaiLy = 24, NgayThuTien = seedDate.AddDays(-74), SoTienThu = 7400000 },
            new PhieuThu { MaPhieuThu = 75, MaDaiLy = 25, NgayThuTien = seedDate.AddDays(-75), SoTienThu = 7500000 },
            new PhieuThu { MaPhieuThu = 76, MaDaiLy = 26, NgayThuTien = seedDate.AddDays(-76), SoTienThu = 7600000 },
            new PhieuThu { MaPhieuThu = 77, MaDaiLy = 27, NgayThuTien = seedDate.AddDays(-77), SoTienThu = 7700000 },
            new PhieuThu { MaPhieuThu = 78, MaDaiLy = 28, NgayThuTien = seedDate.AddDays(-78), SoTienThu = 7800000 },
            new PhieuThu { MaPhieuThu = 79, MaDaiLy = 29, NgayThuTien = seedDate.AddDays(-79), SoTienThu = 7900000 },
            new PhieuThu { MaPhieuThu = 80, MaDaiLy = 30, NgayThuTien = seedDate.AddDays(-80), SoTienThu = 8000000 },

            new PhieuThu { MaPhieuThu = 81, MaDaiLy = 31, NgayThuTien = seedDate.AddDays(-81), SoTienThu = 8100000 },
            new PhieuThu { MaPhieuThu = 82, MaDaiLy = 32, NgayThuTien = seedDate.AddDays(-82), SoTienThu = 8200000 },
            new PhieuThu { MaPhieuThu = 83, MaDaiLy = 33, NgayThuTien = seedDate.AddDays(-83), SoTienThu = 8300000 },
            new PhieuThu { MaPhieuThu = 84, MaDaiLy = 34, NgayThuTien = seedDate.AddDays(-84), SoTienThu = 8400000 },
            new PhieuThu { MaPhieuThu = 85, MaDaiLy = 35, NgayThuTien = seedDate.AddDays(-85), SoTienThu = 8500000 },
            new PhieuThu { MaPhieuThu = 86, MaDaiLy = 36, NgayThuTien = seedDate.AddDays(-86), SoTienThu = 8600000 },
            new PhieuThu { MaPhieuThu = 87, MaDaiLy = 37, NgayThuTien = seedDate.AddDays(-87), SoTienThu = 8700000 },
            new PhieuThu { MaPhieuThu = 88, MaDaiLy = 38, NgayThuTien = seedDate.AddDays(-88), SoTienThu = 8800000 },
            new PhieuThu { MaPhieuThu = 89, MaDaiLy = 39, NgayThuTien = seedDate.AddDays(-89), SoTienThu = 8900000 },
            new PhieuThu { MaPhieuThu = 90, MaDaiLy = 40, NgayThuTien = seedDate.AddDays(-90), SoTienThu = 9000000 },

            new PhieuThu { MaPhieuThu = 91, MaDaiLy = 41, NgayThuTien = seedDate.AddDays(-91), SoTienThu = 9100000 },
            new PhieuThu { MaPhieuThu = 92, MaDaiLy = 42, NgayThuTien = seedDate.AddDays(-92), SoTienThu = 9200000 },
            new PhieuThu { MaPhieuThu = 93, MaDaiLy = 43, NgayThuTien = seedDate.AddDays(-93), SoTienThu = 9300000 },
            new PhieuThu { MaPhieuThu = 94, MaDaiLy = 44, NgayThuTien = seedDate.AddDays(-94), SoTienThu = 9400000 },
            new PhieuThu { MaPhieuThu = 95, MaDaiLy = 45, NgayThuTien = seedDate.AddDays(-95), SoTienThu = 9500000 },
            new PhieuThu { MaPhieuThu = 96, MaDaiLy = 46, NgayThuTien = seedDate.AddDays(-96), SoTienThu = 9600000 },
            new PhieuThu { MaPhieuThu = 97, MaDaiLy = 47, NgayThuTien = seedDate.AddDays(-97), SoTienThu = 9700000 },
            new PhieuThu { MaPhieuThu = 98, MaDaiLy = 48, NgayThuTien = seedDate.AddDays(-98), SoTienThu = 9800000 },
            new PhieuThu { MaPhieuThu = 99, MaDaiLy = 49, NgayThuTien = seedDate.AddDays(-99), SoTienThu = 9900000 },
            new PhieuThu { MaPhieuThu = 100, MaDaiLy = 50, NgayThuTien = seedDate.AddDays(-100), SoTienThu = 10000000 }
        };
        context.PhieuThus.AddRange(phieuthus);
        await context.SaveChangesAsync();

        var donViTinhs = new List<DonViTinh>
        {
            new DonViTinh { MaDonViTinh = 1, TenDonViTinh = "Chai" },
            new DonViTinh { MaDonViTinh = 2, TenDonViTinh = "Hộp" },
            new DonViTinh { MaDonViTinh = 3, TenDonViTinh = "Kg" },
            new DonViTinh { MaDonViTinh = 4, TenDonViTinh = "Thùng" }
        };
        context.DonViTinhs.AddRange(donViTinhs);
        await context.SaveChangesAsync();

        var matHangs = new List<MatHang>
        {
            new MatHang { MaMatHang = 1, TenMatHang = "Nước ngọt CocaCola", MaDonViTinh = 1, SoLuongTon = 500 },
            new MatHang { MaMatHang = 2, TenMatHang = "Bánh Oreo", MaDonViTinh = 2, SoLuongTon = 300 },
            new MatHang { MaMatHang = 3, TenMatHang = "Sữa Vinamilk", MaDonViTinh = 2, SoLuongTon = 400 },
            new MatHang { MaMatHang = 4, TenMatHang = "Dầu ăn Tường An", MaDonViTinh = 1, SoLuongTon = 200 },
            new MatHang { MaMatHang = 5, TenMatHang = "Gạo ST25", MaDonViTinh = 3, SoLuongTon = 1000 },
            new MatHang { MaMatHang = 6, TenMatHang = "Đường trắng Biên Hòa", MaDonViTinh = 3, SoLuongTon = 600 },
            new MatHang { MaMatHang = 7, TenMatHang = "Muối hạt", MaDonViTinh = 3, SoLuongTon = 450 },
            new MatHang { MaMatHang = 8, TenMatHang = "Nước mắm Nam Ngư", MaDonViTinh = 1, SoLuongTon = 350 },
            new MatHang { MaMatHang = 9, TenMatHang = "Bia Heineken", MaDonViTinh = 4, SoLuongTon = 250 },
            new MatHang { MaMatHang = 10, TenMatHang = "Mì gói Hảo Hảo", MaDonViTinh = 4, SoLuongTon = 800 }
        };
        context.MatHangs.AddRange(matHangs);
        await context.SaveChangesAsync();

        var ChiTietPhieuXuats = new List<ChiTietPhieuXuat>
        {
            // Phiếu Xuất 1
            new ChiTietPhieuXuat { MaPhieuXuat = 1, MaMatHang = 1, SoLuongXuat = 5, DonGiaXuat = 20000, ThanhTien = 100000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 1, MaMatHang = 3, SoLuongXuat = 2, DonGiaXuat = 50000, ThanhTien = 100000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 1, MaMatHang = 5, SoLuongXuat = 1, DonGiaXuat = 150000, ThanhTien = 150000 },

            // Phiếu Xuất 2
            new ChiTietPhieuXuat { MaPhieuXuat = 2, MaMatHang = 2, SoLuongXuat = 10, DonGiaXuat = 30000, ThanhTien = 300000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 2, MaMatHang = 4, SoLuongXuat = 3, DonGiaXuat = 120000, ThanhTien = 360000 },

            // Phiếu Xuất 3
            new ChiTietPhieuXuat { MaPhieuXuat = 3, MaMatHang = 1, SoLuongXuat = 7, DonGiaXuat = 20000, ThanhTien = 140000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 3, MaMatHang = 6, SoLuongXuat = 2, DonGiaXuat = 100000, ThanhTien = 200000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 3, MaMatHang = 7, SoLuongXuat = 4, DonGiaXuat = 80000, ThanhTien = 320000 },

            // Phiếu Xuất 4
            new ChiTietPhieuXuat { MaPhieuXuat = 4, MaMatHang = 2, SoLuongXuat = 6, DonGiaXuat = 30000, ThanhTien = 180000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 4, MaMatHang = 5, SoLuongXuat = 1, DonGiaXuat = 150000, ThanhTien = 150000 },

            // Phiếu Xuất 5
            new ChiTietPhieuXuat { MaPhieuXuat = 5, MaMatHang = 3, SoLuongXuat = 2, DonGiaXuat = 50000, ThanhTien = 100000 },

            // Phiếu Xuất 6
            new ChiTietPhieuXuat { MaPhieuXuat = 6, MaMatHang = 1, SoLuongXuat = 4, DonGiaXuat = 20000, ThanhTien = 80000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 6, MaMatHang = 7, SoLuongXuat = 3, DonGiaXuat = 80000, ThanhTien = 240000 },

            // Phiếu Xuất 7
            new ChiTietPhieuXuat { MaPhieuXuat = 7, MaMatHang = 6, SoLuongXuat = 5, DonGiaXuat = 100000, ThanhTien = 500000 },

            // Phiếu Xuất 8
            new ChiTietPhieuXuat { MaPhieuXuat = 8, MaMatHang = 2, SoLuongXuat = 8, DonGiaXuat = 30000, ThanhTien = 240000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 8, MaMatHang = 4, SoLuongXuat = 2, DonGiaXuat = 120000, ThanhTien = 240000 },

            // Phiếu Xuất 9
            new ChiTietPhieuXuat { MaPhieuXuat = 9, MaMatHang = 5, SoLuongXuat = 2, DonGiaXuat = 150000, ThanhTien = 300000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 9, MaMatHang = 7, SoLuongXuat = 1, DonGiaXuat = 80000, ThanhTien = 80000 },

            // Phiếu Xuất 10
            new ChiTietPhieuXuat { MaPhieuXuat = 10, MaMatHang = 1, SoLuongXuat = 3, DonGiaXuat = 20000, ThanhTien = 60000 },

            // Phiếu Xuất 11
            new ChiTietPhieuXuat { MaPhieuXuat = 11, MaMatHang = 6, SoLuongXuat = 2, DonGiaXuat = 100000, ThanhTien = 200000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 11, MaMatHang = 2, SoLuongXuat = 5, DonGiaXuat = 30000, ThanhTien = 150000 },

            // Phiếu Xuất 12
            new ChiTietPhieuXuat { MaPhieuXuat = 12, MaMatHang = 3, SoLuongXuat = 7, DonGiaXuat = 50000, ThanhTien = 350000 },

            // Phiếu Xuất 13
            new ChiTietPhieuXuat { MaPhieuXuat = 13, MaMatHang = 4, SoLuongXuat = 3, DonGiaXuat = 120000, ThanhTien = 360000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 13, MaMatHang = 5, SoLuongXuat = 1, DonGiaXuat = 150000, ThanhTien = 150000 },

            // Phiếu Xuất 14
            new ChiTietPhieuXuat { MaPhieuXuat = 14, MaMatHang = 7, SoLuongXuat = 2, DonGiaXuat = 80000, ThanhTien = 160000 },

            // Phiếu Xuất 15
            new ChiTietPhieuXuat { MaPhieuXuat = 15, MaMatHang = 1, SoLuongXuat = 10, DonGiaXuat = 20000, ThanhTien = 200000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 15, MaMatHang = 6, SoLuongXuat = 1, DonGiaXuat = 100000, ThanhTien = 100000 },

            // Phiếu Xuất 16
            new ChiTietPhieuXuat { MaPhieuXuat = 16, MaMatHang = 2, SoLuongXuat = 4, DonGiaXuat = 30000, ThanhTien = 120000 },

            // Phiếu Xuất 17
            new ChiTietPhieuXuat { MaPhieuXuat = 17, MaMatHang = 3, SoLuongXuat = 6, DonGiaXuat = 50000, ThanhTien = 300000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 17, MaMatHang = 5, SoLuongXuat = 2, DonGiaXuat = 150000, ThanhTien = 300000 },

            // Phiếu Xuất 18
            new ChiTietPhieuXuat { MaPhieuXuat = 18, MaMatHang = 4, SoLuongXuat = 2, DonGiaXuat = 120000, ThanhTien = 240000 },

            // Phiếu Xuất 19
            new ChiTietPhieuXuat { MaPhieuXuat = 19, MaMatHang = 7, SoLuongXuat = 3, DonGiaXuat = 80000, ThanhTien = 240000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 19, MaMatHang = 6, SoLuongXuat = 2, DonGiaXuat = 100000, ThanhTien = 200000 },

            // Phiếu Xuất 20
            new ChiTietPhieuXuat { MaPhieuXuat = 20, MaMatHang = 1, SoLuongXuat = 2, DonGiaXuat = 20000, ThanhTien = 40000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 20, MaMatHang = 2, SoLuongXuat = 3, DonGiaXuat = 30000, ThanhTien = 90000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 20, MaMatHang = 5, SoLuongXuat = 1, DonGiaXuat = 150000, ThanhTien = 150000 },

            // Phiếu Xuất 21
            new ChiTietPhieuXuat { MaPhieuXuat = 21, MaMatHang = 1, SoLuongXuat = 3, DonGiaXuat = 20000, ThanhTien = 60000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 21, MaMatHang = 2, SoLuongXuat = 5, DonGiaXuat = 30000, ThanhTien = 150000 },
            
            // Phiếu Xuất 22
            new ChiTietPhieuXuat { MaPhieuXuat = 22, MaMatHang = 3, SoLuongXuat = 2, DonGiaXuat = 50000, ThanhTien = 100000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 22, MaMatHang = 6, SoLuongXuat = 1, DonGiaXuat = 100000, ThanhTien = 100000 },
            
            // Phiếu Xuất 23
            new ChiTietPhieuXuat { MaPhieuXuat = 23, MaMatHang = 4, SoLuongXuat = 4, DonGiaXuat = 120000, ThanhTien = 480000 },
            
            // Phiếu Xuất 24
            new ChiTietPhieuXuat { MaPhieuXuat = 24, MaMatHang = 5, SoLuongXuat = 3, DonGiaXuat = 150000, ThanhTien = 450000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 24, MaMatHang = 7, SoLuongXuat = 2, DonGiaXuat = 80000, ThanhTien = 160000 },
            
            // Phiếu Xuất 25
            new ChiTietPhieuXuat { MaPhieuXuat = 25, MaMatHang = 8, SoLuongXuat = 1, DonGiaXuat = 250000, ThanhTien = 250000 },
            
            // Phiếu Xuất 26
            new ChiTietPhieuXuat { MaPhieuXuat = 26, MaMatHang = 2, SoLuongXuat = 6, DonGiaXuat = 30000, ThanhTien = 180000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 26, MaMatHang = 9, SoLuongXuat = 1, DonGiaXuat = 300000, ThanhTien = 300000 },
            
            // Phiếu Xuất 27
            new ChiTietPhieuXuat { MaPhieuXuat = 27, MaMatHang = 1, SoLuongXuat = 10, DonGiaXuat = 20000, ThanhTien = 200000 },
            
            // Phiếu Xuất 28
            new ChiTietPhieuXuat { MaPhieuXuat = 28, MaMatHang = 6, SoLuongXuat = 3, DonGiaXuat = 100000, ThanhTien = 300000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 28, MaMatHang = 3, SoLuongXuat = 5, DonGiaXuat = 50000, ThanhTien = 250000 },
            
            // Phiếu Xuất 29
            new ChiTietPhieuXuat { MaPhieuXuat = 29, MaMatHang = 7, SoLuongXuat = 4, DonGiaXuat = 80000, ThanhTien = 320000 },
            
            // Phiếu Xuất 30
            new ChiTietPhieuXuat { MaPhieuXuat = 30, MaMatHang = 4, SoLuongXuat = 2, DonGiaXuat = 120000, ThanhTien = 240000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 30, MaMatHang = 5, SoLuongXuat = 1, DonGiaXuat = 150000, ThanhTien = 150000 },
            
            // Phiếu Xuất 31
            new ChiTietPhieuXuat { MaPhieuXuat = 31, MaMatHang = 2, SoLuongXuat = 8, DonGiaXuat = 30000, ThanhTien = 240000 },
            
            // Phiếu Xuất 32
            new ChiTietPhieuXuat { MaPhieuXuat = 32, MaMatHang = 9, SoLuongXuat = 2, DonGiaXuat = 300000, ThanhTien = 600000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 32, MaMatHang = 1, SoLuongXuat = 5, DonGiaXuat = 20000, ThanhTien = 100000 },
            
            // Phiếu Xuất 33
            new ChiTietPhieuXuat { MaPhieuXuat = 33, MaMatHang = 3, SoLuongXuat = 7, DonGiaXuat = 50000, ThanhTien = 350000 },
            
            // Phiếu Xuất 34
            new ChiTietPhieuXuat { MaPhieuXuat = 34, MaMatHang = 6, SoLuongXuat = 2, DonGiaXuat = 100000, ThanhTien = 200000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 34, MaMatHang = 7, SoLuongXuat = 1, DonGiaXuat = 80000, ThanhTien = 80000 },
            
            // Phiếu Xuất 35
            new ChiTietPhieuXuat { MaPhieuXuat = 35, MaMatHang = 8, SoLuongXuat = 3, DonGiaXuat = 250000, ThanhTien = 750000 },
            
            // Phiếu Xuất 36
            new ChiTietPhieuXuat { MaPhieuXuat = 36, MaMatHang = 2, SoLuongXuat = 5, DonGiaXuat = 30000, ThanhTien = 150000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 36, MaMatHang = 5, SoLuongXuat = 2, DonGiaXuat = 150000, ThanhTien = 300000 },
            
            // Phiếu Xuất 37
            new ChiTietPhieuXuat { MaPhieuXuat = 37, MaMatHang = 1, SoLuongXuat = 9, DonGiaXuat = 20000, ThanhTien = 180000 },
            
            // Phiếu Xuất 38
            new ChiTietPhieuXuat { MaPhieuXuat = 38, MaMatHang = 4, SoLuongXuat = 3, DonGiaXuat = 120000, ThanhTien = 360000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 38, MaMatHang = 9, SoLuongXuat = 1, DonGiaXuat = 300000, ThanhTien = 300000 },
            
            // Phiếu Xuất 39
            new ChiTietPhieuXuat { MaPhieuXuat = 39, MaMatHang = 7, SoLuongXuat = 2, DonGiaXuat = 80000, ThanhTien = 160000 },
            
            // Phiếu Xuất 40
            new ChiTietPhieuXuat { MaPhieuXuat = 40, MaMatHang = 6, SoLuongXuat = 6, DonGiaXuat = 100000, ThanhTien = 600000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 40, MaMatHang = 3, SoLuongXuat = 1, DonGiaXuat = 50000, ThanhTien = 50000 },
            
            // Phiếu Xuất 41
            new ChiTietPhieuXuat { MaPhieuXuat = 41, MaMatHang = 5, SoLuongXuat = 4, DonGiaXuat = 150000, ThanhTien = 600000 },
            
            // Phiếu Xuất 42
            new ChiTietPhieuXuat { MaPhieuXuat = 42, MaMatHang = 1, SoLuongXuat = 2, DonGiaXuat = 20000, ThanhTien = 40000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 42, MaMatHang = 8, SoLuongXuat = 1, DonGiaXuat = 250000, ThanhTien = 250000 },
            
            // Phiếu Xuất 43
            new ChiTietPhieuXuat { MaPhieuXuat = 43, MaMatHang = 2, SoLuongXuat = 7, DonGiaXuat = 30000, ThanhTien = 210000 },
            
            // Phiếu Xuất 44
            new ChiTietPhieuXuat { MaPhieuXuat = 44, MaMatHang = 3, SoLuongXuat = 5, DonGiaXuat = 50000, ThanhTien = 250000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 44, MaMatHang = 9, SoLuongXuat = 2, DonGiaXuat = 300000, ThanhTien = 600000 },
            
            // Phiếu Xuất 45
            new ChiTietPhieuXuat { MaPhieuXuat = 45, MaMatHang = 6, SoLuongXuat = 2, DonGiaXuat = 100000, ThanhTien = 200000 },
            
            // Phiếu Xuất 46
            new ChiTietPhieuXuat { MaPhieuXuat = 46, MaMatHang = 7, SoLuongXuat = 5, DonGiaXuat = 80000, ThanhTien = 400000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 46, MaMatHang = 4, SoLuongXuat = 1, DonGiaXuat = 120000, ThanhTien = 120000 },
            
            // Phiếu Xuất 47
            new ChiTietPhieuXuat { MaPhieuXuat = 47, MaMatHang = 8, SoLuongXuat = 2, DonGiaXuat = 250000, ThanhTien = 500000 },
            
            // Phiếu Xuất 48
            new ChiTietPhieuXuat { MaPhieuXuat = 48, MaMatHang = 5, SoLuongXuat = 3, DonGiaXuat = 150000, ThanhTien = 450000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 48, MaMatHang = 1, SoLuongXuat = 6, DonGiaXuat = 20000, ThanhTien = 120000 },
            
            // Phiếu Xuất 49
            new ChiTietPhieuXuat { MaPhieuXuat = 49, MaMatHang = 2, SoLuongXuat = 4, DonGiaXuat = 30000, ThanhTien = 120000 },
            
            // Phiếu Xuất 50
            new ChiTietPhieuXuat { MaPhieuXuat = 50, MaMatHang = 9, SoLuongXuat = 1, DonGiaXuat = 300000, ThanhTien = 300000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 50, MaMatHang = 6, SoLuongXuat = 2, DonGiaXuat = 100000, ThanhTien = 200000 },

                // Phiếu Xuất 51
            new ChiTietPhieuXuat { MaPhieuXuat = 51, MaMatHang = 1, SoLuongXuat = 5, DonGiaXuat = 20000, ThanhTien = 100000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 51, MaMatHang = 4, SoLuongXuat = 2, DonGiaXuat = 120000, ThanhTien = 240000 },

            // Phiếu Xuất 52
            new ChiTietPhieuXuat { MaPhieuXuat = 52, MaMatHang = 3, SoLuongXuat = 3, DonGiaXuat = 50000, ThanhTien = 150000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 52, MaMatHang = 7, SoLuongXuat = 1, DonGiaXuat = 80000, ThanhTien = 80000 },

            // Phiếu Xuất 53
            new ChiTietPhieuXuat { MaPhieuXuat = 53, MaMatHang = 2, SoLuongXuat = 6, DonGiaXuat = 30000, ThanhTien = 180000 },

            // Phiếu Xuất 54
            new ChiTietPhieuXuat { MaPhieuXuat = 54, MaMatHang = 5, SoLuongXuat = 2, DonGiaXuat = 150000, ThanhTien = 300000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 54, MaMatHang = 9, SoLuongXuat = 1, DonGiaXuat = 300000, ThanhTien = 300000 },

            // Phiếu Xuất 55
            new ChiTietPhieuXuat { MaPhieuXuat = 55, MaMatHang = 6, SoLuongXuat = 4, DonGiaXuat = 100000, ThanhTien = 400000 },

            // Phiếu Xuất 56
            new ChiTietPhieuXuat { MaPhieuXuat = 56, MaMatHang = 7, SoLuongXuat = 3, DonGiaXuat = 80000, ThanhTien = 240000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 56, MaMatHang = 1, SoLuongXuat = 2, DonGiaXuat = 20000, ThanhTien = 40000 },

            // Phiếu Xuất 57
            new ChiTietPhieuXuat { MaPhieuXuat = 57, MaMatHang = 2, SoLuongXuat = 5, DonGiaXuat = 30000, ThanhTien = 150000 },

            // Phiếu Xuất 58
            new ChiTietPhieuXuat { MaPhieuXuat = 58, MaMatHang = 8, SoLuongXuat = 1, DonGiaXuat = 250000, ThanhTien = 250000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 58, MaMatHang = 4, SoLuongXuat = 2, DonGiaXuat = 120000, ThanhTien = 240000 },

            // Phiếu Xuất 59
            new ChiTietPhieuXuat { MaPhieuXuat = 59, MaMatHang = 3, SoLuongXuat = 6, DonGiaXuat = 50000, ThanhTien = 300000 },

            // Phiếu Xuất 60
            new ChiTietPhieuXuat { MaPhieuXuat = 60, MaMatHang = 9, SoLuongXuat = 2, DonGiaXuat = 300000, ThanhTien = 600000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 60, MaMatHang = 6, SoLuongXuat = 1, DonGiaXuat = 100000, ThanhTien = 100000 },

            // Phiếu Xuất 61
            new ChiTietPhieuXuat { MaPhieuXuat = 61, MaMatHang = 5, SoLuongXuat = 3, DonGiaXuat = 150000, ThanhTien = 450000 },

            // Phiếu Xuất 62
            new ChiTietPhieuXuat { MaPhieuXuat = 62, MaMatHang = 7, SoLuongXuat = 2, DonGiaXuat = 80000, ThanhTien = 160000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 62, MaMatHang = 1, SoLuongXuat = 4, DonGiaXuat = 20000, ThanhTien = 80000 },

            // Phiếu Xuất 63
            new ChiTietPhieuXuat { MaPhieuXuat = 63, MaMatHang = 2, SoLuongXuat = 9, DonGiaXuat = 30000, ThanhTien = 270000 },

            // Phiếu Xuất 64
            new ChiTietPhieuXuat { MaPhieuXuat = 64, MaMatHang = 8, SoLuongXuat = 2, DonGiaXuat = 250000, ThanhTien = 500000 },

            // Phiếu Xuất 65
            new ChiTietPhieuXuat { MaPhieuXuat = 65, MaMatHang = 3, SoLuongXuat = 1, DonGiaXuat = 50000, ThanhTien = 50000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 65, MaMatHang = 6, SoLuongXuat = 2, DonGiaXuat = 100000, ThanhTien = 200000 },

            // Phiếu Xuất 66
            new ChiTietPhieuXuat { MaPhieuXuat = 66, MaMatHang = 4, SoLuongXuat = 5, DonGiaXuat = 120000, ThanhTien = 600000 },

            // Phiếu Xuất 67
            new ChiTietPhieuXuat { MaPhieuXuat = 67, MaMatHang = 5, SoLuongXuat = 2, DonGiaXuat = 150000, ThanhTien = 300000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 67, MaMatHang = 7, SoLuongXuat = 3, DonGiaXuat = 80000, ThanhTien = 240000 },

            // Phiếu Xuất 68
            new ChiTietPhieuXuat { MaPhieuXuat = 68, MaMatHang = 9, SoLuongXuat = 1, DonGiaXuat = 300000, ThanhTien = 300000 },

            // Phiếu Xuất 69
            new ChiTietPhieuXuat { MaPhieuXuat = 69, MaMatHang = 1, SoLuongXuat = 7, DonGiaXuat = 20000, ThanhTien = 140000 },

            // Phiếu Xuất 70
            new ChiTietPhieuXuat { MaPhieuXuat = 70, MaMatHang = 6, SoLuongXuat = 4, DonGiaXuat = 100000, ThanhTien = 400000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 70, MaMatHang = 2, SoLuongXuat = 5, DonGiaXuat = 30000, ThanhTien = 150000 },

            // Phiếu Xuất 71
            new ChiTietPhieuXuat { MaPhieuXuat = 71, MaMatHang = 3, SoLuongXuat = 8, DonGiaXuat = 50000, ThanhTien = 400000 },

            // Phiếu Xuất 72
            new ChiTietPhieuXuat { MaPhieuXuat = 72, MaMatHang = 7, SoLuongXuat = 2, DonGiaXuat = 80000, ThanhTien = 160000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 72, MaMatHang = 5, SoLuongXuat = 1, DonGiaXuat = 150000, ThanhTien = 150000 },

            // Phiếu Xuất 73
            new ChiTietPhieuXuat { MaPhieuXuat = 73, MaMatHang = 8, SoLuongXuat = 1, DonGiaXuat = 250000, ThanhTien = 250000 },

            // Phiếu Xuất 74
            new ChiTietPhieuXuat { MaPhieuXuat = 74, MaMatHang = 2, SoLuongXuat = 4, DonGiaXuat = 30000, ThanhTien = 120000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 74, MaMatHang = 9, SoLuongXuat = 2, DonGiaXuat = 300000, ThanhTien = 600000 },

            // Phiếu Xuất 75
            new ChiTietPhieuXuat { MaPhieuXuat = 75, MaMatHang = 6, SoLuongXuat = 3, DonGiaXuat = 100000, ThanhTien = 300000 },

                // Phiếu Xuất 76
            new ChiTietPhieuXuat { MaPhieuXuat = 76, MaMatHang = 1, SoLuongXuat = 4, DonGiaXuat = 20000, ThanhTien = 80000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 76, MaMatHang = 7, SoLuongXuat = 3, DonGiaXuat = 80000, ThanhTien = 240000 },

            // Phiếu Xuất 77
            new ChiTietPhieuXuat { MaPhieuXuat = 77, MaMatHang = 2, SoLuongXuat = 6, DonGiaXuat = 30000, ThanhTien = 180000 },

            // Phiếu Xuất 78
            new ChiTietPhieuXuat { MaPhieuXuat = 78, MaMatHang = 5, SoLuongXuat = 2, DonGiaXuat = 150000, ThanhTien = 300000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 78, MaMatHang = 9, SoLuongXuat = 1, DonGiaXuat = 300000, ThanhTien = 300000 },

            // Phiếu Xuất 79
            new ChiTietPhieuXuat { MaPhieuXuat = 79, MaMatHang = 3, SoLuongXuat = 5, DonGiaXuat = 50000, ThanhTien = 250000 },

            // Phiếu Xuất 80
            new ChiTietPhieuXuat { MaPhieuXuat = 80, MaMatHang = 6, SoLuongXuat = 2, DonGiaXuat = 100000, ThanhTien = 200000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 80, MaMatHang = 4, SoLuongXuat = 1, DonGiaXuat = 120000, ThanhTien = 120000 },

            // Phiếu Xuất 81
            new ChiTietPhieuXuat { MaPhieuXuat = 81, MaMatHang = 8, SoLuongXuat = 1, DonGiaXuat = 250000, ThanhTien = 250000 },

            // Phiếu Xuất 82
            new ChiTietPhieuXuat { MaPhieuXuat = 82, MaMatHang = 7, SoLuongXuat = 4, DonGiaXuat = 80000, ThanhTien = 320000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 82, MaMatHang = 1, SoLuongXuat = 3, DonGiaXuat = 20000, ThanhTien = 60000 },

            // Phiếu Xuất 83
            new ChiTietPhieuXuat { MaPhieuXuat = 83, MaMatHang = 2, SoLuongXuat = 7, DonGiaXuat = 30000, ThanhTien = 210000 },

            // Phiếu Xuất 84
            new ChiTietPhieuXuat { MaPhieuXuat = 84, MaMatHang = 9, SoLuongXuat = 2, DonGiaXuat = 300000, ThanhTien = 600000 },

            // Phiếu Xuất 85
            new ChiTietPhieuXuat { MaPhieuXuat = 85, MaMatHang = 6, SoLuongXuat = 5, DonGiaXuat = 100000, ThanhTien = 500000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 85, MaMatHang = 3, SoLuongXuat = 2, DonGiaXuat = 50000, ThanhTien = 100000 },

            // Phiếu Xuất 86
            new ChiTietPhieuXuat { MaPhieuXuat = 86, MaMatHang = 5, SoLuongXuat = 1, DonGiaXuat = 150000, ThanhTien = 150000 },

            // Phiếu Xuất 87
            new ChiTietPhieuXuat { MaPhieuXuat = 87, MaMatHang = 4, SoLuongXuat = 3, DonGiaXuat = 120000, ThanhTien = 360000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 87, MaMatHang = 7, SoLuongXuat = 2, DonGiaXuat = 80000, ThanhTien = 160000 },

            // Phiếu Xuất 88
            new ChiTietPhieuXuat { MaPhieuXuat = 88, MaMatHang = 8, SoLuongXuat = 2, DonGiaXuat = 250000, ThanhTien = 500000 },

            // Phiếu Xuất 89
            new ChiTietPhieuXuat { MaPhieuXuat = 89, MaMatHang = 1, SoLuongXuat = 8, DonGiaXuat = 20000, ThanhTien = 160000 },

            // Phiếu Xuất 90
            new ChiTietPhieuXuat { MaPhieuXuat = 90, MaMatHang = 2, SoLuongXuat = 5, DonGiaXuat = 30000, ThanhTien = 150000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 90, MaMatHang = 6, SoLuongXuat = 3, DonGiaXuat = 100000, ThanhTien = 300000 },

            // Phiếu Xuất 91
            new ChiTietPhieuXuat { MaPhieuXuat = 91, MaMatHang = 9, SoLuongXuat = 1, DonGiaXuat = 300000, ThanhTien = 300000 },

            // Phiếu Xuất 92
            new ChiTietPhieuXuat { MaPhieuXuat = 92, MaMatHang = 7, SoLuongXuat = 2, DonGiaXuat = 80000, ThanhTien = 160000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 92, MaMatHang = 5, SoLuongXuat = 2, DonGiaXuat = 150000, ThanhTien = 300000 },

            // Phiếu Xuất 93
            new ChiTietPhieuXuat { MaPhieuXuat = 93, MaMatHang = 3, SoLuongXuat = 6, DonGiaXuat = 50000, ThanhTien = 300000 },

            // Phiếu Xuất 94
            new ChiTietPhieuXuat { MaPhieuXuat = 94, MaMatHang = 4, SoLuongXuat = 4, DonGiaXuat = 120000, ThanhTien = 480000 },

            // Phiếu Xuất 95
            new ChiTietPhieuXuat { MaPhieuXuat = 95, MaMatHang = 6, SoLuongXuat = 2, DonGiaXuat = 100000, ThanhTien = 200000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 95, MaMatHang = 8, SoLuongXuat = 1, DonGiaXuat = 250000, ThanhTien = 250000 },

            // Phiếu Xuất 96
            new ChiTietPhieuXuat { MaPhieuXuat = 96, MaMatHang = 1, SoLuongXuat = 5, DonGiaXuat = 20000, ThanhTien = 100000 },

            // Phiếu Xuất 97
            new ChiTietPhieuXuat { MaPhieuXuat = 97, MaMatHang = 9, SoLuongXuat = 2, DonGiaXuat = 300000, ThanhTien = 600000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 97, MaMatHang = 2, SoLuongXuat = 3, DonGiaXuat = 30000, ThanhTien = 90000 },

            // Phiếu Xuất 98
            new ChiTietPhieuXuat { MaPhieuXuat = 98, MaMatHang = 7, SoLuongXuat = 3, DonGiaXuat = 80000, ThanhTien = 240000 },

            // Phiếu Xuất 99
            new ChiTietPhieuXuat { MaPhieuXuat = 99, MaMatHang = 3, SoLuongXuat = 4, DonGiaXuat = 50000, ThanhTien = 200000 },
            new ChiTietPhieuXuat { MaPhieuXuat = 99, MaMatHang = 5, SoLuongXuat = 1, DonGiaXuat = 150000, ThanhTien = 150000 },

            // Phiếu Xuất 100
            new ChiTietPhieuXuat { MaPhieuXuat = 100, MaMatHang = 8, SoLuongXuat = 2, DonGiaXuat = 250000, ThanhTien = 500000 }
        };
        context.ChiTietPhieuXuats.AddRange(ChiTietPhieuXuats);
        await context.SaveChangesAsync();
    }
}