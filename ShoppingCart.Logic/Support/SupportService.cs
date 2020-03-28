using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.DBEntity;
using ShoppingCart.DBConnect.Common;

namespace ShoppingCart.Logic
{
    public class SupportService : ISupportService
    {
        private IRepository<ContactUs> _contactUsRepository;
        private IRepository<ContactUsType> _contactUsTypeRepository;

        public SupportService(
            IRepository<ContactUs> contactUsRepository,
            IRepository<ContactUsType> contactUsTypeRepository
            )
        {
            _contactUsRepository = contactUsRepository;
            _contactUsTypeRepository = contactUsTypeRepository;
        }

        public long AddContactUs(ContactUs input)
        {
            try
            {
                _contactUsRepository.Add(input);
                return input.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<ContactUsType> GetContactUsTypes()
        {
            try
            {
                var predicate = PredicateBuilder.True<ContactUsType>();
                predicate = predicate.And(x => !x.IsDeleted);

                var result = _contactUsTypeRepository.GetAllUsingExpression(out int totalCount, 1, 0, predicate).OrderBy(x=>x.Type).ToList();                
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
