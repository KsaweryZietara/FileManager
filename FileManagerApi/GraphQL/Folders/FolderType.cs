using FileManager.FileManagerApi.GraphQL.Files;
using FileManager.FileManagerApi.Models;

namespace FileManager.FileManagerApi.GraphQL.Folders{

    public class FolderType : ObjectType<FolderModel>{
        protected override void Configure(IObjectTypeDescriptor<FolderModel> descriptor){
            descriptor.Description("Folder");

            descriptor
                .Field(f => f.Path)
                .Description("Path of the folder")
                .Type<StringType>();

            descriptor
                .Field(f => f.Name)
                .Description("Name of the folder")
                .Type<StringType>();

            descriptor
                .Field(f => f.Folders)
                .Description("Folders in folder")
                .Type<ListType<FolderType>>();

            descriptor
                .Field(f => f.Files)
                .Description("Files in folder")
                .Type<ListType<FileType>>();
        }
    }
}