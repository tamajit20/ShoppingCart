using ShoppingCart.DBEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.ViewModel
{
    public class CarousellCompomentViewModels : BaseViewModel
    {
        public IList<CarousellComponentViewModel> Carousells { get; set; }

        public void PopulateList(IList<CarousellComponent> components)
        {
            if (components != null && components.Count > 0)
            {
                Carousells = new List<CarousellComponentViewModel>();
                var converter = new CarousellComponentViewModel();

                Parallel.ForEach(components, (current) =>
                {
                    Carousells.Add(converter.ConvertToViewModel(current));
                });
            }
        }
    }

    public class CarousellComponentViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public int Order { get; set; }

        public CarousellComponent ConvertToDBEntity(CarousellComponentViewModel component)
        {
            return new CarousellComponent()
            {
                Id = component.Id,
                Name = component.Name,
                Link = component.Link,
                Order = component.Order,
                IsDeleted = component.IsDeleted
            };
        }

        public CarousellComponentViewModel ConvertToViewModel(CarousellComponent component)
        {
            return new CarousellComponentViewModel()
            {
                Id = component.Id,
                Name = component.Name,
                Link = component.Link,
                Order = component.Order,
                IsDeleted = component.IsDeleted
            };
        }
    }
}
