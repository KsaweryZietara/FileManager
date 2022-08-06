using System.ComponentModel.DataAnnotations;

namespace FileManager.Api.Models{

    public class FolderModel{
        public string? Location { get; set; }

        public string? Name { get; set; }

        public List<FolderModel> Folders { get; set; } = new List<FolderModel>();

        public List<FileModel> Files { get; set; } = new List<FileModel>();
    }
}