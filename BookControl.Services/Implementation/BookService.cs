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
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Services.Implementation
{
    public class BookService : IBookService
    {

        private readonly IBookRepository repository;
        private readonly ILogger<BookService> logger;
        private readonly IMapper mapper;

        public BookService(IBookRepository repository, ILogger<BookService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<BaseResponseGenerics<ICollection<BookResponseDto>>> GetAsync()
        {
            var response = new BaseResponseGenerics<ICollection<BookResponseDto>>();
            try
            {
                var data = await repository.GetAsync();
                response.Data = mapper.Map<ICollection<BookResponseDto>>(data);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener los libros.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGenerics<BookResponseDto>> GetAsync(string id)
        {
            var response = new BaseResponseGenerics<BookResponseDto>();
            try
            {
                var data = await repository.GetAsync(id);
                response.Data = mapper.Map<BookResponseDto>(data);
                response.IsSuccess = data != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener el libro por el id: " + id;
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGenerics<BookResponseDto>> AddAsync(BookRequestDto request)
        {
            var response = new BaseResponseGenerics<BookResponseDto>();
            try
            {
                Book book = await repository.AddAsync(mapper.Map<Book>(request));
                response.Data = new BookResponseDto(book.Id, book.Name, book.Author, book.Isbn, book.Status);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al insertar el libro";
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
                response.ErrorMessage = "Ocurrió un error al eliminar el libro";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(string id, BookRequestDto request)
        {
            var response = new BaseResponse();
            try
            {
                var data = await repository.GetAsync(id);
                if (data is null)
                {
                    response.ErrorMessage = "El libro no fue encontrado";
                    return response;
                }
                mapper.Map(request, data);
                await repository.UpdateAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al actualizar el libro";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGenerics<ICollection<BookResponseDto>>> GetBooksDni(string Dni)
        {
            var response = new BaseResponseGenerics<ICollection<BookResponseDto>>();
            try
            {
                var data = await repository.GetBooksDni(Dni);
                response.Data = mapper.Map<ICollection<BookResponseDto>>(data);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener los libros por el Dni: " + Dni;
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }   
    }
}
