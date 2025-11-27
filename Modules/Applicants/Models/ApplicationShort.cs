using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [NotMapped]
    public class ApplicationShort
    {
        [Key]
        [Column("Код_Заявления")]
        public int ApplicationCode { get; set; }

        [Column("Номер_договора")]
        public string? ContractNumber { get; set; }

        [Column("КодОплаты")]
        public int? PaymentCode { get; set; }

        [Column("ТипПлательщика")]
        public int? PayerType { get; set; }

        [Column("ДатаЗаключения")]
        public DateTime? ContractDate { get; set; }

        [Column("Затраты")]
        public string? Costs { get; set; }

        [Column("Сумма")]
        public string? Amount { get; set; }
    }
}
