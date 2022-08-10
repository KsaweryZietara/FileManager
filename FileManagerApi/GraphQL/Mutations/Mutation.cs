using FileManager.FileManagerApi.Data;
using FileManager.FileManagerApi.GraphQL.Repositories;
using FileManager.FileManagerApi.GraphQL.Users;
using FileManager.FileManagerApi.Models;

namespace FileManager.FileManagerApi.GraphQL.Mutations{

    public class Mutation{
        public async Task<UserAddedPayload> AddUserAsync(
            [Service(ServiceKind.Synchronized)] AppDbContext context,
            UserAddedInput input){
                var user = new UserModel{
                    Username = input.username
                };

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return new UserAddedPayload(user);
        }

        public async Task<RepositoryAddedPayload> AddRepositoryAsync(
            [Service(ServiceKind.Synchronized)] AppDbContext context,
            RepositoryAddedInput input){
                var repo = new RepositoryModel{
                    Path = input.path,
                    Name = input.name
                };

                context.Users.FirstOrDefault(x => x.Username == input.path).Repositories.Add(repo);
                await context.SaveChangesAsync();

                return new RepositoryAddedPayload(repo);
        }
    }
}