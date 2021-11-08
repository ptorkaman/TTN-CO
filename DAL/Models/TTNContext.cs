using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public class TTNContext : DbContext
    {
        public TTNContext()
        {
        }

 
        public TTNContext(DbContextOptions<TTNContext> contextOptions)
            : base(contextOptions)
        {
        }

    
        public DbSet<VehicleManager> VehicleManagers { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<StuffManager> StuffManagers { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<UserMenu> UserMenus { get; set; }
        public DbSet<MenuPermission> MenuPermissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Bin> Bins { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptBin> ReceiptBins { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetails { get; set; }
        public DbSet<ReceiptStatus> ReceiptStatuses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Parish> Parishes { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<SenderReciver> SenderRecivers { get; set; }
        public DbSet<SenderReciverAddress> SenderReciverAddresses { get; set; }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<SenderWarehouse> SenderWarehouses { get; set; }
        public DbSet<TransportationDetail> TransportationDtls { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserWarhouse> UserWarhouses { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WehicleType> WehicleType { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<WehicleType>(entity => { entity.ToTable("WehicleTypes", "dbo"); });
            modelBuilder.Entity<Warehouse>(entity => { entity.ToTable("Warehouses", "dbo"); });
            modelBuilder.Entity<Unit>(entity => { entity.ToTable("Units", "dbo"); });
            modelBuilder.Entity<TransportationDetail>(entity => { entity.ToTable("TransportationDetails", "dbo"); });
            modelBuilder.Entity<SenderWarehouse>(entity => { entity.ToTable("SenderWarehouses", "dbo"); });
            modelBuilder.Entity<Region>(entity => { entity.ToTable("Regions", "dbo"); });
            modelBuilder.Entity<SenderReciver>(entity => { entity.ToTable("SenderRecivers", "dbo"); });
            modelBuilder.Entity<SenderReciverAddress>(entity => { entity.ToTable("SenderReciverAddresses", "dbo"); });
            modelBuilder.Entity<Province>(entity => { entity.ToTable("Provinces", "dbo"); });
            modelBuilder.Entity<Parish>(entity => { entity.ToTable("Parishes", "dbo"); });
            modelBuilder.Entity<Country>(entity => { entity.ToTable("Countries", "dbo"); });
            modelBuilder.Entity<City>(entity => { entity.ToTable("Cities", "dbo"); });
            modelBuilder.Entity<ReceiptStatus>(entity => { entity.ToTable("ReceiptStatuses", "dbo"); });
            modelBuilder.Entity<Receipt>(entity => { entity.ToTable("Receipts", "dbo"); });
            modelBuilder.Entity<ReceiptDetail>(entity => { entity.ToTable("ReceiptDetails", "dbo"); });
            modelBuilder.Entity<ReceiptBin>(entity => { entity.ToTable("ReceiptBins", "dbo"); });
            modelBuilder.Entity<Bin>(entity => { entity.ToTable("Bins", "dbo"); });
            modelBuilder.Entity<MenuPermission>(entity => { entity.ToTable("MenuPermissions", "dbo"); });
            modelBuilder.Entity<RolePermission>(entity => { entity.ToTable("RolePermissions", "dbo"); });
            modelBuilder.Entity<Menu>(entity => { entity.ToTable("Menus", "dbo"); });
            modelBuilder.Entity<Permission>(entity => { entity.ToTable("Permissions", "dbo"); });
            modelBuilder.Entity<Person>(entity => { entity.ToTable("Persons", "dbo"); });
            modelBuilder.Entity<UserRole>(entity => { entity.ToTable("UserRoles", "dbo"); });

            modelBuilder.Entity<UserMenu>(entity =>
            {
                entity.ToTable("UserMenus", "dbo");
                //entity.HasOne<User>(x => x.User)
                //    .WithMany(x => x.UserMenus)
                //    .HasForeignKey(x => x.UserId);
                //entity.HasOne<Menu>(x => x.Menu)
                //    .WithMany(x => x.UserMenus)
                //    .HasForeignKey(x => x.MenuId);
            });

            modelBuilder.Entity<UserType>(entity => { entity.ToTable("UserTypes", "dbo"); });
            modelBuilder.Entity<Role>(entity => { entity.ToTable("Roles", "dbo"); });
            //modelBuilder.Entity<UserWarhouse>(entity =>{ entity.ToTable("UserWarhouses", "dbo"); });
            modelBuilder.Entity<UserWarhouse>(entity =>
            {
                entity.ToTable("UserWarhouses", "dbo");
                //entity.HasOne<User>(x => x.User)
                //    .WithMany().HasForeignKey(x => x.UserId);
                //entity.HasOne<Warehouse>(x => x.Warehouse)
                //    .WithMany()
                //    .HasForeignKey(x => x.WarehouseId);

            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "dbo");
                entity.Property(e => e.ChangePasswordCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Code).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Password).HasMaxLength(200);
                entity.Property(e => e.TwoStepCode).HasMaxLength(10);
                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
