using Bogus;
using BooksSpa.Api.Controllers;
using BooksSpa.Api.Models;
using BooksSpa.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BooksSpa.Tests;

[TestFixture]
public class ControllerTests
{
    [Test]
    public async Task CreateBook_Returns201WithCorrectObject()
    {
        // Arrange
        var repo = new Mock<IBookRepositoryService>();
        var faker = new Faker();
        var dto = faker.NewBook();
        var mockResponse = new BookWithId(dto)
        {
            Id = faker.Random.Int(min: 1)
        };
        repo.Setup(r => r.CreateBookAsync(dto))
            .ReturnsAsync(mockResponse);
        var logger = new Mock<ILogger<BooksApiController>>();
        var controller = new BooksApiController(repo.Object,
            logger.Object);

        // Act
        var response = await controller.CreateBook(dto);
        var result = response.Result as CreatedResult;
        
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Value, Is.EqualTo(mockResponse));
    }

    [Test]
    public async Task CreateBook_ExceptionReturns500WithCorrectObject()
    {
        // Arrange
        var repo = new Mock<IBookRepositoryService>();
        var faker = new Faker();
        var exception = new Exception(faker.Lorem.Sentence());
        repo.Setup(r => r.CreateBookAsync(It.IsAny<Book>()))
            .ThrowsAsync(exception);
        var logger = new Mock<ILogger<BooksApiController>>();
        var controller = new BooksApiController(repo.Object,
            logger.Object);
        
        // Act
        var response = await controller.CreateBook(new Book());
        var result = response.Result as ObjectResult;
        var errorResponse = result?.Value as ErrorResponse;
        
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.StatusCode, Is.EqualTo(500));
        Assert.That(errorResponse, Is.Not.Null);
    }
    
    [Test]
    public async Task GetSpecificBook_ReturnsSpecifiedBook()
    {
        // Arrange
        var repo = new Mock<IBookRepositoryService>();
        var faker = new Faker();
        
        var book1 = faker.NewBookWithId();
        book1.Id = 1;
        var book2 = faker.NewBookWithId();
        book1.Id = 2;
        repo.Setup(r => r.GetBookAsync(1))
            .ReturnsAsync(book1);
        repo.Setup(r => r.GetBookAsync(2))
            .ReturnsAsync(book2);
        
        var logger = new Mock<ILogger<BooksApiController>>();
        var controller = new BooksApiController(repo.Object,
            logger.Object);

        // Act
        var book1Response = await controller.GetSpecificBook(1);
        var book1Result = book1Response.Result as OkObjectResult;
        var book2Response = await controller.GetSpecificBook(2);
        var book2Result = book2Response.Result as OkObjectResult;
        
        // Assert
        Assert.That(book1Result, Is.Not.Null);
        Assert.That(book2Result, Is.Not.Null);
        Assert.That(book1Result.Value, Is.EqualTo(book1));
        Assert.That(book2Result.Value, Is.EqualTo(book2));
    }

    [Test]
    public async Task GetSpecificBook_NonExistenceReturnsNotFound()
    {
        // Arrange
        var repo = new Mock<IBookRepositoryService>();
        var faker = new Faker();
        repo.Setup(r => r.GetBookAsync(It.IsAny<int>()))
            .ReturnsAsync((BookWithId?)null);
        var logger = new Mock<ILogger<BooksApiController>>();
        var controller = new BooksApiController(repo.Object,
            logger.Object);
        
        // Act
        var response = await controller.GetSpecificBook(faker.Random.Int(min: 0));
        var result = response.Result as NotFoundResult;
        
        // Assert
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public async Task GetSpecificBook_ExceptionReturns500WithCorrectBook()
    {
        throw new NotImplementedException();
    }
    
    [Test]
    public async Task UpdateBook_ReturnsSameAsRepo()
    {
        throw new NotImplementedException();
    }
    
    [Test]
    public async Task UpdateBook_NonExistenceReturns404()
    {
        throw new NotImplementedException();
    }
    
    [Test]
    public async Task UpdateBook_ExceptionReturns500W()
    {
        throw new NotImplementedException();
    }
    
    [Test]
    public async Task DeleteBook_ReturnsSameAsRepo()
    {
        throw new NotImplementedException();
    }
    
    [Test]
    public async Task DeleteBook_NonExistenceReturns404()
    {
        throw new NotImplementedException();
    }
    
    [Test]
    public async Task DeleteBook_ExceptionReturns500()
    {
        throw new NotImplementedException();
    }
    
    [Test]
    public async Task GetAll_ReturnsSameAsRepo()
    {
        throw new NotImplementedException();
    }
    
    [Test]
    public async Task GetAll_ExceptionReturns500()
    {
        throw new NotImplementedException();
    }
}