using Coupon.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Coupon.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Coupon>().HasData(
            new Models.Coupon
            { 
                CouponId = 1,
                CouponCode="WWWE",
                DiscountAmount=50,
                MinAmount=100,
            });

            modelBuilder.Entity<Models.Coupon>().HasData(
              new Models.Coupon
              {
                  CouponId = 2,
                  CouponCode = "SSSB",
                  DiscountAmount = 10,
                  MinAmount = 0,
              });
        }
    }
}
