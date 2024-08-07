namespace BooksSpa.Api.Models;

public class Book
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Isbn { get; set; }
    public DateTimeOffset? PublishedDate { get; set; }
}