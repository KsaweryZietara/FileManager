using FileManager.FileManagerApi.GraphQL.Files;
using FileManager.FileManagerApi.GraphQL.Folders;
using FileManager.FileManagerApi.GraphQL.Repositories;
using FileManager.FileManagerApi.GraphQL.Users;

namespace FileManager.FileManagerApi.GraphQL.Mutations{

    public class MutationType : ObjectType<Mutation>{
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor){
            descriptor
                .Field(f => f.AddUserAsync(default!, default!))
                .Type<UserAddedPayloadType>();

            descriptor
                .Field(f => f.AddRepositoryAsync(default!, default!))
                .Type<RepositoryAddedPayloadType>();

            descriptor
                .Field(f => f.AddFolderAsync(default!, default!))
                .Type<FolderAddedPayloadType>();
            
            descriptor
                .Field(f => f.AddFileAsync(default!, default!))
                .Type<FileAddedPayloadType>();
        }
    }
}