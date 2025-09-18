using Quan_ly_dai_ly.Data;
using Quan_ly_dai_ly.Configs;
using Quan_ly_dai_ly.Services;
using Quan_ly_dai_ly.ServiceImpls;
using Microsoft.EntityFrameworkCore;
using Quan_ly_dai_ly.RepositoryInterfaces;
using Quan_ly_dai_ly.Repositories;
using Quan_ly_dai_ly.Views.DaiLyViews;
using Quan_ly_dai_ly.ViewModels.DaiLyViewModels;
using Quan_ly_dai_ly.Views.PhieuXuatViews;
using Quan_ly_dai_ly.ViewModels.PhieuXuatViewModels;
using Quan_ly_dai_ly.Views.PhieuThuViews;
using Quan_ly_dai_ly.ViewModels.PhieuThuViewModels;
namespace Quan_ly_dai_ly.DI;

public static class AppModule
{
    public static IServiceCollection RegisterDependency(this IServiceCollection services)
    {
        //Đăng ký DataBaseConfig dưới dạng Singleton. 
        services.AddSingleton<DataBaseConfig>();

        //Đăng ký DataContext (DbContext) với SQLite
        services.AddDbContext<DataContext>((ServiceProvider, options) =>
        {
            var databasePath = DataBaseConfig.GetResourcePath();
            options.UseSqlite($"Data Source={databasePath}");
        });

        services.AddScoped<DatabaseService, DatabaseServiceImpl>();

        services.AddScoped<IDaiLyService, DaiLyServiceImpl>();
        services.AddScoped<ILoaiDaiLyService, LoaiDaiLyServiceImpl>();
        services.AddScoped<IQuanService, QuanServiceImpl>();
        services.AddScoped<IThamSoService, ThamSoServiceImpl>();

        services.AddScoped<IChiTietPhieuXuatService, ChiTietPhieuXuatServiceImpl>();
        services.AddScoped<IPhieuXuatService, PhieuXuatServiceImpl>();
        services.AddScoped<IMatHangService, MatHangServiceImpl>();
        services.AddScoped<IDonViTinhService, DonViTinhServiceImpl>();
        services.AddScoped<IPhieuThuService, PhieuThuServiceImpl>();

        //Đăng kí repository
        services.AddScoped<IDaiLyRepository, DaiLyRepository>();
        services.AddScoped<ILoaiDaiLyRepository, LoaiDaiLyRepository>();
        services.AddScoped<IQuanRepository, QuanRepository>();
        services.AddScoped<IThamSoRepository, ThamSoRepository>();

        services.AddScoped<IChiTietPhieuXuatRepository, ChiTietPhieuXuatRepository>();
        services.AddScoped<IPhieuXuatRepository, PhieuXuatRepository>();
        services.AddScoped<IMatHangRepository, MatHangRepository>();
        services.AddScoped<IDonViTinhRepository, DonViTinhRepository>();
        services.AddScoped<IPhieuThuRepository, PhieuThuRepository>();

        //Đăng kí View
        services.AddTransient<DanhSachDaiLyPageView>();
        services.AddTransient<ThemDaiLyWindowView>();
        services.AddTransient<DanhSachDaiLyPageView>();
        services.AddTransient<LapPhieuXuatHangWindowView>();
        services.AddTransient<TraCuuDaiLyWindowView>();
        services.AddTransient<DanhSachPhieuThuPageView>();
        services.AddTransient<LapPhieuThuTienWindowView>();

        //Đăng kí ViewModel
        services.AddTransient<DanhSachDaiLyPageViewModel>();
        services.AddTransient<ThemDaiLyWindowViewModel>();
        services.AddTransient<DanhSachPhieuXuatHangPageViewModel>();
        services.AddTransient<LapPhieuXuatHangWindowViewModel>();
        services.AddTransient<TraCuuDaiLyWindowViewModel>();
        services.AddTransient<DanhSachPhieuThuPageViewModels>();
        services.AddTransient<LapPhieuThuTienWindowViewModel>();

        return services;
    }
}
    

