using FileManager.FileManagerApi.Data;
using FileManager.FileManagerApi.GraphQL.Files;
using FileManager.FileManagerApi.GraphQL.Folders;
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

        public async Task<RepositoryAddedPayload?> AddRepositoryAsync(
            [Service(ServiceKind.Synchronized)] AppDbContext context,
            RepositoryAddedInput input){
                var repo = new RepositoryModel{
                    Path = input.path,
                    Name = input.name
                };

                // context.Users.FirstOrDefault(x => x.Username == input.path).Repositories.Add(repo);
                
                var user = context.Users.FirstOrDefault(x => x.Username == input.path);

                if(user == null){
                    return null;
                }

                user.Repositories.Add(repo);
                
                await context.SaveChangesAsync();

                return new RepositoryAddedPayload(repo);
        }

        public async Task<FolderAddedPayload?> AddFolderAsync(
            [Service(ServiceKind.Synchronized)] AppDbContext context,
            FolderAddedInput input){
                var folder = new FolderModel{
                    Path = input.path,
                    Name = input.name
                };

                List<string> pathArr = input.path.Split('\\').ToList();

                var user = context.Users.FirstOrDefault(x => x.Username == pathArr[0]);

                if(user == null){
                    return null;
                }

                var repo = user.Repositories.FirstOrDefault(x => x.Name == pathArr[1]);

                if(repo == null){
                    return null;
                }

                if(pathArr.Count == 2){
                    repo.Folders.Add(folder);
                    await context.SaveChangesAsync();
                    return new FolderAddedPayload(folder);
                }

                var destination = repo.Folders.FirstOrDefault(x => x.Name == pathArr[2]);

                if(destination == null){
                    return null;
                }

                for(int i = 3; i < pathArr.Count; i++){
                    destination = destination.Folders.FirstOrDefault(x => x.Name == pathArr[i]);
                    if(destination == null){
                        return null;
                    }
                }
                
                destination.Folders.Add(folder);
                await context.SaveChangesAsync();

                return new FolderAddedPayload(folder);
        }
        
        public async Task<FileAddedPayload?> AddFileAsync(
            [Service(ServiceKind.Synchronized)] AppDbContext context,
            FileAddedInput input){
                var file = new FileModel{
                    Path = input.path,
                    Name = input.name,
                    Content = input.content
                };

                List<string> pathArr = input.path.Split('\\').ToList();

                var user = context.Users.FirstOrDefault(x => x.Username == pathArr[0]);

                if(user == null){
                    return null;
                }

                var repo = user.Repositories.FirstOrDefault(x => x.Name == pathArr[1]);

                if(repo == null){
                    return null;
                }

                if(pathArr.Count == 2){
                    repo.Files.Add(file);
                    await context.SaveChangesAsync();
                    return new FileAddedPayload(file);
                }

                var destination = repo.Folders.FirstOrDefault(x => x.Name == pathArr[2]);

                if(destination == null){
                    return null;
                }

                for(int i = 3; i < pathArr.Count; i++){
                    destination = destination.Folders.FirstOrDefault(x => x.Name == pathArr[i]);
                    if(destination == null){
                        return null;
                    }
                }
                
                destination.Files.Add(file);
                await context.SaveChangesAsync();

                return new FileAddedPayload(file);
        }
        
    }
}