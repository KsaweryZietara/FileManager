using System.ComponentModel.DataAnnotations;

namespace FileManager.Api.Models{

    public class FileModel{
        public string? Location { get; set; }

        public string? Name { get; set; }

        public string? Content { get; set; }
    }
}