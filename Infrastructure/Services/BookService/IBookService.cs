using Domain;
using Domain.DTOs;

namespace Infrastructure;

public interface IBookService
{
    Task<Response<List<Book>>> GetBookAsync();
    Task<Response<Book>> GetBookByIdAsync(int id);
    Task<Response<bool>> AddBookAsync(Book book);
    Task<Response<bool>> UpdateBookAsync(int id,Book book);
    Task<Response<bool>> DeleteBookAsync(int id);
    Task<Response<List<BookWithAuthorDTO>>> GetBooksWithAuthorAsync();
}