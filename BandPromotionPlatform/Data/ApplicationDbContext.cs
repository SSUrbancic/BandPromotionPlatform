using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BandPromotionPlatform.Models;
namespace BandPromotionPlatform.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Add Identity related model configuration
        //    base.OnModelCreating(modelBuilder);
        //    // Your fluent modeling here
        //}
        public DbSet<BandPromotionPlatform.Models.AdminUser> AdminUser { get; set; }
        public DbSet<BandPromotionPlatform.Models.Cart> Cart { get; set; }
        public DbSet<BandPromotionPlatform.Models.CartItem> CartItem { get; set; }
        public DbSet<BandPromotionPlatform.Models.Customer> Customer { get; set; }
        public DbSet<BandPromotionPlatform.Models.Order> Order { get; set; }
        public DbSet<BandPromotionPlatform.Models.OrderDetails> OrderDetails { get; set; }
        public DbSet<BandPromotionPlatform.Models.Product> Product { get; set; }
        public DbSet<BandPromotionPlatform.Models.Event> Event { get; set; }
        public DbSet<BandPromotionPlatform.Models.YouTubeVideo> YouTubeVideo { get; set; }
        public DbSet<BandPromotionPlatform.Models.SoundCloud> SoundCloud { get; set; }
    }
}