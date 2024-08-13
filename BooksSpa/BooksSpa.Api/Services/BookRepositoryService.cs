using BooksSpa.Api.Data;
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
        var entity = new BookEntity(book);
        await _database.Books.AddAsync(entity);
        await _database.SaveChangesAsync();
        return new BookWithId(entity);
    }

    public async Task<BookWithId?> UpdateBookAsync(BookWithId book)
    {
        var existingBook = await _database.Books.FindAsync(book.Id);
        if (existingBook == null) return null;
        
        existingBook.Apply(book);
        await _database.SaveChangesAsync();

        return new BookWithId(existingBook);
    }

    public async Task<BookWithId?> GetBookAsync(int bookId)
    {
        var existingBook = await _database.Books.FindAsync(bookId);
        return existingBook == null
            ? null
            : new BookWithId(existingBook);
    }

    public async Task<IEnumerable<BookWithId>> GetAllBooksAsync()
    {
        var allBooks = await _database.Books.ToListAsync();
        return allBooks.Select(e => new BookWithId(e));
    }

    public async Task<bool> DeleteBookAsync(int bookId)
    {
        var existingBook = await _database.Books.FindAsync(bookId);
        if (existingBook == null) return false;

        _database.Books.Remove(existingBook);
        await _database.SaveChangesAsync();
        return true;
    }
}