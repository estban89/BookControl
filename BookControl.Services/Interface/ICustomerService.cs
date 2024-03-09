using BookControl.Dto;
using BookControl.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Services.Interface
{
    public interface ICustomerService
    {
        Task<BaseResponseGenerics<ICollection<CustomerResponseDto>>> GetAsync();
        Task<BaseResponseGenerics<CustomerResponseDto>> GetAsync(string id);
        Task<BaseResponseGenerics<CustomerResponseDto>> AddAsync(CustomerRequestDto request);
        Task<BaseResponse> UpdateAsync(string id, CustomerRequestDto request);
        Task<BaseResponse> DeleteAsync(string id);
    }
}
