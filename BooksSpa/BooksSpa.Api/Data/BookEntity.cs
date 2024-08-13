using System.ComponentModel.DataAnnotations.Schema;
using BooksSpa.Api.Models;

namespace BooksSpa.Api.Data;

public class BookEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Isbn { get; set; }
    public DateTimeOffset? PublishedDate { get; set; }
    
    public BookEntity() {}
    
    public BookEntity(Book dto)
    {
        Apply(dto);
    }
    
    public void Apply(Book book)
    {
        Title = book.Title;
        Author = book.Author;
        Isbn = book.Isbn;
        PublishedDate = book.PublishedDate;
    }
}