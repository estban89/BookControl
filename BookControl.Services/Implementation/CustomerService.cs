using AutoMapper;
using BookControl.Dto;
using BookControl.Dto.Response;
using BookControl.Entities;
using BookControl.Repositories;
using BookControl.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;
        private readonly ILogger<CustomerService> logger;
        private readonly IMapper mapper;

        public CustomerService(ICustomerRepository repository, ILogger<CustomerService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<BaseResponseGenerics<ICollection<CustomerResponseDto>>> GetAsync()
        {
            var response = new BaseResponseGenerics<ICollection<CustomerResponseDto>>();
            try
            {
                var data = await repository.GetAsync();
                response.Data = mapper.Map<ICollection<CustomerResponseDto>>(data);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener los clientes.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGenerics<CustomerResponseDto>> GetAsync(string id)
        {
            var response = new BaseResponseGenerics<CustomerResponseDto>();
            try
            {
                var data = await repository.GetAsync(id);
                response.Data = mapper.Map<CustomerResponseDto>(data);
                response.IsSuccess = data != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener el cliente por el id: " + id;
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGenerics<CustomerResponseDto>> AddAsync(CustomerRequestDto request)
        {
            var response = new BaseResponseGenerics<CustomerResponseDto>();
            try
            {
                Customer customer = await repository.AddAsync(mapper.Map<Customer>(request));
                response.Data = new CustomerResponseDto(customer.Id, customer.Name, customer.LastName, customer.Dni, customer.Age);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al insertar el cliente";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(string id)
        {
            var response = new BaseResponse();
            try
            {
                await repository.DeleteAsync(id);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al eliminar el cliente";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(string id, CustomerRequestDto request)
        {
            var response = new BaseResponse();
            try
            {
                var data = await repository.GetAsync(id);
                if (data is null)
                {
                    response.ErrorMessage = "El cliente no fue encontrado";
                    return response;
                }
                mapper.Map(request, data);
                await repository.UpdateAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al actualizar el cliente";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

    }
}
