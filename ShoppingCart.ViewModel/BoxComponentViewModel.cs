using ShoppingCart.DBEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.ViewModel
{
    public class BoxCompomentViewModels : BaseViewModel
    {
        public IList<BoxComponentViewModel> Boxes { get; set; }

        public void PopulateList(IList<BoxComponent> components)
        {
            if (components != null && components.Count > 0)
            {
                Boxes = new List<BoxComponentViewModel>();
                var converter = new BoxComponentViewModel();

                Parallel.ForEach(components, (current) =>
                {
                    Boxes.Add(converter.ConvertToViewModel(current));
                });
            }
        }
    }

    public class BoxComponentViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public int Order { get; set; }
        public string Text { get; set; }

        public BoxComponent ConvertToDBEntity(BoxComponentViewModel component)
        {
            return new BoxComponent()
            {
                Id = component.Id,
                Name = component.Name,
                Link = component.Link,
                Order = component.Order,
                Text = component.Text,
                IsDeleted = component.IsDeleted
            };
        }

        public BoxComponentViewModel ConvertToViewModel(BoxComponent component)
        {
            return new BoxComponentViewModel()
            {
                Id = component.Id,
                Name = component.Name,
                Link = component.Link,
                Order = component.Order,
                Text = component.Text,
                IsDeleted = component.IsDeleted
            };
        }
    }
}
