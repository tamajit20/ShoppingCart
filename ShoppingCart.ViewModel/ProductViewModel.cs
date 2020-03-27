using ShoppingCart.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.ViewModel
{

    public class ProductViewModels : BaseViewModel
    {
        IList<ProductViewModel> Products { get; set; }

        public void PopulateList(IList<Product> input)
        {
            if (input != null && input.Count > 0)
            {
                Products = new List<ProductViewModel>();
                var converter = new ProductViewModel();

                Parallel.ForEach(input, (current) =>
                {
                    Products.Add(converter.ConvertToViewModel(current));
                });
            }
        }
    }
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<ProductSiteLinkViewModel> ProductSiteLinks { get; set; }


        public ProductViewModel ConvertToViewModel(Product input)
        {
            var ret = new ProductViewModel()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                IsDeleted = input.IsDeleted
            };

            if (input.ProductSiteLinks != null && input.ProductSiteLinks.Count > 0)
            {
                ret.ProductSiteLinks = new List<ProductSiteLinkViewModel>();

                Parallel.ForEach(input.ProductSiteLinks, (currentSubMenu) =>
                { ret.ProductSiteLinks.Add(new ProductSiteLinkViewModel().ConvertToViewModel(currentSubMenu)); });
            }

            return ret;
        }

    }

    public class ProductSiteLinkViewModel : BaseViewModel
    {
        public string Link { get; set; }
        public long FK_WebSiteId { get; set; }
        public string WebSiteName { get; set; }

        public ProductSiteLink ConvertToDBEntity(ProductSiteLinkViewModel input)
        {
            return new ProductSiteLink()
            {
                Id = input.Id,
                FK_WebSiteId = input.FK_WebSiteId,
                IsDeleted = input.IsDeleted
            };
        }

        public ProductSiteLinkViewModel ConvertToViewModel(ProductSiteLink input)
        {
            return new ProductSiteLinkViewModel()
            {
                Id = input.Id,
                FK_WebSiteId = input.FK_WebSiteId,
                WebSiteName = (input.WebSite == null) ? string.Empty : input.WebSite.Name,
                IsDeleted = input.IsDeleted
            };
        }
    }
}
