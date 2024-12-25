using Domain;

namespace Infrastructure.Services.AuthorService;

public interface IAuthorService
{
    Task<Response<Author>> GetAuthorByIdAsync(int id);
    Task<Response<bool>> AddAuthorAsync(Author author);
    Task<Response<bool>> DeleteAuthorAsync(int id);
}