namespace Project.Api.Modules.Applicants.Models.Dto
{
    public class StudentStatusDto
    {
        public int Code { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public string? ShortName { get; set; }
    }
}