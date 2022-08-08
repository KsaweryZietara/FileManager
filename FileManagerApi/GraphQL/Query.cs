using FileManager.FileManagerApi.Data;
using FileManager.FileManagerApi.Models;

namespace FileManager.FileManagerApi.GraphQL{
    public class Query{
        public IQueryable<UserModel> GetUsers([Service] AppDbContext context){
            return context.Users.AsQueryable();
        }
    }
}