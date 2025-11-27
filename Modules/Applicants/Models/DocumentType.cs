using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("Вид_Документа", Schema = "dbo")]
    public class DocumentType
    {
        [Key]
        [Column("Код_Документа")]
        public int Code { get; set; }

        [Column("Название")]
        public string? Name { get; set; }

        [Column("Комментарий")]
        public string? Comment { get; set; }

        [Column("Сокращение")]
        public string? ShortName { get; set; }

        [Column("Документ")]
        public bool? IsDocument { get; set; }
    }
}
