using System.ComponentModel.DataAnnotations.Schema;

namespace BooksSpa.Api.Models;

public class BookWithId: Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public BookWithId() {}

    public BookWithId(Book book)
    {
        Title = book.Title;
        Author = book.Author;
        Isbn = book.Isbn;
        PublishedDate = book.PublishedDate;
    }
}