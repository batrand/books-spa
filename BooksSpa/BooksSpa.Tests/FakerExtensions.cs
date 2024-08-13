using Bogus;
using BooksSpa.Api.Data;
using BooksSpa.Api.Models;

namespace BooksSpa.Tests;

public static class FakerExtensions
{
    public static Book NewBook(this Faker faker)
        => new()
        {
            Author = faker.Name.FullName(),
            Title = faker.Lorem.Sentence(),
            Isbn = faker.Random.String(13),
            PublishedDate = faker.Date.PastOffset()
        };
    
    public static BookWithId NewBookWithId(this Faker faker)
        => new()
        {
            Id = faker.Random.Int(min: 1),
            Author = faker.Name.FullName(),
            Title = faker.Lorem.Sentence(),
            Isbn = faker.Random.String(13),
            PublishedDate = faker.Date.PastOffset()
        };
    
    public static BookEntity NewBookEntity(this Faker faker)
        => new()
        {
            Id = faker.Random.Int(min: 1),
            Author = faker.Name.FullName(),
            Title = faker.Lorem.Sentence(),
            Isbn = faker.Random.String(13),
            PublishedDate = faker.Date.PastOffset()
        };
}