using ShoppingCart.DBEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.ViewModel
{

    public class CategoryViewModels 
    {
        IList<CategoryViewModel> Categories { get; set; }

        public void PopulateList(IList<Category> categories)
        {
            if (categories != null && categories.Count > 0)
            {
                Categories = new List<CategoryViewModel>();
                var converter = new CategoryViewModel();

                Parallel.ForEach(categories, (current) =>
                {
                    Categories.Add(converter.ConvertToViewModel(current));
                });
            }
        }
    }

    public class CategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Navigation { get; set; }
        public int Order { get; set; }
        public IList<SubCategoryViewModel> SubCategories { get; set; }

        public Category ConvertToDBEntity(CategoryViewModel category)
        {
            var ret = new Category()
            {
                Id = category.Id,
                Navigation = category.Navigation,
                Name = category.Name,
                Order = category.Order,
                IsDeleted = category.IsDeleted
            };

            if (category.SubCategories != null && category.SubCategories.Count > 0)
            {
                ret.SubCategories = new List<SubCategory>();

                Parallel.ForEach(category.SubCategories, (currentSubCateogry) =>
                { ret.SubCategories.Add(new SubCategoryViewModel().ConvertToDBEntity(currentSubCateogry)); });
            }

            return ret;
        }

        public CategoryViewModel ConvertToViewModel(Category category)
        {
            var ret = new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                Order = category.Order,
                Navigation = category.Navigation,
                IsDeleted = category.IsDeleted
            };

            if (category.SubCategories != null && category.SubCategories.Count > 0)
            {
                ret.SubCategories = new List<SubCategoryViewModel>();

                Parallel.ForEach(category.SubCategories, (currentSubcatgory) =>
                { ret.SubCategories.Add(new SubCategoryViewModel().ConvertToViewModel(currentSubcatgory)); });
            }

            return ret;
        }
    }

    public class SubCategoryViewModel : BaseViewModel
    {
        public long FK_CategoryId { get; set; }
        public string Name { get; set; }
        public string Navigation { get; set; }
        public int Order { get; set; }
        
        public SubCategory ConvertToDBEntity(SubCategoryViewModel subCategory)
        {
            return new SubCategory()
            {
                Id = subCategory.Id,
                Navigation = subCategory.Navigation,
                Name = subCategory.Name,
                Order = subCategory.Order,
                IsDeleted = subCategory.IsDeleted
            };
        }

        public SubCategoryViewModel ConvertToViewModel(SubCategory subCategory)
        {
            return new SubCategoryViewModel()
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                Order = subCategory.Order,
                Navigation = subCategory.Navigation,
                IsDeleted = subCategory.IsDeleted
            };
        }

    }
}
