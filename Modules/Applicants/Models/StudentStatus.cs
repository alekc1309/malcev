using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("Статус_Студента", Schema = "dbo")]
    public class StudentStatus
    {
        [Key]
        [Column("Код")]
        public int Code { get; set; }

        [Column("Статус")]
        public string? Status { get; set; }

        [Column("Описание")]
        public string? Description { get; set; }

        [Column("Сокращ")]
        public string? ShortName { get; set; }
    }
}