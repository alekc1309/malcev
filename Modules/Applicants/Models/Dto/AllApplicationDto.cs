namespace Project.Api.Modules.Applicants.Models.Dto
{
    public class AllApplicationDto
    {
        public int ApplicationCode { get; set; }
        public string? Costs { get; set; }
        public string? Sum { get; set; }
        public string? ContractNumber { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public string? PaymentPeriod { get; set; }
        public string? ReceiptNumber { get; set; }
        public DateTime? PayDate { get; set; }
        public string? PayerType { get; set; }
        public DateTime? ContractDate { get; set; }
        public int? PaymentCode { get; set; }
        public bool? Consented { get; set; }
        public DateTime? ConsentDate { get; set; }
        public int? OperatorCode { get; set; }

        // Новые поля
        public string? ConsentedDirection { get; set; }
        public string? ConsentUploadDate { get; set; }
        public int? ConsentFilesCount { get; set; }
        public string? GreenWaveDate { get; set; }
        public int? GreenWaveFilesCount { get; set; }
        public string? ReductionDate { get; set; }
        public int? ReductionFilesCount { get; set; }
    }
}
