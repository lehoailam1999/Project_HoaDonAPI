using Microsoft.EntityFrameworkCore;
using Project_HoaDonAPI.Entities;

namespace Project_HoaDonAPI.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-5K7OTPS\\SQLEXPRESS;Initial Catalog=Project_HoaDonApi;Integrated Security=True;Encrypt=true;Trustservercertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<HoaDon>()
                .Property(h => h.HinhAnh)
                .HasColumnName("HinhAnh");
        }
    }
}
