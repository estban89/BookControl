using BookControl.Dto.Request;
using BookControl.Dto.Response;
using BookControl.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookControl.Controllers
{

    [ApiController]
    [Route("api/orders")]
    public class OrderController: ControllerBase
    {
        private readonly IOrderService service;

        public OrderController(IOrderService service)
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
        public async Task<IActionResult> Post(OrderRequestDto request)
        {
            var response = await service.AddAsync(request);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, OrderUpdateRequestDto request)
        {
            var response = await service.UpdateAsync(id, request);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("orderByDateRange/{StartDate}/{EndDate}")]
        public async Task<IActionResult> GetOrderByDateRange(DateTime StartDate, DateTime EndDate)
        {
            var response = await service.GetOrderByDateRange(StartDate, EndDate);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

    }
}
