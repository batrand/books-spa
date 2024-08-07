using BooksSpa.Api.Models;

namespace BooksSpa.Api.Services;

public interface IBookRepositoryService
{
    Task<BookWithId> CreateBookAsync(Book book);
    Task<BookWithId> UpdateBookAsync(BookWithId book);
    Task<BookWithId> GetBookAsync(int bookId);
    Task<IEnumerable<BookWithId>> GetAllBooksAsync();
    Task DeleteBookAsync(int bookId);
}