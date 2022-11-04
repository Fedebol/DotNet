using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FNB.Ecommerce.Application.DTO;
using FNB.Ecommerce.Application.Interface;

namespace FNB.Ecommerce.Service.WebApi.Controllers
{
    [Route("api/[controller]/[accion]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersApplication _customersApplication;
        public CustomersController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region "Metodos sincronos"
        [HttpPost]
        public IActionResult Insert([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();
            var response = _customersApplication.Insert(customersDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();
            var response = _customersApplication.Update(customersDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpDelete("{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            var response = _customersApplication.Delete(customerId);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet("{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            var response = _customersApplication.Get(customerId);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _customersApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }
        #endregion

        #region"metodos asincronos"
        [HttpPost]
        public async Task <IActionResult> InsertAsync([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();
            var response = await  _customersApplication.InsertAsync(customersDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task <IActionResult> UpdateAsync([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();
            var response = await _customersApplication.UpdateAsync(customersDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpDelete("{customerId}")]
        public async Task <IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            var response = await _customersApplication.DeleteAsync(customerId);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet("{customerId}")]
        public async Task <IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            var response = await _customersApplication.GetAsync(customerId);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task <IActionResult> GetAllAsync()
        {
            var response = await _customersApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }
        #endregion
    }
}
