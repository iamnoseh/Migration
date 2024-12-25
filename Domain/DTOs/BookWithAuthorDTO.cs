namespace Domain.DTOs;

public class BookWithAuthorDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime PublishedYear { get; set; }
    public string? Genre { get; set; }
    public bool IsAvailable { get; set; }
    public string? AuthorName { get; set; }
    public string? AuthorCountry  { get; set; }
}