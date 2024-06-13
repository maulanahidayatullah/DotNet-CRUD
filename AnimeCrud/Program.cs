using Microsoft.EntityFrameworkCore;
using AnimeCrud.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("test"));

builder.Services.AddDbContext<ApiContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("AnimeConnectionString")));

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
