using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("АбитДостижения", Schema = "dbo")]
    public class AbitAchievement
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Код")] 
        public int Code { get; set; }

        [Column("Название")]
        public string? Name { get; set; }

        [Column("Балл")]
        public double? MaxBall { get; set; }

        [Column("БаллИД")]
        public double? Counted { get; set; }

        [Column("СтатусДостижения")]
        public string? Status { get; set; }

        [Column("ИзменениеБалла")]
        public bool? BallChanged { get; set; }

        [Column("КодИД")]
        public int? IdCode { get; set; }

        [Column("КодВерификатора")]
        public int? VerifierCode { get; set; }

        [Column("ДатаИзменения")]
        public DateTime? ChangeDate { get; set; }

        [Column("Год")]
        public int? Year { get; set; }
    }
}
