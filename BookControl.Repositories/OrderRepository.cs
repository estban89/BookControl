using AutoMapper;
using BookControl.Dto;
using BookControl.Dto.Response;
using BookControl.Dto.Response.Consult;
using BookControl.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookControl.Repositories
{
    public class OrderRepository : RepositoryBase<Orders>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<ICollection<OrderResponseDto>> GetOrders()
        {
            return await context.Set<Orders>()
                .Include(x => x.Customer)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Books)
                .Select(x => new OrderResponseDto(x.Id, x.DateOrder,
                                                                 new CustomerResponseDto(x.Customer.Id, x.Customer.Name, x.Customer.LastName, x.Customer.Dni, x.Customer.Age), MapOrderDetail(x.OrderDetails), x.Status)).ToListAsync();
        }

        private static List<OrderDetailResponseDto> MapOrderDetail(List<OrderDetail> orderDetails)
        {
            List<OrderDetailResponseDto> orderDetailResponseDtos = new List<OrderDetailResponseDto>();
            foreach (var item in orderDetails)
            {
                orderDetailResponseDtos.Add(new OrderDetailResponseDto(item.Id, new BookResponseDto(item.Books.Id, item.Books.Name, item.Books.Author, item.Books.Isbn, item.Books.Status)));
            }
            return orderDetailResponseDtos;
        }

        public async Task<ICollection<BookDateRangeResponseDto>> GetOrderByDateRange(DateTime StartDate, DateTime EndDate)
        {
            return await context.Set<Orders>()
                .Where(x => x.DateOrder >= StartDate && x.DateOrder <= EndDate)
                .Select(x => new BookDateRangeResponseDto(x.Id,x.DateOrder,x.Status)).ToListAsync();
        }

    }

}
