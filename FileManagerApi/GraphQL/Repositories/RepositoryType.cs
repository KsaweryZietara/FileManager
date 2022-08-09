using FileManager.FileManagerApi.GraphQL.Files;
using FileManager.FileManagerApi.GraphQL.Folders;
using FileManager.FileManagerApi.Models;

namespace FileManager.FileManagerApi.GraphQL.Repositories{

    public class RepositoryType : ObjectType<RepositoryModel>{
        protected override void Configure(IObjectTypeDescriptor<RepositoryModel> descriptor){
            descriptor.Description("Repository");

            descriptor
                .Field(f => f.Path)
                .Description("Path of the repository")
                .Type<StringType>();

            descriptor
                .Field(f => f.Name)
                .Description("Name of the repository")
                .Type<StringType>();

            descriptor
                .Field(f => f.Folders)
                .Description("Folders in repository")
                .Type<ListType<FolderType>>();

            descriptor
                .Field(f => f.Files)
                .Description("Files in repository")
                .Type<ListType<FileType>>();
        }
    }
}