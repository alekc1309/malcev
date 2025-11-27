namespace Project.Api.Modules.Applicants.Models
{
    public class ApplicantsChartPointDto
    {
        public DateTime Date { get; set; }
        public int Cumulative { get; set; }
    }

    public class ApplicantsChartSeriesDto
    {
        public int Year { get; set; }
        public List<ApplicantsChartPointDto> Points { get; set; } = new();
    }
}