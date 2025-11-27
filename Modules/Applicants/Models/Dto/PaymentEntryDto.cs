// Project.Api\Modules\Applicants\Models\Dto\PaymentEntryDto.cs
namespace Project.Api.Modules.Applicants.Models.Dto
{
    public class PaymentEntryDto
    {
        public int Code { get; set; }
        public string? PaymentName { get; set; }
        public bool? IsDate { get; set; }
        public int? Period { get; set; }
        public int? FormCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}