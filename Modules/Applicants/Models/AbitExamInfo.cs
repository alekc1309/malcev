using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("ДляСводнойВедомостиОтчет", Schema = "dbo")]
    public class AbitExamInfo
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Код_Заявления")]
        public int ApplicationCode { get; set; }

        [Column("БаллыВсего")]
        public double? BallTotal { get; set; }

        [Column("ВКонкурсе")]
        public int? InCompetition { get; set; }

        [Column("Оценка1")]
        public double? Score1 { get; set; }

        [Column("Оценка2")]
        public double? Score2 { get; set; }

        [Column("Оценка3")]
        public double? Score3 { get; set; }

        [Column("Оценка4")]
        public double? Score4 { get; set; }

        [Column("Оценка5")]
        public double? Score5 { get; set; }

        [Column("Оценка6")]
        public double? Score6 { get; set; }

        [Column("Итого")]
        public double? Total { get; set; }

        [Column("БаллИД")]
        public double? AdditionalScoreId { get; set; }

        [Column("СуммаБаллов")]
        public double? ScoreSum { get; set; }

        // --- Испытания (всегда varchar!) ---
        [Column("Исп1")]
        public string? Exam1 { get; set; }

        [Column("Исп2")]
        public string? Exam2 { get; set; }

        [Column("Исп3")]
        public string? Exam3 { get; set; }

        [Column("Исп4")]
        public string? Exam4 { get; set; }

        [Column("Исп5")]
        public string? Exam5 { get; set; }

        [Column("Исп6")]
        public string? Exam6 { get; set; }

        // --- Дисциплины (varchar) ---
        [Column("Дис1")]
        public string? Disc1 { get; set; }

        [Column("Дис2")]
        public string? Disc2 { get; set; }

        [Column("Дис3")]
        public string? Disc3 { get; set; }

        [Column("Дис4")]
        public string? Disc4 { get; set; }

        [Column("Дис5")]
        public string? Disc5 { get; set; }

        [Column("Дис6")]
        public string? Disc6 { get; set; }

        // --- Коды дисциплин (int) ---
        [Column("КодДис1")]
        public int? DiscCode1 { get; set; }

        [Column("КодДис2")]
        public int? DiscCode2 { get; set; }

        [Column("КодДис3")]
        public int? DiscCode3 { get; set; }

        [Column("КодДис4")]
        public int? DiscCode4 { get; set; }

        [Column("КодДис5")]
        public int? DiscCode5 { get; set; }

        [Column("КодДис6")]
        public int? DiscCode6 { get; set; }

        // --- Профили ЕГЭ (float) ---
        [Column("Мат")]
        public double? Mat { get; set; }

        [Column("ИКТ")]
        public double? Ikt { get; set; }

        [Column("Физ")]
        public double? Fiz { get; set; }

        [Column("Рус")]
        public double? Rus { get; set; }

        [Column("Хим")]
        public double? Him { get; set; }

        [Column("Ист")]
        public double? Ist { get; set; }

        [Column("Общ")]
        public double? Obsh { get; set; }

        [Column("Рис")]
        public double? Ris { get; set; }

        [Column("Лит")]
        public double? Lit { get; set; }

        [Column("Комп")]
        public double? Komp { get; set; }

        [Column("ИнЯз")]
        public double? InYaz { get; set; }

        [Column("Гео")]
        public double? Geo { get; set; }

        [Column("Био")]
        public double? Bio { get; set; }

        [Column("ТИ")]
        public double? TI { get; set; }

        // Испытания текстовые
        [Column("РусИсп")]
        public string? RusExam { get; set; }

        [Column("МатИсп")]
        public string? MatExam { get; set; }

        [Column("ОбщИсп")]
        public string? ObshExam { get; set; }

        [Column("ФизИсп")]
        public string? FizExam { get; set; }

        [Column("ХимИсп")]
        public string? HimExam { get; set; }

        [Column("БиоИсп")]
        public string? BioExam { get; set; }

        [Column("ГеоИсп")]
        public string? GeoExam { get; set; }

        [Column("ИстИсп")]
        public string? IstExam { get; set; }

        [Column("ИКТИсп")]
        public string? IktExam { get; set; }

        // Средние
        [Column("СрБалл")]
        public double? AvgTotal { get; set; }

        [Column("СрБаллЕГЭ")]
        public double? AvgEge { get; set; }

        [Column("СрБаллВИ")]
        public double? AvgVi { get; set; }

        [Column("МинОценкаЕГЭ")]
        public double? MinEgeScore { get; set; }

        // Даты
        [Column("Дата1")]
        public DateTime? Date1 { get; set; }

        [Column("Дата2")]
        public DateTime? Date2 { get; set; }

        [Column("Дата3")]
        public DateTime? Date3 { get; set; }

        [Column("Дата4")]
        public DateTime? Date4 { get; set; }

        [Column("Дата5")]
        public DateTime? Date5 { get; set; }

        [Column("Дата6")]
        public DateTime? Date6 { get; set; }

        [Column("БаллИДбезСоч")]
        public double? AdditionalScoreNoEssay { get; set; }

        [Column("БаллСоч")]
        public double? EssayScore { get; set; }

        [Column("ВесИД")]
        public double? IdWeight { get; set; }

        [Column("КодСпециальности")]
        public int? SpecialtyCode { get; set; }

        [Column("Z")]
        public bool? Z { get; set; }

        [Column("U")]
        public int? U { get; set; }

        [Column("Согласен")]
        public bool? Agreement { get; set; }

        [Column("ЕГЭ")]
        public int? Ege { get; set; }

        [Column("НеЕГЭ")]
        public int? NoEge { get; set; }

        [Column("МинОценка")]
        public double? MinScore { get; set; }

        [Column("Допуск")]
        public int? Admission { get; set; }

        [Column("Допуск1")]
        public int? Admission1 { get; set; }

        [Column("Допуск2")]
        public int? Admission2 { get; set; }

        [Column("Допуск3")]
        public int? Admission3 { get; set; }

        [Column("Допуск4")]
        public int? Admission4 { get; set; }

        [Column("Допуск5")]
        public int? Admission5 { get; set; }

        [Column("Допуск6")]
        public int? Admission6 { get; set; }

        [Column("Олим100")]
        public int? Olim100 { get; set; }
    }
}
