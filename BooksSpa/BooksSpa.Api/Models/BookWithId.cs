using System.ComponentModel.DataAnnotations.Schema;
using BooksSpa.Api.Data;

namespace BooksSpa.Api.Models;

public class BookWithId: Book
{
    public int Id { get; set; }
    
    public BookWithId() {}

    public BookWithId(BookEntity book)
    {
        Id = book.Id;
        Title = book.Title;
        Author = book.Author;
        Isbn = book.Isbn;
        PublishedDate = book.PublishedDate;
    }
    
    public BookWithId(Book book)
    {
        Title = book.Title;
        Author = book.Author;
        Isbn = book.Isbn;
        PublishedDate = book.PublishedDate;
    }
}