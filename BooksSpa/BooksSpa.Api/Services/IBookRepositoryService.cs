using BooksSpa.Api.Models;

namespace BooksSpa.Api.Services;

public interface IBookRepositoryService
{
    Task<BookWithId> CreateBookAsync(Book book);
    Task<BookWithId?> UpdateBookAsync(BookWithId book);
    Task<BookWithId?> GetBookAsync(int bookId);
    Task<IEnumerable<BookWithId>> GetAllBooksAsync();
    /// <summary>
    /// Delete a book
    /// </summary>
    /// <param name="bookId"></param>
    /// <returns>True if deleted, false if not found</returns>
    Task<bool> DeleteBookAsync(int bookId);
}