using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DBEntity;
using ShoppingCart.DBConnect.Common;

namespace ShoppingCart.Logic
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public long AddProduct(Product product)
        {
            try
            {
                _productRepository.Add(product);
                return product.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Product> GetProducts()
        {
            try
            {
                var predicate = PredicateBuilder.True<Product>();
                predicate = predicate.And(x => !x.IsDeleted);

                var result = _productRepository.GetAllUsingExpression(out int totalCount, 1, 0, predicate).ToList();

                Parallel.ForEach(result, (each) =>
                {
                    if (each.ProductSiteLinks != null)
                    {
                        each.ProductSiteLinks = each.ProductSiteLinks.Where(x => !x.IsDeleted).ToList();
                    }

                    if (each.ProductImages != null)
                    {
                        each.ProductImages = each.ProductImages.Where(x => !x.IsDeleted).OrderBy(x=>x.Order).ToList();
                    }
                });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
