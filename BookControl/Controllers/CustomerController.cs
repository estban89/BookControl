using BookControl.Dto.Response;
using BookControl.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookControl.Controllers
{

    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await service.GetAsync();
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await service.GetAsync(id);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequestDto request)
        {
            var response = await service.AddAsync(request);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, CustomerRequestDto request)
        {
            var response = await service.UpdateAsync(id, request);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await service.DeleteAsync(id);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
