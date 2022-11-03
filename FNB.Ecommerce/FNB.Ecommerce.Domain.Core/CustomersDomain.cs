using FNB.Ecommerce.Domain.Entity;
using FNB.Ecommerce.Domain.Interface;
using FNB.Ecommerce.Infrastructure.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FNB.Ecommerce.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersDomain(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        #region Metodos Sincronos

        #endregion
    }
}