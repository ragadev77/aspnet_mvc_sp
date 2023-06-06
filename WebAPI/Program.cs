using WebAPI.Models;
using WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/** add repositores **/
builder.Services.AddScoped<IProdukRepository, ProdukRepository>();
///** add db connection  **/
builder.Services.AddDbContext<APIDbContext>(o => 
    o.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlServer")));
//services.AddControllers();
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
