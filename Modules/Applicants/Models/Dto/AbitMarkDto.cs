namespace Project.Api.Modules.Applicants.Models.Dto
{
    public class AbitMarkDto
    {
        public int Id { get; set; }
        public int? ExamCode { get; set; }
        public double? Score { get; set; }
        public DateTime? ExamDate { get; set; }
    }
}