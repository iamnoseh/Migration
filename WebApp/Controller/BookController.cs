using Domain;
using Domain.DTOs;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;
[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService service): ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Book>>> GetBooks()
    {
        return await service.GetBookAsync();
    }

    [HttpGet("[action]/{id}")]
    public async Task<Response<Book>> GetBook(int id)
    {
        return await service.GetBookByIdAsync(id);
    }

    [HttpGet("/books-authors")]
    public async Task<Response<List<BookWithAuthorDTO>>> GetBooksAuthors()
    {
        return await service.GetBooksWithAuthorAsync();
    }

    [HttpPost]
    public async Task<Response<bool>> PostBook(Book book)
    {
        return await service.AddBookAsync(book);
    }

    [HttpPut("[action]/{id}")]
    public async Task<Response<bool>> PutBook(int id, Book book)
    {
        return await service.UpdateBookAsync(id, book);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<Response<bool>> DeleteBook(int id)
    {
        return await service.DeleteBookAsync(id);
    }
    
}