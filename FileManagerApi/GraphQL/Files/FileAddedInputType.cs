namespace FileManager.FileManagerApi.GraphQL.Files{
    public class FileAddedInputType : ObjectType<FileAddedInput>{
        protected override void Configure(IObjectTypeDescriptor<FileAddedInput> descriptor){
            descriptor
                .Name("FileAdded")
                .Description("Represents the input to add for a file.");

            descriptor
                .Field(f => f.path)
                .Description("Represents the path of the file.");

            descriptor
                .Field(f => f.name)
                .Description("Represents the name of the file.");

            descriptor
                .Field(f => f.content)
                .Description("Represents the content of the file.");
        }
    }
}