using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Models
{
    public partial class qldtContext : DbContext
    {
        public qldtContext()
        {
        }

        public qldtContext(DbContextOptions<qldtContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminManager> AdminManagers { get; set; }
        public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }
        public virtual DbSet<Danhmuc> Danhmucs { get; set; }
        public virtual DbSet<Donhang> Donhangs { get; set; }
        public virtual DbSet<Hedieuhanh> Hedieuhanhs { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Phanquyen> Phanquyens { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Tintuc> Tintucs { get; set; }
        public virtual DbSet<Trangthai> Trangthais { get; set; }
        public virtual DbSet<Trangthaidonhang> Trangthaidonhangs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-8QR6R0J4\\SQLEXPRESS;Initial Catalog=qldt;User ID=sa;Password=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminManager>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.ToTable("AdminManager");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.MatkhauAdmin)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.PhanquyenId).HasColumnName("PhanquyenID");

                entity.Property(e => e.TenAdmin)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Phanquyen)
                    .WithMany(p => p.AdminManagers)
                    .HasForeignKey(d => d.PhanquyenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminManager_Phanquyen");
            });

            modelBuilder.Entity<Chitietdonhang>(entity =>
            {
                entity.ToTable("Chitietdonhang");

                entity.Property(e => e.ChitietdonhangId).HasColumnName("ChitietdonhangID");

                entity.Property(e => e.DonhangId).HasColumnName("DonhangID");

                entity.Property(e => e.Ngaylaphoadon).HasColumnType("datetime");

                entity.Property(e => e.SanphamId).HasColumnName("SanphamID");

                entity.HasOne(d => d.Donhang)
                    .WithMany(p => p.Chitietdonhangs)
                    .HasForeignKey(d => d.DonhangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chitietdonhang_Donhang");

                entity.HasOne(d => d.Sanpham)
                    .WithMany(p => p.Chitietdonhangs)
                    .HasForeignKey(d => d.SanphamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chitietdonhang_sanpham");
            });

            modelBuilder.Entity<Danhmuc>(entity =>
            {
                entity.ToTable("Danhmuc");

                entity.Property(e => e.DanhmucId).HasColumnName("DanhmucID");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(150)
                    .IsFixedLength(true);

                entity.Property(e => e.Tendanhmuc).HasMaxLength(50);
            });

            modelBuilder.Entity<Donhang>(entity =>
            {
                entity.ToTable("Donhang");

                entity.Property(e => e.DonhangId).HasColumnName("DonhangID");

                entity.Property(e => e.Diachigiaohang).HasMaxLength(100);

                entity.Property(e => e.KhachhangId).HasColumnName("KhachhangID");

                entity.Property(e => e.Masodonhang).HasMaxLength(50);

                entity.Property(e => e.Ngaytaodon).HasColumnType("datetime");

                entity.Property(e => e.TaikhoanId).HasColumnName("TaikhoanID");

                entity.Property(e => e.TrangthaidonhangId).HasColumnName("TrangthaidonhangID");

                entity.HasOne(d => d.Khachhang)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.KhachhangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donhang_Khachhang");

                entity.HasOne(d => d.Taikhoan)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.TaikhoanId)
                    .HasConstraintName("FK_Donhang_Nhanvien");

                entity.HasOne(d => d.Trangthaidonhang)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.TrangthaidonhangId)
                    .HasConstraintName("FK_Donhang_Trangthaidonhang");
            });

            modelBuilder.Entity<Hedieuhanh>(entity =>
            {
                entity.ToTable("Hedieuhanh");

                entity.Property(e => e.HedieuhanhId).HasColumnName("HedieuhanhID");

                entity.Property(e => e.Tenhedieuhanh)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.ToTable("Khachhang");

                entity.Property(e => e.KhachhangId).HasColumnName("KhachhangID");

                entity.Property(e => e.Diachi).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Hovaten).HasMaxLength(50);

                entity.Property(e => e.Landangnhapgannhat).HasColumnType("datetime");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(32)
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaysinh).HasColumnType("date");

                entity.Property(e => e.Sodienthoai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TrangthaiId).HasColumnName("TrangthaiID");

                entity.HasOne(d => d.Trangthai)
                    .WithMany(p => p.Khachhangs)
                    .HasForeignKey(d => d.TrangthaiId)
                    .HasConstraintName("FK_Khachhang_Trangthai");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.TaikhoanId);

                entity.ToTable("Nhanvien");

                entity.Property(e => e.TaikhoanId).HasColumnName("TaikhoanID");

                entity.Property(e => e.Cmnd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CMND")
                    .IsFixedLength(true);

                entity.Property(e => e.Diachi).HasMaxLength(100);

                entity.Property(e => e.Gioitinh).HasMaxLength(50);

                entity.Property(e => e.Hovaten).HasMaxLength(50);

                entity.Property(e => e.Matkhau).HasMaxLength(32);

                entity.Property(e => e.Ngaysinh).HasColumnType("date");

                entity.Property(e => e.Ngaytao).HasColumnType("datetime");

                entity.Property(e => e.PhanquyenId).HasColumnName("PhanquyenID");

                entity.Property(e => e.TrangthaiId).HasColumnName("TrangthaiID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Phanquyen)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.PhanquyenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nhanvien_Phanquyen");

                entity.HasOne(d => d.Trangthai)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.TrangthaiId)
                    .HasConstraintName("FK_Nhanvien_Trangthai");
            });

            modelBuilder.Entity<Phanquyen>(entity =>
            {
                entity.ToTable("Phanquyen");

                entity.Property(e => e.PhanquyenId).HasColumnName("PhanquyenID");

                entity.Property(e => e.Tenquyentruycap).HasMaxLength(50);
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.ToTable("sanpham");

                entity.Property(e => e.SanphamId).HasColumnName("SanphamID");

                entity.Property(e => e.DanhmucId).HasColumnName("DanhmucID");

                entity.Property(e => e.Dungluong)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HedieuhanhId).HasColumnName("HedieuhanhID");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Tensanpham)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Danhmuc)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.DanhmucId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sanpham_Danhmuc");

                entity.HasOne(d => d.Hedieuhanh)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.HedieuhanhId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sanpham_Hedieuhanh1");
            });

            modelBuilder.Entity<Tintuc>(entity =>
            {
                entity.ToTable("Tintuc");

                entity.Property(e => e.TintucId).HasColumnName("TintucID");

                entity.Property(e => e.Hinhanhtintuc)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaytaotintuc).HasColumnType("datetime");

                entity.Property(e => e.TaikhoanId).HasColumnName("TaikhoanID");

                entity.Property(e => e.Tentintuc).HasMaxLength(200);

                entity.Property(e => e.Tieude).HasMaxLength(200);

                entity.HasOne(d => d.Taikhoan)
                    .WithMany(p => p.Tintucs)
                    .HasForeignKey(d => d.TaikhoanId)
                    .HasConstraintName("FK_Tintuc_Nhanvien");
            });

            modelBuilder.Entity<Trangthai>(entity =>
            {
                entity.ToTable("Trangthai");

                entity.Property(e => e.TrangthaiId).HasColumnName("TrangthaiID");

                entity.Property(e => e.Tentrangthai)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Trangthaidonhang>(entity =>
            {
                entity.ToTable("Trangthaidonhang");

                entity.Property(e => e.TrangthaidonhangId)
                    .ValueGeneratedNever()
                    .HasColumnName("TrangthaidonhangID");

                entity.Property(e => e.Tentrangthaidonhang)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
