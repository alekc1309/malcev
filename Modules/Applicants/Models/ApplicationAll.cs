using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("Все_Заявления", Schema = "dbo")]
    public class AllApplications
    {
        [Key]
        [Column("Код_Заявления")]
        public int ApplicationCode { get; set; }

        [Column("Затраты")]
        public string? Costs { get; set; }

        [Column("Сумма")]
        public string? Sum { get; set; }

        [Column("Номер_договора")]
        public string? ContractNumber { get; set; }

        [Column("СрокОт")]
        public DateTime? PeriodFrom { get; set; }

        [Column("СрокДо")]
        public DateTime? PeriodTo { get; set; }

        [Column("ПериодОплаты")]
        public string? PaymentPeriod { get; set; }

        [Column("НомерКвитанции")]
        public string? ReceiptNumber { get; set; }

        [Column("ДатаОплаты")]
        public DateTime? PayDate { get; set; }

        [Column("ТипПлательщика")]
        public string? PayerType { get; set; }

        [Column("ДатаЗаключения")]
        public DateTime? ContractDate { get; set; }

        [Column("КодОплаты")]
        public int? PaymentCode { get; set; }

        [Column("СогласенНаЗачисление")]
        public bool? Consented { get; set; }

        [Column("СогласенДата")]
        public DateTime? ConsentDate { get; set; }

        [Column("КодОператора")]
        public int? OperatorCode { get; set; }

        // ====== ДОБАВЛЕНЫ ПОЛЯ ИЗ БОЛЬШОГО SQL ======

        // Направление согласен (ОКСО из Абит_Заявления с СогласенНаЗачисление = 1)
        [Column("Направление_Согласен")]
        public string? ConsentedDirection { get; set; }

        // СогласиеДатаЗагрузки (минимальная дата загрузки файла, строкой)
        [Column("СогласиеДатаЗагрузки")]
        public string? ConsentUploadDate { get; set; }

        // Количество файлов "Согласие на зачисление"
        [Column("СогласиеФайлов")]
        public int? ConsentFilesCount { get; set; }

        // Зеленая волна — дата первой загрузки
        [Column("ЗеленаяВолна")]
        public string? GreenWaveDate { get; set; }

        // Зеленая волна — количество файлов
        [Column("ЗеленаяВолнаФайлов")]
        public int? GreenWaveFilesCount { get; set; }

        // Снижение — дата первой загрузки
        [Column("Снижение")]
        public string? ReductionDate { get; set; }

        // Снижение — количество файлов
        [Column("СнижениеФайлов")]
        public int? ReductionFilesCount { get; set; }
    }
}
