using Domain;
using Infrastructure;
using Infrastructure.Services.AuthorService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService service) : ControllerBase
{
    [HttpGet("[action]/{id}")]
    public async Task<Response<Author>> GetAuthors(int id)
    {
        return await service.GetAuthorByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<bool>> AddAuthor(Author author)
    {
        return await service.AddAuthorAsync(author);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<Response<bool>> DeleteAuthor(int id)
    {
        return await service.DeleteAuthorAsync(id);
    }
}