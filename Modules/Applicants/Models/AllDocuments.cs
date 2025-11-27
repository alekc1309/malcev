using Project.Api.Modules.Applicants.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Api.Modules.Applicants.Models
{
    [Table("Все_Документы", Schema = "dbo")]
    public class AllDocuments
    {
        [Key]
        [Column("Код")]
        public int Code { get; set; }

        [Column("ID")]
        public int AbitId { get; set; }

        [Column("Код_Документа")]
        public int DocumentCode { get; set; }

        [Column("Название")]
        public string? Name { get; set; }

        [Column("Баллы")]
        public int? Points { get; set; }

        [Column("СтатусДокумента")]
        public string? Status { get; set; }

        [Column("Серия_Документа")]
        public string? Series { get; set; }

        [Column("Номер_Документа")]
        public string? Number { get; set; }

        [Column("КодВерификатора")]
        public int? VerifierId { get; set; }

        [Column("ДатаИзменения")]
        public DateTime? ChangeDate { get; set; }

        [Column("Год")]
        public int? Year { get; set; }
    }
}
