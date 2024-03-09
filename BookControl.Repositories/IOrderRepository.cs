using BookControl.Dto;
using BookControl.Dto.Response;
using BookControl.Dto.Response.Consult;
using BookControl.Entities;


namespace BookControl.Repositories
{
    public interface IOrderRepository : IRepositoryBase<Orders>  
    {
        Task<ICollection<OrderResponseDto>> GetOrders();
        Task<ICollection<BookDateRangeResponseDto>> GetOrderByDateRange(DateTime StartDate, DateTime EndDate);

    }
}
