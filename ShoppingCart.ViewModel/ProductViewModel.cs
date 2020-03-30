using ShoppingCart.DBEntity;
using System.Collections.Generic;
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
        public string PrimaryImage { get; set; }
        public IList<ProductSiteLinkViewModel> ProductSiteLinks { get; set; }
        public IList<ProductImageViewModel> Images { get; set; }


        public ProductViewModel ConvertToViewModel(Product input)
        {
            var ret = new ProductViewModel()
            {
                Id = input.Id,
                Name = input.Name,
                PrimaryImage = PrimaryImage,
                Description = input.Description,
                IsDeleted = input.IsDeleted
            };

            if (input.ProductSiteLinks != null && input.ProductSiteLinks.Count > 0)
            {
                ret.ProductSiteLinks = new List<ProductSiteLinkViewModel>();

                Parallel.ForEach(input.ProductSiteLinks, (currentSubMenu) =>
                { ret.ProductSiteLinks.Add(new ProductSiteLinkViewModel().ConvertToViewModel(currentSubMenu)); });
            }

            if (input.ProductImages != null && input.ProductImages.Count > 0)
            {
                ret.Images = new List<ProductImageViewModel>();
                Parallel.ForEach(input.ProductImages, (currentImage) =>
                     {
                         ret.Images.Add(new ProductImageViewModel().ConvertToViewModel(currentImage));
                     });
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

    public class ProductImageViewModel : BaseViewModel
    {
        public string Image { get; set; }
        public int Order { get; set; }

        public ProductImage ConvertToDBEntity(ProductImageViewModel input)
        {
            return new ProductImage()
            {
                Id = input.Id,
                Image = input.Image,
                Order = input.Order,
                IsDeleted = input.IsDeleted
            };
        }

        public ProductImageViewModel ConvertToViewModel(ProductImage input)
        {
            return new ProductImageViewModel()
            {
                Id = input.Id,
                Image = input.Image,
                Order = input.Order,
                IsDeleted = input.IsDeleted
            };
        }
    }
}

