using BookControl.Dto.Response;
using BookControl.Dto;
using BookControl.Dto.Response.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookControl.Dto.Request;

namespace BookControl.Services.Interface
{
    public interface IOrderService
    {
        Task<BaseResponseGenerics<ICollection<OrderResponseDto>>> GetAsync();
        Task<BaseResponseGenerics<OrderResponseDto>> GetAsync(string id);
        Task<BaseResponseGenerics<OrderResponseDto>> AddAsync(OrderRequestDto request);
        Task<BaseResponse> UpdateAsync(string id, OrderUpdateRequestDto request);
        Task<BaseResponseGenerics<ICollection<BookDateRangeResponseDto>>> GetOrderByDateRange(DateTime StartDate, DateTime EndDate);

    }
}
