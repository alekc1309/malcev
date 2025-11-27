using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [NotMapped]
    public class DocumentShort
    {
        [Key]
        [Column("Код")]
        public int Id { get; set; }

        [Column("Код_Документа")]
        public int DocumentCode { get; set; }
    }
}
