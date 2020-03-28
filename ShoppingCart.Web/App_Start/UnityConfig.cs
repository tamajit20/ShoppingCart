using ShoppingCart.DBConnect.Common;
using ShoppingCart.DBEntity;
using ShoppingCart.Logic;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ShoppingCart.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            //Register Services
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IMenuService, MenuService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IDashboardService, DashboardSercvice>();

            //Register Repositories
            container.RegisterType<IRepository<User>, Repository<User>>();
            container.RegisterType<IRepository<Menu>, Repository<Menu>>();
            container.RegisterType<IRepository<SubMenu>, Repository<SubMenu>>();
            container.RegisterType<IRepository<Category>, Repository<Category>>();
            container.RegisterType<IRepository<SubCategory>, Repository<SubCategory>>();
            container.RegisterType<IRepository<Product>, Repository<Product>>();
            container.RegisterType<IRepository<Website>, Repository<Website>>();
            container.RegisterType<IRepository<ProductSiteLink>, Repository<ProductSiteLink>>();
            container.RegisterType<IRepository<CarousellComponent>, Repository<CarousellComponent>>();
            container.RegisterType<IRepository<BoxComponent>, Repository<BoxComponent>>();
            container.RegisterType<IRepository<ProductImage>, Repository<ProductImage>>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}