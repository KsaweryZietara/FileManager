namespace FileManager.FileManagerApi.GraphQL.Users{

    public class UserAddedInputType : ObjectType<UserAddedInput>{
        protected override void Configure(IObjectTypeDescriptor<UserAddedInput> descriptor){
            descriptor
                .Name("UserAdded")
                .Description("Represents the input to add for a user.");
                

            descriptor
                .Field(f => f.username)
                .Description("Represents the name of the user.");
        }
    }
}