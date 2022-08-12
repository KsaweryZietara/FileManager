namespace FileManager.FileManagerApi.GraphQL.Folders{
    public class FolderAddedInputType : ObjectType<FolderAddedInput>{
        protected override void Configure(IObjectTypeDescriptor<FolderAddedInput> descriptor){
            descriptor
                .Name("FolderAdded")
                .Description("Represents the input to add for a folder.");

            descriptor
                .Field(f => f.path)
                .Description("Represents the path of the folder.");

            descriptor
                .Field(f => f.name)
                .Description("Represents the name of the folder.");
        }
    }
}