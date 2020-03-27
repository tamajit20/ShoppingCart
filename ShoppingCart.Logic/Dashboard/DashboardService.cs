using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.DBEntity;
using ShoppingCart.DBConnect.Common;

namespace ShoppingCart.Logic
{
    public class DashboardSercvice : IDashboardService
    {
        private IRepository<CarousellComponent> _carousellRepository;
        private IRepository<BoxComponent> _boxRepository;

        public DashboardSercvice(
            IRepository<CarousellComponent> carousellRepository,
            IRepository<BoxComponent> boxRepository
            )
        {
            _carousellRepository = carousellRepository;
            _boxRepository = boxRepository;
        }

        public IList<CarousellComponent> GetCarousellComponents()
        {
            try
            {
                var predicate = PredicateBuilder.True<CarousellComponent>();
                predicate = predicate.And(x => !x.IsDeleted);

                var result = _carousellRepository.GetAllUsingExpression(out int totalCount, 1, 0, predicate)
                    .OrderBy(x => x.Order).ToList();
              
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<BoxComponent> GetBoxComponents()
        {
            try
            {
                var predicate = PredicateBuilder.True<BoxComponent>();
                predicate = predicate.And(x => !x.IsDeleted);

                var result = _boxRepository.GetAllUsingExpression(out int totalCount, 1, 0, predicate)
                    .OrderBy(x => x.Order).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
