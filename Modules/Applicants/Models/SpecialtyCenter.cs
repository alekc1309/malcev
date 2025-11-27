using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("СпециальностиЦО", Schema = "dbo")]
    public class SpecialtyCenter
    {
        [Key]
        [Column("Код")]
        public int Id { get; set; }

        [Column("Код_Специальности")]
        public int SpecialtyCode { get; set; }

        [Column("Код_Организации")]
        public int OrgCode { get; set; }

        [Column("НомерПредложенияРвР")]
        public int? ProposalNumber { get; set; }
    }
}
