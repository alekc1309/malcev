using Project.Api.Modules.Applicants.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("Абит_Заявления", Schema = "dbo")]
    public class ApplicantApplications
    {
        [Key]
        [Column("Код_Заявления")]
        public int ApplicationCode { get; set; }

        [Column("ID")]
        public int AbitId { get; set; }

        [Column("Удалена")]
        public bool? Deleted { get; set; }

        [Column("ЗабралДок")]
        public bool? TookDocs { get; set; }

        [Column("СогласенНаЗачисление")]
        public bool? ConsentToEnrollment { get; set; }

        [Column("Общежитие")]
        public string? Dormitory { get; set; }
    }
}
