using BooksSpa.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksSpa.Api.Services;

public class BookRepositoryService : IBookRepositoryService
{
    private readonly AppDbContext _database;
    public BookRepositoryService(AppDbContext database)
    {
        _database = database;
    }

    public async Task<BookWithId> CreateBookAsync(Book book)
    {
        var bookWithId = new BookWithId(book);
        await _database.Books.AddAsync(bookWithId);
        await _database.SaveChangesAsync();
        return bookWithId;
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
        var allBooks = await _database.Books.ToListAsync();
        return allBooks;
    }

    public async Task DeleteBookAsync(int bookId)
    {
        throw new NotImplementedException();
    }
}