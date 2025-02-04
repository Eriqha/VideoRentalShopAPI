using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VideoShopRentalAPIv3.Data; // Correctly referencing the namespace

var builder = WebApplication.CreateBuilder(args);

// ? Retrieve connection string
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ? Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connection)
);

// ? Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()); // Fixed duplicate AllowAnyMethod()
});

var app = builder.Build();

// ? Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll"); // Apply the correct CORS policy
app.UseAuthorization();
app.MapControllers();

app.Run();
