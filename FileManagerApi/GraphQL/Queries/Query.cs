using FileManager.FileManagerApi.Data;
using FileManager.FileManagerApi.Models;

namespace FileManager.FileManagerApi.GraphQL.Queries{
    public class Query{
        public IQueryable<UserModel> GetUsers([Service(ServiceKind.Synchronized)] AppDbContext context){
            return context.Users.AsQueryable();
        }
    }
}