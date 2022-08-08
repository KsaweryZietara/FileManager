using System.ComponentModel.DataAnnotations;

namespace FileManager.FileManagerApi.Models{
    public class FileModel{
        [Required]
        public string Path { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
    }
}