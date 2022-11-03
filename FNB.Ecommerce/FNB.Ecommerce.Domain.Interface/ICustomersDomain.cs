using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNB.Ecommerce.Domain.Entity;

namespace FNB.Ecommerce.Domain.Interface
{
    public interface ICustomersDomain
    {

        #region Metodos sincronos
        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string customerId);
        Customers Get(string customerId);
        IEnumerable<Customers> GetAll();
        #endregion

        #region Metodos asincronos

        Task<bool> InsertAsync(Customers customer);
        Task<bool> UpdateAsync(Customers customer);
        Task<bool> DeleteAsync(string customerId);
        Task<Customers> GetAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();

        #endregion

    }
}
