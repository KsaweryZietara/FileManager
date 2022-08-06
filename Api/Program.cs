using FileManager.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(opt => 
opt.UseSqlServer(configuration["ConnectionStrings:SqlConnection"]));



var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();



app.Run();
