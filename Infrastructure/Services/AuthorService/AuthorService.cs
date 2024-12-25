using System.Net;
using Dapper;
using Domain;
using Infrastructure.Data;

namespace Infrastructure.Services.AuthorService;

public class AuthorService(DataContext context): IAuthorService
{
    public async Task<Response<Author>> GetAuthorByIdAsync(int id)
    {
        string cmd = "select * from Authors where Id = @id";
        using var _context = context.GetConnection();
        var authors = await _context.QueryAsync(cmd, new { Id = id });
        return authors == null
            ? new Response<Author>(HttpStatusCode.NotFound, "No authors found")
            : new Response<Author>(authors.FirstOrDefault());
    }
    public async Task<Response<bool>> AddAuthorAsync(Author author)
    {
        string cmd = "insert into Authors (Id, Name,Country) values (@Id, @Name,Country)";
        using var _context = context.GetConnection();
        var effect =await _context.ExecuteAsync(cmd, author);
        return effect == 0
            ? new Response<bool>(HttpStatusCode.Created, "Author added")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> DeleteAuthorAsync(int id)
    {
        string cmd = "delete from Authors where Id = @Id";
        var _context = context.GetConnection();
        var author = await _context.ExecuteAsync(cmd, new { Id = id });
        return author == 0 
            ? new Response<bool>(HttpStatusCode.NotFound,"No authors found")
            : new Response<bool>(true);
    }
}