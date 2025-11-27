namespace Project.Api.Modules.Applicants.Models.Dto
{
    public class ApplicationShortDto
    {
        public int ApplicationCode { get; set; }
        public string? ContractNumber { get; set; }
        public int? PaymentCode { get; set; }
        public int? PayerType { get; set; }
        public DateTime? ContractDate { get; set; }
        public string? Costs { get; set; }
        public string? Amount { get; set; }
    }
}