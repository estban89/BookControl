using AutoMapper;
using BookControl.Dto.Response;
using BookControl.Entities;


namespace BookControl.Services.Profiles
{
    public class BookProfile: Profile
    {
          public BookProfile()
        {
                CreateMap<Book, BookResponseDto>();
                CreateMap<BookRequestDto, Book>();
          }
    }
}
