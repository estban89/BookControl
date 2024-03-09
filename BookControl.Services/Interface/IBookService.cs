using BookControl.Dto.Response;
using BookControl.Dto;

namespace BookControl.Services.Interface
{
    public interface IBookService
    {
        Task<BaseResponseGenerics<ICollection<BookResponseDto>>> GetAsync();
        Task<BaseResponseGenerics<BookResponseDto>> GetAsync(string id);
        Task<BaseResponseGenerics<BookResponseDto>> AddAsync(BookRequestDto request);
        Task<BaseResponse> UpdateAsync(string id, BookRequestDto request);
        Task<BaseResponse> DeleteAsync(string id);
        Task<BaseResponseGenerics<ICollection<BookResponseDto>>> GetBooksDni(string Dni);
    }
}
