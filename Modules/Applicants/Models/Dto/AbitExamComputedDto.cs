namespace Project.Api.Modules.Applicants.Models.Dto
{
    public class AbitExamComputedDto
    {
        public int? ApplicationCode { get; set; }

        public double Score1 { get; set; }
        public double Score2 { get; set; }
        public double Score3 { get; set; }
        public double Score4 { get; set; }
        public double Score5 { get; set; }
        public double Score6 { get; set; }

        public double AdditionalScoreId { get; set; }
        public double ScoreSum { get; set; }
        public double Total { get; set; }
        public int Count { get; set; }
        public bool NoExamType { get; set; }

        public string? Exam1 { get; set; }
        public string? Exam2 { get; set; }
        public string? Exam3 { get; set; }
        public string? Exam4 { get; set; }
        public string? Exam5 { get; set; }
        public string? Exam6 { get; set; }

        public string? Disc1 { get; set; }
        public string? Disc2 { get; set; }
        public string? Disc3 { get; set; }
        public string? Disc4 { get; set; }
        public string? Disc5 { get; set; }
        public string? Disc6 { get; set; }

        public double TotalWithBonus => ScoreSum + AdditionalScoreId;
        public bool HasAnyScores => Count > 0;
    }
}