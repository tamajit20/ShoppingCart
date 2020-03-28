using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DBEntity;
using ShoppingCart.DBConnect.Common;

namespace ShoppingCart.Logic
{
    public class MenuService : IMenuService
    {
        private IRepository<Menu> _menuRepository;

        public MenuService(IRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public long AddMenu(Menu menu)
        {
            try
            {
                _menuRepository.Add(menu);
                return menu.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Menu> GetMenus()
        {
            try
            {
                var predicate = PredicateBuilder.True<Menu>();
                predicate = predicate.And(x => !x.IsDeleted);

                var result = _menuRepository.GetAllUsingExpression(out int totalCount, 1, 0, predicate)
                    .OrderBy(x => x.Order).ToList();

                Parallel.ForEach(result, (each) =>
                {
                    if (each.SubMenus != null)
                    {
                        each.SubMenus = each.SubMenus.Where(x => !x.IsDeleted).OrderBy(y => y.Order).ToList();
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
