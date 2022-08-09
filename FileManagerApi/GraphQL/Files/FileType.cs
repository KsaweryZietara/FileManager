using FileManager.FileManagerApi.Models;

namespace FileManager.FileManagerApi.GraphQL.Files{

    public class FileType : ObjectType<FileModel>{
        protected override void Configure(IObjectTypeDescriptor<FileModel> descriptor){
            descriptor.Description("File");

            descriptor
                .Field(f => f.Path)
                .Description("Path of the file")
                .Type<StringType>();

            descriptor
                .Field(f => f.Name)
                .Description("Name of the file")
                .Type<StringType>();

            descriptor
                .Field(f => f.Content)
                .Description("Content of the file")
                .Type<StringType>();
        }
    }
}