using BookControl.Dto.Response;
using BookControl.Entities;

namespace BookControl.Repositories
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<ICollection<BookResponseDto>> GetBooksDni(string Dni);
    }
}
