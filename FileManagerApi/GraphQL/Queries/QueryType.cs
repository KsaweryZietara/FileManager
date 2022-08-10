using FileManager.FileManagerApi.GraphQL.Users;

namespace FileManager.FileManagerApi.GraphQL.Queries{

    public class QueryType : ObjectType<Query>{
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor){
            descriptor
                .Field(f => f.GetUsers(default!)).UseProjection()
                .Type<ListType<UserType>>();
        }
    }
}