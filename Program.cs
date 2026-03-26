using CoreBackend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//tambah service controller
builder.Services.AddControllers();

//use openAPI instead of swagger
builder.Services.AddOpenApi();

//get connection from user secret
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

//register dbcontext 4 posgresql
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();