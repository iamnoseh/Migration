using System.Net;
using Dapper;
using Domain;
using Domain.DTOs;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure;


public class BookService(DataContext context) : IBookService
{
    public async Task<Response<List<Book>>> GetBookAsync()
    {
        string sql = "select * from books";
        var _context = context.GetConnection();
        var books = await _context.QueryAsync<Book>(sql);
        if (!books.Any())
        {
            return new Response<List<Book>>(HttpStatusCode.NotFound, "No books found");
        }

        return new Response<List<Book>>(books.ToList());
    }

    public async Task<Response<Book>> GetBookByIdAsync(int id)
    {
        string sql = "select * from books where id = @id";
        var _context = context.GetConnection();
        var book = await _context.QueryAsync<Book>(sql, new { id });
        return book == null
            ? new Response<Book>(HttpStatusCode.NotFound, "No book found")
            : new Response<Book>(book.FirstOrDefault());
    }

    public async Task<Response<bool>> AddBookAsync(Book book)
    {
        string cmd =
            "inset into books(title,authorid,publishedyear,genre,isavailable) values(@Title,@AuthorId,@PublishYear,@Genre,@IsAvailable)";
        var _context = context.GetConnection();
        var effect = await _context.ExecuteAsync(cmd, book);
        return effect == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> UpdateBookAsync(int newid, Book book)
    {
        string cmd =
            "Update books set title = @Title,authorid = AuthorId,publishedyear = @PublishedYear,genre = @Genre,isavailable = @IsAvailable where id = @newid ";
        var _context = context.GetConnection();
        var effect = await _context.ExecuteAsync(cmd, book);
        return effect == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> DeleteBookAsync(int id)
    {
        string cmd = "delete from books where id = @id";
        var _context = context.GetConnection();
        var effect = _context.Execute(cmd, new { id });
        return effect == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(true);
    }

    public async Task<Response<List<BookWithAuthorDTO>>> GetBooksWithAuthorAsync()
    {
        string cmd = @"select * from books as b 
           join authors as a on b.Authorid = a.id";
        var _context = context.GetConnection();
        var books = await _context.QueryAsync<BookWithAuthorDTO>(cmd);
        if (!books.Any())
        {
            return new Response<List<BookWithAuthorDTO>>(HttpStatusCode.NotFound, "No books found");
        }
        return new Response<List<BookWithAuthorDTO>>(books.ToList());
    }


}




