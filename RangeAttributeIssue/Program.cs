using System.ComponentModel.DataAnnotations;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidation();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

//app.UseExceptionHandler();
app.UseStatusCodePages();

app.MapOpenApi();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", app.Environment.ApplicationName);
});

app.MapPost("/api/range", (Input input, [Range(42.1, 89.8)] double value) =>
{
    return TypedResults.Ok();
});

app.Run();

public record Input 
{
    [Required]
    [Range(1234.56, 7891.1)]
    public int Value { get; set; }    
}