using System.ComponentModel.DataAnnotations;

namespace FileManager.FileManagerApi.Models{
    public class UserModel{
        [Key]
        public string Username { get; set; } = string.Empty;

        public List<RepositoryModel> Repositories { get; set; } = new List<RepositoryModel>();
    }
}