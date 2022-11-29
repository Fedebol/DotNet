using AutoMapper;
using FNB.Ecommerce.Application.DTO;
using FNB.Ecommerce.Application.Interface;
using FNB.Ecommerce.Domain.Entity;
using FNB.Ecommerce.Domain.Interface;
using FNB.Ecommerce.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace FNB.Ecommerce.Application.Main
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;

        public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper, IAppLogger<CustomersApplication> logger)
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #region metodos sincronos

        public Response<bool> Insert(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = _customersDomain.Insert(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!";
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
            }
            return response;
        }
        public Response<bool> Update(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = _customersDomain.Update(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion Exitosa!!";
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
            }
            return response;
        }
        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customersDomain.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion Exitosa!!";
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
            }
            return response;
        }
        public Response<CustomersDTO> Get(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = _customersDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!";
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
            }
            return response;
        }
        public Response<IEnumerable<CustomersDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customer = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!";
                    _logger.LogInformation("consulta Exitosa!!");
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
                _logger.LogError(Ex.Message);
            }
            return response;
        }
        public ResponsePagination<IEnumerable<CustomersDTO>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomersDTO>>();
            try
            {
                var count = _customersDomain.Count();
                var customers = _customersDomain.GetAllWithPagination(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);

                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSuccess=true;
                    response.Message = "Consulta Paginada Exitosa!";
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;

            }
            return response;
        }
        #endregion

        #region metodos Asincronos

        public async Task<Response<bool>> InsertAsync(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = await _customersDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!";
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = await _customersDomain.UpdateAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion Exitosa!!";
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customersDomain.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion Exitosa!!";
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
            }
            return response;
        }
        public async Task<Response<CustomersDTO>> GetAsync(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = await _customersDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!";
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customer = await _customersDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!";
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
            }
            return response;
        }

      

        public async Task<ResponsePagination<IEnumerable<CustomersDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomersDTO>>();
                try
                {
                    var count = await _customersDomain.CountAsync();
                    var customers = await _customersDomain.GetAllWithPaginationAsync(pageNumber, pageSize);
                    response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);

                    if (response.Data != null)
                    {
                        response.PageNumber = pageNumber;
                        response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                        response.TotalCount = count;
                        response.IsSuccess = true;
                        response.Message = "Consulta Paginada Exitosa!";
                    }
                }
                catch (Exception ex)
                {

                    response.Message = ex.Message;

                }
                return response;
            
        }

        #endregion
    }
}