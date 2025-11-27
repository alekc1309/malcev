using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("Роли", Schema = "dbo")]
    public class RoleInfo
    {
        [Key]
        [Column("Код")]
        public int Code { get; set; }

        [Column("Имя")]
        public string? Name { get; set; }

        [Column("Программа")]
        public string? Program { get; set; }

        [Column("Объект")]
        public string? Object { get; set; }

        [Column("Столбец")]
        public string? Column { get; set; }
    }
}
