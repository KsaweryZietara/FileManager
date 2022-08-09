using FileManager.FileManagerApi.Data;
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
    }
}