using AutoMapper;
using BookControl.Dto;
using BookControl.Dto.Request;
using BookControl.Dto.Response;
using BookControl.Dto.Response.Consult;
using BookControl.Entities;
using BookControl.Repositories;
using BookControl.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Services.Implementation
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository repository;
        private readonly ILogger<OrderService> logger;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository repository, ILogger<OrderService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<BaseResponseGenerics<OrderResponseDto>> AddAsync(OrderRequestDto request)
        {
            var response = new BaseResponseGenerics<OrderResponseDto>();
            try
            {
                var orderEntity = mapper.Map<Orders>(request);
                var order = await repository.AddAsync(orderEntity);
                response.Data = new OrderResponseDto(order.Id,order.DateOrder,null, null,order.Status);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al insertar el libro";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGenerics<ICollection<OrderResponseDto>>> GetAsync()
        {
            var response = new BaseResponseGenerics<ICollection<OrderResponseDto>>();
            try
            {
                var data = await repository.GetOrders();
                response.Data = mapper.Map<ICollection<OrderResponseDto>>(data);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener los pedidos.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGenerics<OrderResponseDto>> GetAsync(string id)
        {
            var response = new BaseResponseGenerics<OrderResponseDto>();
            try
            {
                var data = await repository.GetAsync(id);
                response.Data = mapper.Map<OrderResponseDto>(data);
                response.IsSuccess = data != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener el pedido por el id: " + id;
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(string id, OrderUpdateRequestDto request)
        {
            var response = new BaseResponse();
            try
            {
                var data = await repository.GetAsync(id);
                if (data is null)
                {
                    response.ErrorMessage = "El pedido no fue encontrado";
                    return response;
                }
                mapper.Map(request, data);
                await repository.UpdateAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al actualizar el pedido";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGenerics<ICollection<BookDateRangeResponseDto>>> GetOrderByDateRange(DateTime StartDate, DateTime EndDate)
        {
            var response = new BaseResponseGenerics<ICollection<BookDateRangeResponseDto>>();
            try
            {
                var data = await repository.GetOrderByDateRange(StartDate, EndDate);
                response.Data = mapper.Map<ICollection<BookDateRangeResponseDto>>(data);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener los pedidos";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
    }
}
