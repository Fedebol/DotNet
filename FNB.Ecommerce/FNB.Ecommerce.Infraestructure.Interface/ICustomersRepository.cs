﻿using FNB.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNB.Ecommerce.Infrastructure.Interface
{
    public interface ICustomersRepository
    {
        #region Metodos sincronos
        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string customerId);
        Customers Get(string customerId);
        IEnumerable<Customers> GetAll();
        #endregion

        #region Metodos asincronos

        Task <bool> InsertAsync(Customers customer);
        Task<bool> UpdateAsync(Customers customer);
        Task<bool> DeleteAsync(string customerId);
        Task <Customers> GetAsync(string customerId);
        Task <IEnumerable<Customers>> GetAllAsync();

        #endregion
    }
}
