using Project.Api.Modules.Applicants.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Api.Modules.Applicants.Models
{
    [Table("FilesContent", Schema = "dbo")]
    public class FileContent
    {
        [Key]
        [Column("FileId")]
        public int FileId { get; set; }

        [Column("fileContent")]
        public byte[] Content { get; set; } = default!;
    }
}
