using MySql.Data.Entity;
using ShoppingCart.DBEntity;
using System.Data.Entity;

namespace ShoppingCart.DBConnect.MySQL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySQLDBContext : DbContext
    {
        public MySQLDBContext() : base("mysqlCon")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("tUser").HasKey(t=>t.Id);

            modelBuilder.Entity<Menu>().ToTable("tMenu").HasKey(t => t.Id)
                .HasMany(l => l.SubMenus).WithRequired().HasForeignKey(f => f.FK_MenuId); 

            modelBuilder.Entity<SubMenu>().ToTable("tSubMenu").HasKey(t => t.Id);

            modelBuilder.Entity<Category>().ToTable("tCategory").HasKey(t=>t.Id)
                      .HasMany(l => l.SubCategories).WithRequired().HasForeignKey(f=>f.FK_CategoryId);

            modelBuilder.Entity<SubCategory>().ToTable("tSubCategory").HasKey(t => t.Id);

            modelBuilder.Entity<Product>().ToTable("tProduct").HasKey(t => t.Id)
                     .HasMany(l => l.ProductSiteLinks).WithRequired().HasForeignKey(f => f.FK_ProductId);

            modelBuilder.Entity<Product>().ToTable("tProduct").HasKey(t => t.Id)
                   .HasMany(l => l.ProductImages).WithRequired().HasForeignKey(f => f.FK_ProductId);

            modelBuilder.Entity<ProductSiteLink>().ToTable("tProductSiteLink").HasKey(t => t.Id)
                 .HasRequired(e => e.WebSite).WithOptional();

            modelBuilder.Entity<ProductImage>().ToTable("tProductImage").HasKey(t => t.Id);

            modelBuilder.Entity<Website>().ToTable("tWebsite").HasKey(t => t.Id);

            modelBuilder.Entity<CarousellComponent>().ToTable("tCarousellComponent").HasKey(t => t.Id);

            modelBuilder.Entity<BoxComponent>().ToTable("tBoxComponent").HasKey(t => t.Id);

            modelBuilder.Entity<ContactUs>().ToTable("tContactUs").HasKey(t => t.Id);

            modelBuilder.Entity<ContactUsType>().ToTable("tContactUsType").HasKey(t => t.Id);
        }
    }
}
