using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("АбитДисциплины", Schema = "dbo")]
    public class Discipline
    {
        [Key]
        [Column("Код")]
        public int Code { get; set; }

        [Column("Дисциплина")]
        [MaxLength(250)] 
        public string? Name { get; set; }
    }
}
