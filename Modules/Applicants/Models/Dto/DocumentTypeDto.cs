namespace Project.Api.Modules.Applicants.Models.Dto
{
    public class DocumentTypeDto
    {
        public int Code { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public string? ShortName { get; set; }
        public bool? IsDocument { get; set; }
    }
}
