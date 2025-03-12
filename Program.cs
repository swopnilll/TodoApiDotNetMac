using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Enable API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true; // Shows API versions in response headers
    options.AssumeDefaultVersionWhenUnspecified = true; // Uses default version if none is specified
    options.DefaultApiVersion = new ApiVersion(1, 0); // Sets v1.0 as the default
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} else {
    app.UseHttpsRedirection();
}


app.MapControllers();

app.Run();

