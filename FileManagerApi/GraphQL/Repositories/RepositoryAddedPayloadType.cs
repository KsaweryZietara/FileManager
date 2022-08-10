namespace FileManager.FileManagerApi.GraphQL.Repositories{

    public class RepositoryAddedPayloadType : ObjectType<RepositoryAddedPayload>{
        protected override void Configure(IObjectTypeDescriptor<RepositoryAddedPayload> descriptor){
            descriptor.Description("Represents the payload to return for an added repository.");

            descriptor
                .Field(f => f.repository)
                .Description("Represents the added user.");
        }
    }
}