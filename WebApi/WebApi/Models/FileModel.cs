using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class FileModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public DateTime UploadDate { get; set; }


    }
}
