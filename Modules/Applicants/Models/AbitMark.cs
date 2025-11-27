using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("Абит_Оценки", Schema = "dbo")]
    public class AbitMark
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Код_Испытания")]
        public int? ExamCode { get; set; }

        [Column("Оценка")]
        public double? Score { get; set; }

        [Column("Дата_Экзамена")]
        public DateTime? ExamDate { get; set; }
    }
}
