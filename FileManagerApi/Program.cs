using FileManager.FileManagerApi.Data;
using FileManager.FileManagerApi.GraphQL.Files;
using FileManager.FileManagerApi.GraphQL.Folders;
using FileManager.FileManagerApi.GraphQL.Mutations;
using FileManager.FileManagerApi.GraphQL.Queries;
using FileManager.FileManagerApi.GraphQL.Repositories;
using FileManager.FileManagerApi.GraphQL.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(opt => 
opt.UseSqlServer(configuration["ConnectionStrings:SqlConnection"]));

builder.Services
    .AddGraphQLServer()
    .AddType<FileType>()
    .AddType<FileAddedInputType>()
    .AddType<FileAddedPayloadType>()
    .AddType<FolderType>()
    .AddType<FolderAddedInputType>()
    .AddType<FolderAddedPayloadType>()
    .AddType<RepositoryType>()
    .AddType<RepositoryAddedInputType>()
    .AddType<RepositoryAddedPayloadType>()
    .AddType<UserType>()
    .AddType<UserAddedInputType>()
    .AddType<UserAddedPayloadType>()
    .AddQueryType<QueryType>()
    .AddMutationType<MutationType>()
    .AddProjections();

var app = builder.Build();

app.MapGraphQL();

app.Run();
