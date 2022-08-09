using FileManager.FileManagerApi.GraphQL.Users;

namespace FileManager.FileManagerApi.GraphQL.Mutations{

    public class MutationType : ObjectType<Mutation>{
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor){
            descriptor
                .Field(f => f.AddUserAsync(default!, default!))
                .Type<UserAddedPayloadType>();
        }
    }
}