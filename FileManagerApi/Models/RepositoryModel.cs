using System.ComponentModel.DataAnnotations;

namespace FileManager.FileManagerApi.Models{
    public class RepositoryModel{
        [Required]
        public string Path { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<FolderModel> Folders { get; set; } = new List<FolderModel>();

        public List<FileModel> Files { get; set; } = new List<FileModel>();
    }
}