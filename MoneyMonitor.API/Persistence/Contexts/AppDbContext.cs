using Microsoft.EntityFrameworkCore;
using MoneyMonitor.API.Domain.Models;

namespace MoneyMonitor.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Deal> Deals { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AssetType>().ToTable("AssetTypes");
            builder.Entity<AssetType>().HasKey(p => p.Id);
            builder.Entity<AssetType>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<AssetType>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<AssetType>().HasMany(p => p.Assets).WithOne(p => p.AssetType).HasForeignKey(p => p.TypeId);

            builder.Entity<AssetType>().HasData
                (
                    new AssetType { Id = 1, Name = "crypto currency" },
                    new AssetType { Id = 2, Name = "share" },
                    new AssetType { Id = 3, Name = "foreign currency" }
                );

            builder.Entity<Asset>().ToTable("Assets");
            builder.Entity<Asset>().HasKey(p => p.Id);
            builder.Entity<Asset>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Asset>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Asset>().Property(p => p.ShortName).IsRequired().HasMaxLength(3);
            builder.Entity<Asset>().HasMany(p => p.Deals).WithOne(p => p.Asset).HasForeignKey(p => p.AssetId);

            builder.Entity<Asset>().HasData
                (
                    new Asset { Id = 4, Name = "United States of America Dollar", ShortName = "USD", TypeId = 3 },
                    new Asset { Id = 5, Name = "Bitcoin crypto currency", ShortName = "BTC", TypeId = 1 }
                );

            builder.Entity<Deal>().ToTable("Deals");
            builder.Entity<Deal>().HasKey(p => p.Id);
            builder.Entity<Deal>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Deal>().Property(p => p.OperationType).IsRequired();
            builder.Entity<Deal>().Property(p => p.Amount).IsRequired();
            builder.Entity<Deal>().Property(p => p.Value).IsRequired();
            builder.Entity<Deal>().Property(p => p.BaseCurrency).IsRequired().HasMaxLength(3);
            builder.Entity<Deal>().Property(p => p.AdditionalCosts).IsRequired();
            builder.Entity<Deal>().Property(p => p.AdditionalInfo).IsRequired();
        }
    }
}
