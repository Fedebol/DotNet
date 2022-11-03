using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNB.Ecommerce.Application.DTO;
using FNB.Ecommerce.Transversal.Common;
using System.Threading.Tasks;




namespace FNB.Ecommerce.Application.Interface
{
    public interface ICustomersApplication
    {
        #region metodos sincronos

        Response <bool> Insert(CustomersDTO customersDTO);
        Response <bool> Update(CustomersDTO customersDTO);
        Response <bool> Delete(string customerId);
        Response <CustomersDTO> Get(string customerId);
        Response <IEnumerable<CustomersDTO>> GetAll();

        #endregion

        #region metodos Asincronos

        Task <Response <bool>> InsertAsync(CustomersDTO customersDTO);
        Task<Response<bool>> UpdateAsync(CustomersDTO customersDTO);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomersDTO>>  GetAsync(string customerId);
        Task <Response<IEnumerable<CustomersDTO>>> GetAllAsync();

        #endregion

    }
}
