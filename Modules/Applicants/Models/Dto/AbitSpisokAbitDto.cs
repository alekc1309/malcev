// Project.Api\Modules\Applicants\Models\Dto\AbitSpisokAbitDto.cs
using System;

namespace Project.Api.Modules.Applicants.Models.Dto
{
    public class AbitSpisokAbitDto
    {
        public int Id { get; set; }
        public int? ApplicationCode { get; set; }
        public string? FullName { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public int? SpecialtyCode { get; set; }
        public string? SpecialtyName { get; set; }
        public string? SpecialName { get; set; }
        public string? Specialization { get; set; }
        public string? Profile { get; set; }
        public string? Faculty { get; set; }
        public string? OKSO { get; set; }
        public int? Level { get; set; }
        public string? LevelName { get; set; }
        public int? LevelCategory { get; set; }
        public int? EducationForm { get; set; }
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public bool? Dormitory { get; set; }
        public string? EducationType { get; set; }
        public string? School { get; set; }
        public string? SchoolLocation { get; set; }
        public short? GraduationYear { get; set; }
        public string? CertificateSeries { get; set; }
        public string? CertificateNumber { get; set; }
        public string? EducationDocType { get; set; }
        public string? EducationType2 { get; set; }
        public DateTime? EduDocIssueDate { get; set; }
        public string? Citizenship { get; set; }
        public string? RegionPP { get; set; }
        public string? DistrictPP { get; set; }
        public string? CountryPP { get; set; }
        public string? Region { get; set; }
        public bool? Original { get; set; }
        public bool? OriginalDocument { get; set; }
        public DateTime? OriginalSubmissionDate { get; set; }
        public string? BenefitsName { get; set; }
        public string? Snils { get; set; }
        public string? PP { get; set; }
        public int? WithoutExam { get; set; }
        public int? BenefitType { get; set; }
        public int? Priority { get; set; }
        public int? ServicePriority { get; set; }
        public long? EPGUCode { get; set; }
        public long? EPGUApplicationCode { get; set; }
        public string? Payment { get; set; }
        public string? ParentPhone { get; set; }
        public DateTime? DocsSubmitDate { get; set; }
        public bool? RefusedEnrollment { get; set; }
        public DateTime? RefusedEnrollmentDate { get; set; }
        public bool? Enrolled { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string? Order { get; set; }
        public bool? TookDocs { get; set; }
        public DateTime? TookDocsDate { get; set; }
        public string? Document { get; set; }
        public string? Ld { get; set; }
        public string? CaseNumber { get; set; }
        public string? Gradebook { get; set; }
        public int? Status { get; set; }
        public int? SpecialStatus { get; set; }
        public string? ApplicationStatus { get; set; }
        public double? AvgAttestatScore { get; set; }
        public int? EducationService { get; set; }
        public int? OOP { get; set; }
        public int? CN { get; set; }
        public int? SN { get; set; }
        public int? QV { get; set; }
        public int? MIB { get; set; }
        public string? Costs { get; set; }
        public string? Sum { get; set; }
        public bool? AdditionalSet { get; set; }
        public string? Conditions { get; set; }
        public string? LearningConditions { get; set; }
        public int? BasisNumber { get; set; }
        public string? NumberLD { get; set; }
        public int? RecruitmentYear { get; set; }
        public int? BenefitDocCode { get; set; }
        public bool? Deleted { get; set; }
        public string? OtherVUZ { get; set; }

        // Вычисляемые поля
        public string? PlanNabora { get; set; }
        public string? OriginalDoc { get; set; }
        public bool? HighestPriority { get; set; }
        public string? HighestPriorityText { get; set; }
        public string? HighestPriorityOriginal { get; set; }

        // Поля из экзаменов
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
        public double? Score1 { get; set; }
        public double? Score2 { get; set; }
        public double? Score3 { get; set; }
        public double? Score4 { get; set; }
        public double? Score5 { get; set; }
        public double? Score6 { get; set; }
        public double? AdditionalScoreId { get; set; }
        public double? ScoreSum { get; set; }
        public double? Scores { get; set; }
        public string? Total { get; set; }
        public int? Count { get; set; }
        public bool? NoExamType { get; set; }

        public string? Company { get; set; }


        public string? ConsentedDirection { get; set; }
        public string? ConsentUploadDate { get; set; }
        public int? ConsentFilesCount { get; set; }

        public string? GreenWaveDate { get; set; }
        public int? GreenWaveFilesCount { get; set; }

        public string? ReductionDate { get; set; }
        public int? ReductionFilesCount { get; set; }
    }
}