using Quan_ly_dai_ly.Models;
using Microsoft.EntityFrameworkCore;

namespace Quan_ly_dai_ly.Data;

// file DataContext có tác dụng mô hình hóa database, là cầu nối giữa C# code và bảng
public class DataContext : DbContext
{
    // Constructor nhận DbContextOptions từ Dependency Injection
    public DataContext(DbContextOptions<DataContext> options)
    : base(options)
    {
    }
    //Khai báo bảng
    public DbSet<DaiLy> DaiLies { get; set; } = null!;
    public DbSet<LoaiDaiLy> LoaiDaiLies { get; set; } = null!;
    public DbSet<Quan> Quans { get; set; } = null!;
    public DbSet<ThamSo> ThamSos { get; set; } = null!;
    public DbSet<MatHang> MatHangs { get; set; } = null!;
    public DbSet<PhieuXuat> PhieuXuats { get; set; } = null!;
    public DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; } = null!;
    public DbSet<DonViTinh> DonViTinhs { get; set; } = null!;

    //Khởi tạo mô hình
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); //sử dụng cấu hình mặc định ef core

        modelBuilder.Entity<LoaiDaiLy>()
            .HasMany(ldl => ldl.DaiLies)
            .WithOne(dl => dl.LoaiDaiLy)
            .HasForeignKey(dl => dl.MaLoaiDaiLy)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Quan>()
            .HasMany(q => q.DaiLies)
            .WithOne(dl => dl.Quan)
            .HasForeignKey(dl => dl.MaQuan)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DaiLy>()
            .HasMany(dl => dl.PhieuXuats)
            .WithOne(px => px.DaiLy)
            .HasForeignKey(px => px.MaDaiLy)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PhieuXuat>()
            .HasMany(px => px.ChiTietPhieuXuats)
            .WithOne(ctpx => ctpx.PhieuXuat)
            .HasForeignKey(ctpx => ctpx.MaPhieuXuat)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MatHang>()
            .HasMany(mh => mh.ChiTietPhieuXuats)
            .WithOne(ctpx => ctpx.MatHang)
            .HasForeignKey(ctpx => ctpx.MaMatHang)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DonViTinh>()
            .HasMany(dvt => dvt.MatHangs)
            .WithOne(mh => mh.DonViTinh)
            .HasForeignKey(mh => mh.MaDonViTinh)
            .OnDelete(DeleteBehavior.Cascade);
    }

}