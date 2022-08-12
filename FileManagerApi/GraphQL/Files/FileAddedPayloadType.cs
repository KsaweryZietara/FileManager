namespace FileManager.FileManagerApi.GraphQL.Files{
    public class FileAddedPayloadType : ObjectType<FileAddedPayload>{
        protected override void Configure(IObjectTypeDescriptor<FileAddedPayload> descriptor){
            descriptor.Description("Represents the payload to return for an added file.");

            descriptor
                .Field(f => f.file)
                .Description("Represents the added file.");
        }
    }
}