using WebScrapingAEC.Application.Service;
using WebScrapingAEC.Domain.Interfaces.Scraping;
using WebScrapingAEC.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Registra a implementação de IScrapingService
builder.Services.AddTransient<IScrapingService, ScrapingService>();

// Configura a injeção de dependência do objeto "_scrapingService" na classe "WordSearchService"
builder.Services.AddTransient<IWordSearchService, WordSearchService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
