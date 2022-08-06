using System.ComponentModel.DataAnnotations;

namespace FileManager.Api.Models{
    
    public class UserModel{
        [Key]
        public string? Username { get; set; }

        public List<RepositoryModel> Repositories { get; set; } = new List<RepositoryModel>();
    }
}