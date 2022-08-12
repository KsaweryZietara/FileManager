namespace FileManager.FileManagerApi.GraphQL.Folders{
    public class FolderAddedPayloadType : ObjectType<FolderAddedPayload>{
        protected override void Configure(IObjectTypeDescriptor<FolderAddedPayload> descriptor){
            descriptor.Description("Represents the payload to return for an added folder.");

            descriptor
                .Field(f => f.folder)
                .Description("Represents the added folder.");
        }
    }
}