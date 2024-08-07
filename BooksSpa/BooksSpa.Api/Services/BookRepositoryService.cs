using BooksSpa.Api.Models;

namespace BooksSpa.Api.Services;

public class BookRepositoryService : IBookRepositoryService
{
    public async Task<BookWithId> CreateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public async Task<BookWithId> UpdateBookAsync(BookWithId book)
    {
        throw new NotImplementedException();
    }

    public async Task<BookWithId> GetBookAsync(int bookId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BookWithId>> GetAllBooksAsync()
    {
        throw new NotImplementedException();
    }

    public async Task DeleteBookAsync(int bookId)
    {
        throw new NotImplementedException();
    }
}