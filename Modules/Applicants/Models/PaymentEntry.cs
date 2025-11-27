using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("СправочникОплата", Schema = "dbo")]
    public class PaymentEntry
    {
        [Key]
        [Column("КодОплаты")]
        public int Code { get; set; }

        [Column("Оплата")]
        public string? PaymentName { get; set; } // varchar(250), Не NULL

        [Column("Дата")]
        public bool? IsDate { get; set; } // bit, NULL

        [Column("Период")]
        public int? Period { get; set; } // int, NULL

        [Column("КодФормы")]
        public int? FormCode { get; set; } // int, NULL

        [Column("Удалена")]
        public bool IsDeleted { get; set; } // bit, Не NULL
    }
}
