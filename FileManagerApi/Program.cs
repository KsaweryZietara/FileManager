using FileManager.FileManagerApi.Data;
using FileManager.FileManagerApi.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(opt => 
opt.UseSqlServer(configuration["ConnectionStrings:SqlConnection"]));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
