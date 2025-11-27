using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    public class AbitSpisokAbit
    {
        /// <summary>
        /// Список абитуриентов – таблица dbo.АбитСписокАбит
        /// </summary>
        [Table("АбитСписокАбит", Schema = "dbo")]
        public class ApplicantList
        {
            [Key]
            [Column("ID")]
            public int Id { get; set; }

            [Column("Код_Заявления")]
            public int? ApplicationCode { get; set; }

            [Column("ФИО")]
            public string? FullName { get; set; }

            [Column("Фамилия")]
            public string? LastName { get; set; }

            [Column("Имя")]
            public string? FirstName { get; set; }

            [Column("Отчество")]
            public string? MiddleName { get; set; }

            [Column("E_Mail")]
            public string? Email { get; set; }

            [Column("Мобильный")]
            public string? Mobile { get; set; }

            [Column("Дата_рождения")]
            public DateTime? BirthDate { get; set; }

            [Column("Пол")]
            public string? Gender { get; set; }

            [Column("Код_Специальности")]
            public int? SpecialtyCode { get; set; }

            [Column("Название_Специальности")]
            public string? SpecialtyName { get; set; }

            [Column("Название_Спец")]
            public string? SpecialName { get; set; }

            [Column("Специализация")]
            public string? Specialization { get; set; }

            [Column("Профиль")]
            public string? Profile { get; set; }

            [Column("Факультет")]
            public string? Faculty { get; set; }

            [Column("ОКСО")]
            public string? OKSO { get; set; }

            [Column("Уровень")]
            public int? Level { get; set; }

            [Column("УровеньНазвание")]
            public string? LevelName { get; set; }

            // В БД: УровеньКатегория int
            [Column("УровеньКатегория")]
            public int? LevelCategory { get; set; }

            // В БД: ФормаОбучения int
            [Column("ФормаОбучения")]
            public int? EducationForm { get; set; }

            [Column("Адрес")]
            public string? Address { get; set; }

            [Column("Адрес2")]
            public string? Address2 { get; set; }

            // В БД: Общежитие varchar (НЕ bit!)
            [Column("Общежитие")]
            public string? DormitoryRaw { get; set; }

            [Column("ВидОбразования")]
            public string? EducationType { get; set; }

            [Column("Уч_Заведение")]
            public string? School { get; set; }

            [Column("Где_Находится_УЗ")]
            public string? SchoolLocation { get; set; }

            [Column("Год_Окончания_УЗ")]
            public short? GraduationYear { get; set; }

            [Column("Серия_Аттестата")]
            public string? CertificateSeries { get; set; }

            [Column("Номер_Аттестата")]
            public string? CertificateNumber { get; set; }

            [Column("Тип_Образ_Документа")]
            public string? EducationDocType { get; set; }

            [Column("ТипОбразования")]
            public string? EducationType2 { get; set; }

            [Column("Дата_Выдачи_УД")]
            public DateTime? EduDocIssueDate { get; set; }

            [Column("Гражданство")]
            public string? Citizenship { get; set; }

            [Column("Регион_ПП")]
            public string? RegionPP { get; set; }

            [Column("Район_ПП")]
            public string? DistrictPP { get; set; }

            [Column("Страна_ПП")]
            public string? CountryPP { get; set; }

            [Column("Регион")]
            public string? Region { get; set; }

            [Column("Оригинал")]
            public bool? Original { get; set; }

            [Column("ОригиналДокумента")]
            public bool? OriginalDocument { get; set; }

            [Column("ОригиналДатаПодачи")]
            public DateTime? OriginalSubmissionDate { get; set; }

            [Column("ЛьготыНазвание")]
            public string? BenefitsName { get; set; }

            [Column("СНИЛС")]
            public string? Snils { get; set; }

            [Column("ПП")]
            public string? PP { get; set; }

            // В БД: БезВИ int
            [Column("БезВИ")]
            public int? WithoutExam { get; set; }

            [Column("ВидЛьготы")]
            public int? BenefitType { get; set; }

            [Column("Приоритет")]
            public int? Priority { get; set; }

            [Column("ПриоритетУсл")]
            public int? ServicePriority { get; set; }

            [Column("КодЕПГУ")]
            public long? EPGUCode { get; set; }

            [Column("КодЕПГУЗаявления")]
            public long? EPGUApplicationCode { get; set; }

            [Column("Оплата")]
            public string? Payment { get; set; }

            [Column("Телефон_Родители")]
            public string? ParentPhone { get; set; }

            [Column("ДатаПодачиДокументов")]
            public DateTime? DocsSubmitDate { get; set; }

            [Column("ОтказалсяОтЗачисления")]
            public bool? RefusedEnrollment { get; set; }

            [Column("ОтказалсяОтЗачисленияДата")]
            public DateTime? RefusedEnrollmentDate { get; set; }

            [Column("Зачислен")]
            public bool? Enrolled { get; set; }

            [Column("Дата_Зачисления")]
            public DateTime? EnrollmentDate { get; set; }

            [Column("Приказ")]
            public string? Order { get; set; }

            [Column("ЗабралДок")]
            public bool? TookDocs { get; set; }

            [Column("ЗабралДата")]
            public DateTime? TookDocsDate { get; set; }

            [Column("Документ")]
            public string? Document { get; set; }

            [Column("ЛД")]
            public string? Ld { get; set; }

            [Column("НомерДела")]
            public string? CaseNumber { get; set; }

            [Column("ЗачетнаяКнижка")]
            public string? Gradebook { get; set; }

            [Column("Статус")]
            public int? Status { get; set; }

            [Column("СтатусСпец")]
            public int? SpecialStatus { get; set; }

            [Column("СтатусЗаявления")]
            public string? ApplicationStatus { get; set; }

            [Column("СрБаллАттестата")]
            public double? AvgAttestatScore { get; set; }

            // УслОбучения и план набора
            [Column("УслОбучения")]
            public int? EducationService { get; set; }

            [Column("ОО")]
            public int? OOP { get; set; }

            [Column("ЦН")]
            public int? CN { get; set; }

            [Column("СН")]
            public int? SN { get; set; }

            [Column("КВ")]
            public int? QV { get; set; }

            [Column("МИНОБР")]
            public int? MIB { get; set; }

            // Финансы (из Все_Заявления)
            [Column("Затраты")]
            public string? Costs { get; set; }

            [Column("Сумма")]
            public string? Sum { get; set; }

            [Column("ДополнительныйНабор")]
            public bool? AdditionalSet { get; set; }

            [Column("Условия")]
            public string? Conditions { get; set; }

            [Column("УсловияОбучения")]
            public string? LearningConditions { get; set; }

            // В БД: НомерОснования int
            [Column("НомерОснования")]
            public int? BasisNumber { get; set; }

            [Column("НомерЛД")]
            public string? NumberLD { get; set; }

            // Набор / льготы / удаление
            [Column("Год_Набора")]
            public int? RecruitmentYear { get; set; }

            // В БД: КодДокументаЛьготы int
            [Column("КодДокументаЛьготы")]
            public int? BenefitDocCode { get; set; }

            [Column("Удалена")]
            public bool? Deleted { get; set; }

            // В БД: ОригиналДок varchar
            [Column("ОригиналДок")]
            public string? OriginalDoc { get; set; }

            [Column("ОригиналДрВуз")]
            public string? OtherVUZ { get; set; }

            // вот новые

            [Column("СуммаБаллов")]
            public double? SumScores { get; set; }

            [Column("Итого")]
            public double? TotalScore { get; set; }

            [Column("ВысшийПриоритет")]
            public int? HighestPriority { get; set; }

            [Column("ВысшийПриоритетТекст")]
            public string? HighestPriorityText { get; set; }

            [Column("ВысшийПриоритетСУчетомОригинала")]
            public string? HighestPriorityWithOriginal { get; set; }

            [Column("Баллы")]
            public double? Points { get; set; }

            [Column("НетТипаИспытания")]
            public int? NoExamType { get; set; }

            [Column("КолВо")]
            public int? Count { get; set; }

            [Column("Кампания")]
            public string? Company { get; set; }

            [Column("ФилиалНазвание")]
            public string? Filials { get; set; }

        }
    }
}
