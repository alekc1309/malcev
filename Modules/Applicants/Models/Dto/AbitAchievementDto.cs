namespace Project.Api.Modules.Applicants.Models.Dto
{
    public class AbitAchievementDto
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? Name { get; set; }
        public double? MaxBall { get; set; }
        public double? Counted { get; set; }
        public string? Status { get; set; }
        public bool? BallChanged { get; set; }
        public int? IdCode { get; set; }
        public int? VerifierCode { get; set; }
        public DateTime? ChangeDate { get; set; }
        public int? Year { get; set; }
    }
}