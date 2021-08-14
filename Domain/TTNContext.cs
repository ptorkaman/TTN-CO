using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class TTNContext : DbContext
    {
        public TTNContext()
        {
        }

        public TTNContext(DbContextOptions<TTNContext> options)
            : base(options)
        {
        }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<UserMenu> UserMenus { get; set; }
        public DbSet<MenuPermission> MenuPermissions { get; set; }
        public DbSet<User> Users { get; set; }
        public  DbSet<UserRole> UserRoles { get; set; }
        public  DbSet<Role> Roles { get; set; }
        public  DbSet<RolePermission> RolePermissions { get; set; }
        public  DbSet<Menu> Menus { get; set; }
        public  DbSet<Permission> Permissions { get; set; }
        public  DbSet<Person> Persons { get; set; }
        public  DbSet<Bin> Bins { get; set; }
        public  DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptBin> ReceiptBins { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetails { get; set; }
        public DbSet<ReceiptStatus> ReceiptStatuses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Parish> Parishes { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<SenderReciver> SenderRecivers { get; set; }
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

            modelBuilder.Entity<WehicleType>(entity =>{entity.ToTable("WehicleTypes", "TTN"); });
            modelBuilder.Entity<Warehouse>(entity =>{entity.ToTable("Warehouses", "TTN");});
            modelBuilder.Entity<Unit>(entity => {entity.ToTable("Units", "TTN");});
            modelBuilder.Entity<TransportationDetail>(entity => { entity.ToTable("TransportationDetails", "TTN"); });
            modelBuilder.Entity<SenderWarehouse>(entity => { entity.ToTable("SenderWarehouses", "TTN"); });
            modelBuilder.Entity<Region>(entity =>  {  entity.ToTable("Regions", "TTN"); });
            modelBuilder.Entity<SenderReciver>(entity => { entity.ToTable("SenderRecivers", "TTN"); });
            modelBuilder.Entity<Province>(entity => {entity.ToTable("Provinces", "TTN"); });
            modelBuilder.Entity<Parish>(entity => {entity.ToTable("Parishes", "TTN");});
            modelBuilder.Entity<Country>(entity =>{ entity.ToTable("Countries", "TTN");});
            modelBuilder.Entity<City>(entity => {entity.ToTable("Cities", "TTN");});
            modelBuilder.Entity<ReceiptStatus>(entity => { entity.ToTable("ReceiptStatuses", "TTN");});
            modelBuilder.Entity<Receipt>(entity => { entity.ToTable("Receipts", "TTN");});
            modelBuilder.Entity<ReceiptDetail>(entity =>{ entity.ToTable("ReceiptDetails", "TTN"); });
            modelBuilder.Entity<ReceiptBin>(entity => { entity.ToTable("ReceiptBins", "TTN");});
            modelBuilder.Entity<Bin>(entity =>  { entity.ToTable("Bins", "TTN");  });
            modelBuilder.Entity<MenuPermission>(entity =>{ entity.ToTable("MenuPermissions", "TTN");});
            modelBuilder.Entity<RolePermission>(entity =>  {entity.ToTable("RolePermissions", "TTN");  });
            modelBuilder.Entity<Menu>(entity =>  { entity.ToTable("Menus", "TTN"); });
            modelBuilder.Entity<Permission>(entity =>{  entity.ToTable("Permissions", "TTN"); });
            modelBuilder.Entity<Person>(entity => {  entity.ToTable("Persons", "TTN"); });
            modelBuilder.Entity<UserRole>(entity =>{entity.ToTable("UserRoles", "TTN"); });

            modelBuilder.Entity<UserMenu>(entity =>
            {
                entity.ToTable("UserMenus", "TTN");
                entity.HasOne<User>(x => x.User)
                    .WithMany(x => x.UserMenus)
                    .HasForeignKey(x => x.UserId);
                entity.HasOne<Menu>(x => x.Menu)
                    .WithMany(x => x.UserMenus)
                    .HasForeignKey(x => x.MenuId);
            });

            modelBuilder.Entity<UserType>(entity => { entity.ToTable("UserTypes", "TTN");});
            modelBuilder.Entity<Role>(entity =>{ entity.ToTable("Roles", "TTN");});
            modelBuilder.Entity<UserWarhouse>(entity =>{ entity.ToTable("UserWarhouses", "TTN"); });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "TTN");
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
