// Project.Api\Modules\Applicants\Services\ApplicantCalculations.cs
using System.Globalization;
using Project.Api.Modules.Applicants.Models;
using Project.Api.Modules.Applicants.Models.Dto; // <= Добавить
using Project.Api.Modules.Applicants.Models.Computed;
using static Project.Api.Modules.Applicants.Models.AbitSpisokAbit;

namespace Project.Api.Modules.Applicants.Services
{
    public static class ApplicantCalculations
    {
        public static AbitSpisokAbitDto Calculate(ApplicantList a, AbitExamInfo? ex)
        {
            var dto = new AbitSpisokAbitDto();

            // ===== 1. Копируем простые поля из АбитСписокАбит =====

            dto.Id = a.Id;
            dto.ApplicationCode = a.ApplicationCode;
            dto.FullName = a.FullName;
            dto.LastName = a.LastName;
            dto.FirstName = a.FirstName;
            dto.MiddleName = a.MiddleName;
            dto.Email = a.Email;
            dto.Mobile = a.Mobile;
            dto.BirthDate = a.BirthDate;
            dto.Gender = a.Gender;

            dto.SpecialtyCode = a.SpecialtyCode;
            dto.SpecialtyName = a.SpecialtyName;
            dto.SpecialName = a.SpecialName;
            dto.Specialization = a.Specialization;
            dto.Profile = a.Profile;
            dto.Faculty = a.Faculty;
            dto.OKSO = a.OKSO;
            dto.Level = a.Level;
            dto.LevelName = a.LevelName;
            dto.LevelCategory = a.LevelCategory;
            dto.EducationForm = a.EducationForm;

            dto.Address = a.Address;
            dto.Address2 = a.Address2;

            // Общежитие: в БД varchar, в DTO – bool?
            dto.Dormitory = a.DormitoryRaw switch
            {
                null => null,
                var s when string.IsNullOrWhiteSpace(s) => null,
                var s when s == "1"
                           || s.Equals("да", StringComparison.OrdinalIgnoreCase)
                           || s.Equals("true", StringComparison.OrdinalIgnoreCase)
                           || s.Equals("нуждается", StringComparison.OrdinalIgnoreCase) => true,
                var s when s == "0"
                           || s.Equals("нет", StringComparison.OrdinalIgnoreCase)
                           || s.Equals("false", StringComparison.OrdinalIgnoreCase) => false,
                _ => null
            };

            dto.EducationType = a.EducationType;
            dto.School = a.School;
            dto.SchoolLocation = a.SchoolLocation;
            dto.GraduationYear = a.GraduationYear;
            dto.CertificateSeries = a.CertificateSeries;
            dto.CertificateNumber = a.CertificateNumber;
            dto.EducationDocType = a.EducationDocType;
            dto.EducationType2 = a.EducationType2;
            dto.EduDocIssueDate = a.EduDocIssueDate;

            dto.Citizenship = a.Citizenship;
            dto.RegionPP = a.RegionPP;
            dto.DistrictPP = a.DistrictPP;
            dto.CountryPP = a.CountryPP;
            dto.Region = a.Region;

            dto.Original = a.Original;
            dto.OriginalDocument = a.OriginalDocument;
            dto.OriginalSubmissionDate = a.OriginalSubmissionDate;

            dto.BenefitsName = a.BenefitsName;
            dto.Snils = a.Snils;
            dto.PP = a.PP;
            dto.WithoutExam = a.WithoutExam;
            dto.BenefitType = a.BenefitType;

            dto.Priority = a.Priority;
            dto.ServicePriority = a.ServicePriority;

            dto.EPGUCode = a.EPGUCode;
            dto.EPGUApplicationCode = a.EPGUApplicationCode;

            dto.Payment = a.Payment;
            dto.ParentPhone = a.ParentPhone;

            dto.DocsSubmitDate = a.DocsSubmitDate;
            dto.RefusedEnrollment = a.RefusedEnrollment;
            dto.RefusedEnrollmentDate = a.RefusedEnrollmentDate;
            dto.Enrolled = a.Enrolled;
            dto.EnrollmentDate = a.EnrollmentDate;
            dto.Order = a.Order;
            dto.TookDocs = a.TookDocs;
            dto.TookDocsDate = a.TookDocsDate;

            dto.Document = a.Document;
            dto.Ld = a.Ld;
            dto.CaseNumber = a.CaseNumber;
            dto.Gradebook = a.Gradebook;

            dto.Status = a.Status;
            dto.SpecialStatus = a.SpecialStatus;
            dto.ApplicationStatus = a.ApplicationStatus;
            dto.AvgAttestatScore = a.AvgAttestatScore;

            dto.EducationService = a.EducationService;
            dto.OOP = a.OOP;
            dto.CN = a.CN;
            dto.SN = a.SN;
            dto.QV = a.QV;
            dto.MIB = a.MIB;

            dto.Costs = a.Costs;
            dto.Sum = a.Sum;
            dto.AdditionalSet = a.AdditionalSet;
            dto.Conditions = a.Conditions;
            dto.LearningConditions = a.LearningConditions;
            dto.BasisNumber = a.BasisNumber;
            dto.NumberLD = a.NumberLD;

            dto.RecruitmentYear = a.RecruitmentYear;
            dto.BenefitDocCode = a.BenefitDocCode;
            dto.Deleted = a.Deleted;
            dto.OtherVUZ = a.OtherVUZ;

            // ===== 2. Вычисляемые поля по АбитСписокАбит =====

            // ПланНабора: CASE по УслОбучения
            var plan = a.EducationService switch
            {
                1 => a.OOP ?? 0,
                2 => a.CN ?? 0,
                3 => a.SN ?? 0,
                5 => a.QV ?? 0,
                6 => a.MIB ?? 0,
                _ => 0
            };
            dto.PlanNabora = plan.ToString();

            // ОригиналДок (текст)
            dto.OriginalDoc = a.OriginalSubmissionDate.HasValue ? "Да" : "Нет";

            // Высший приоритет
            var highest = (a.Priority == 1);
            dto.HighestPriority = highest;
            dto.HighestPriorityText = highest ? "Первый приоритет" : "Нет";
            dto.HighestPriorityOriginal =
                (highest && (a.OriginalDocument ?? false)) ? "Да" : "Нет";

            // ===== 3. Если экзаменов нет – обнуляем и выходим =====
            var cmp = ex == null ? null : new AbitExamComputed
            {
                ApplicationCode = ex.ApplicationCode,

                Score1 = ex.Score1 ?? 0,
                Score2 = ex.Score2 ?? 0,
                Score3 = ex.Score3 ?? 0,
                Score4 = ex.Score4 ?? 0,
                Score5 = ex.Score5 ?? 0,
                Score6 = ex.Score6 ?? 0,

                AdditionalScoreId = ex.AdditionalScoreId ?? 0,
                ScoreSum = ex.ScoreSum ?? 0,
                Total = ex.Total ?? 0,

                Count = new[] { ex.Score1, ex.Score2, ex.Score3, ex.Score4, ex.Score5, ex.Score6 }
                .Count(x => x.HasValue),

                NoExamType = string.IsNullOrEmpty(ex.Exam1) &&
                 string.IsNullOrEmpty(ex.Exam2) &&
                 string.IsNullOrEmpty(ex.Exam3),

                Exam1 = ex.Exam1,
                Exam2 = ex.Exam2,
                Exam3 = ex.Exam3,
                Exam4 = ex.Exam4,
                Exam5 = ex.Exam5,
                Exam6 = ex.Exam6,

                Disc1 = ex.Disc1,
                Disc2 = ex.Disc2,
                Disc3 = ex.Disc3,
                Disc4 = ex.Disc4,
                Disc5 = ex.Disc5,
                Disc6 = ex.Disc6
            };
            if (ex == null)
            {
                dto.Exam1 = dto.Exam2 = dto.Exam3 = dto.Exam4 = dto.Exam5 = dto.Exam6 = null;
                dto.Disc1 = dto.Disc2 = dto.Disc3 = dto.Disc4 = dto.Disc5 = dto.Disc6 = null;

                dto.Score1 = dto.Score2 = dto.Score3 = dto.Score4 = dto.Score5 = dto.Score6 = null;
                dto.AdditionalScoreId = 0;
                dto.ScoreSum = 0;
                dto.Scores = 0;
                dto.Total = "0";
                dto.Count = 0;
                dto.NoExamType = true;

                return dto;
            }

            // ===== 4. Переносим экзамены из ДляСводнойВедомостиОтчет =====

            dto.Exam1 = ex.Exam1;
            dto.Exam2 = ex.Exam2;
            dto.Exam3 = ex.Exam3;
            dto.Exam4 = ex.Exam4;
            dto.Exam5 = ex.Exam5;
            dto.Exam6 = ex.Exam6;

            dto.Disc1 = ex.Disc1;
            dto.Disc2 = ex.Disc2;
            dto.Disc3 = ex.Disc3;
            dto.Disc4 = ex.Disc4;
            dto.Disc5 = ex.Disc5;
            dto.Disc6 = ex.Disc6;

            dto.Score1 = ex.Score1;
            dto.Score2 = ex.Score2;
            dto.Score3 = ex.Score3;
            dto.Score4 = ex.Score4;
            dto.Score5 = ex.Score5;
            dto.Score6 = ex.Score6;

            dto.AdditionalScoreId = ex.AdditionalScoreId;

            // ===== 5. Расчёт сумм =====

            dto.Score1 = cmp.Score1;
            dto.Score2 = cmp.Score2;
            dto.Score3 = cmp.Score3;
            dto.Score4 = cmp.Score4;
            dto.Score5 = cmp.Score5;
            dto.Score6 = cmp.Score6;

            dto.ScoreSum = cmp.ScoreSum;
            dto.Scores = cmp.TotalWithBonus;
            dto.Count = cmp.Count;
            dto.NoExamType = cmp.NoExamType;

            dto.Total = cmp.Total.ToString();


            int count = 0;
            if (ex.Score1.HasValue) count++;
            if (ex.Score2.HasValue) count++;
            if (ex.Score3.HasValue) count++;
            if (ex.Score4.HasValue) count++;
            if (ex.Score5.HasValue) count++;
            if (ex.Score6.HasValue) count++;
            dto.Count = count;

            dto.NoExamType =
                string.IsNullOrEmpty(ex.Exam1) &&
                string.IsNullOrEmpty(ex.Exam2) &&
                string.IsNullOrEmpty(ex.Exam3);

            return dto;
        }
    }
}
