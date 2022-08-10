namespace FileManager.FileManagerApi.GraphQL.Repositories{

    public class RepositoryAddedInputType : ObjectType<RepositoryAddedInput>{
        protected override void Configure(IObjectTypeDescriptor<RepositoryAddedInput> descriptor){
            descriptor
                .Name("RepositoryAdded")
                .Description("Represents the input to add for a repository.");

            descriptor
                .Field(f => f.path)
                .Description("Represents the path of the repository.");

            descriptor
                .Field(f => f.name)
                .Description("Represents the name of the repository.");
        }
    }
}