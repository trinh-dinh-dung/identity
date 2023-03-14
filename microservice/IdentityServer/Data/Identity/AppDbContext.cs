using IdentityServer.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data.Identity
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> departments { get; set; }
        public DbSet<JobTitle> jobTitles { get; set; }

        public DbSet<Menu> menus { get; set; }
        public DbSet<Permissions> permissions { get; set; }
        public DbSet<PermissionMenu> permissionMenus { get; set; }
        public DbSet<UserPermission> userPermissions { get; set; }
        public DbSet<ActionMenu> actionMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            //modelBuilder.Entity<ActionMenu>(entity =>
            //{
            //    // table mapping
            //    entity.ToTable("ActionMenu");

            //    //pk
            //    entity.HasKey(p => p.Id);

            //    // Index
            //    entity.HasIndex(p => p.Price)
            //    .HasDatabaseName("index-sanpham-price");

            //    // Relative
            //    entity.HasOne(p => p.MenuId)
            //    .WithMany(p => p.MenuId) // category ko có propety ~ sanoham
            //    .HasForeignKey("CateId") // đặt tên Fk
            //    .OnDelete(DeleteBehavior.Cascade)// xóa cate thì có xóa list product hay ko ( xóa phần 1 thì có xóa phần nhiều hay ko )
            //    .HasConstraintName("Khoa_ngoai_sanpham_category")
            //    ;

            //    entity.Property(p => p.Name)
            //    .HasColumnName("title")
            //    .HasColumnType("nvarchar")
            //    .HasMaxLength(60)
            //    .IsRequired(false)
            //    .HasDefaultValue(" điện thoại samsung ")
            //    ;

            //});

        }

    }
}
