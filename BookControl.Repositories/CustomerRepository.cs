using BookControl.Dto.Response;
using BookControl.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookControl.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<ICollection<BookResponseDto>> GetBooksDni(string Dni)
        {
            return await context.Set<Orders>()
                .Include(x => x.Customer)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Books)
                .Where(x => x.Customer.Dni == Dni)
                .SelectMany(x => x.OrderDetails)
                .Select(x => new BookResponseDto(x.Books.Id, x.Books.Name, x.Books.Author, x.Books.Isbn, x.Books.Status)).ToListAsync();
        }


    }
}
