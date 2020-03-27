using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.DBEntity;
using ShoppingCart.DBConnect.Common;

namespace ShoppingCart.Logic
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public long AddCategory(Category category)
        {
            try
            {
                _categoryRepository.Add(category);
                return category.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Category> GetCategories()
        {
            try
            {
                var predicate = PredicateBuilder.True<Category>();
                predicate = predicate.And(x => !x.IsDeleted);

                var result = _categoryRepository.GetAllUsingExpression(out int totalCount, 1, 0, predicate)
                    .OrderBy(x => x.Order).ToList();

                Parallel.ForEach(result, (each) =>
                {
                    if (each.SubCategories != null)
                    {
                        each.SubCategories = each.SubCategories.FindAll(x => !x.IsDeleted).OrderBy(y => y.Order).ToList();
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
