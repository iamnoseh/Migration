namespace Domain;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int AuthorId { get; set; }
    public DateTime PublishedYear { get; set; }
    public string? Genre { get; set; }
    public string IsAvailable { get; set; }
}



