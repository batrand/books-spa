using BooksSpa.Api.Options;
using BooksSpa.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// ASP.NET Core Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

// Options
builder.Services.Configure<AppDbOptions>(builder.Configuration.GetSection(AppDbOptions.Key));

// Services
builder.Services.AddTransient<IBookRepositoryService, BookRepositoryService>();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();