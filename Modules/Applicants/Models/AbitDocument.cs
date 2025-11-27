using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("Абит_Документы", Schema = "dbo")]
    public class AbitDocument
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Код_Документа")]
        public int? DocumentCode { get; set; }

        [Column("Дисциплина")]
        public string? Discipline { get; set; }

        [Column("Баллы")]
        public string? Score { get; set; }

        [Column("СтатусДок")]
        public string? Status { get; set; }
    }
}
