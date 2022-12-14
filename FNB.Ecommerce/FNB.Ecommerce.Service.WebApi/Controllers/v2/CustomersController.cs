using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FNB.Ecommerce.Application.DTO;
using FNB.Ecommerce.Application.Interface;
using Microsoft.AspNetCore.Authorization;

namespace FNB.Ecommerce.Service.WebApi.Controllers.v2
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersApplication _customersApplication;
        public CustomersController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region "Metodos sincronos"
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();
            var response = _customersApplication.Insert(customersDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpPut("Update/{customerId}")]
        public IActionResult Update(string customerId, [FromBody] CustomersDTO customersDTO)
        {
            var customerDTO = _customersApplication.Get(customerId);
            if (customerDTO.Data == null)
                return NotFound(customerDTO.Message);
            if (customersDTO == null)
                return BadRequest();

            var response = _customersApplication.Update(customersDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            var response = _customersApplication.Delete(customerId);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet("Get/{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            var response = _customersApplication.Get(customerId);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _customersApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPagination")]
        public IActionResult GetAllWithPagination([FromQuery] int pageNumber, int pageSize)
        {
            var response = _customersApplication.GetAllWithPagination(pageNumber, pageSize);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }
        #endregion

        #region"metodos asincronos"
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();
            var response = await _customersApplication.InsertAsync(customersDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpPut("UpdateAsync/{customerId}")]
        public async Task<IActionResult> UpdateAsync(string customerId, [FromBody] CustomersDTO customersDTO)
        {
            var costumerDTO = await _customersApplication.GetAsync(customerId);
            if (customersDTO == null)
                return NotFound(costumerDTO.Message);

            if (customersDTO == null)
                return BadRequest();
            var response = await _customersApplication.UpdateAsync(customersDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteAsync/{customerId}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            var response = await _customersApplication.DeleteAsync(customerId);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet("GetAsync/{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            var response = await _customersApplication.GetAsync(customerId);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customersApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<IActionResult> GetAllWithPaginationAsync([FromQuery] int pageNumber, int pageSize)
        {
            var response = await _customersApplication.GetAllWithPaginationAsync(pageNumber, pageSize);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }
        #endregion
    }
}
