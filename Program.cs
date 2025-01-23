using Microsoft.EntityFrameworkCore;
using VideoRentalShopAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VideoShopContext>
(opt => opt.UseInMemoryDatabase("VideoDb"));

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
