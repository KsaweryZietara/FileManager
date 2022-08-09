namespace FileManager.FileManagerApi.GraphQL.Users{

    public class UserAddedPayloadType : ObjectType<UserAddedPayload>{
        protected override void Configure(IObjectTypeDescriptor<UserAddedPayload> descriptor){
            descriptor.Description("Represents the payload to return for an added user.");

            descriptor
                .Field(f => f.user)
                .Description("Represents the added user.");
        }
    }
}