using FileManager.FileManagerApi.GraphQL.Repositories;
using FileManager.FileManagerApi.Models;

namespace FileManager.FileManagerApi.GraphQL.Users{

    public class UserType : ObjectType<UserModel>{
        protected override void Configure(IObjectTypeDescriptor<UserModel> descriptor){
            descriptor.Description("User account");

            descriptor
                .Field(f => f.Username)
                .Description("Name of the user")
                .Type<StringType>();

            descriptor
                .Field(f => f.Repositories)
                .Description("User repositories")
                .Type<ListType<RepositoryType>>();
        }
    }
}