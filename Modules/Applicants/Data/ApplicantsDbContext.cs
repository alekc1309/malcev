using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Models;
using System.Xml.Linq;
using static Project.Api.Modules.Applicants.Models.AbitSpisokAbit;

namespace Project.Api.Modules.Applicants.Data
{
    public class ApplicantsDbContext : DbContext
    {
        public ApplicantsDbContext(DbContextOptions<ApplicantsDbContext> options)
            : base(options)
        {
        }

        public override int SaveChanges()
        {
            Database.SetCommandTimeout(100); // 100000ms = 100 seconds
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            Database.SetCommandTimeout(100); // 100000ms = 100 seconds
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Database.SetCommandTimeout(100); // 100000ms = 100 seconds
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            Database.SetCommandTimeout(100); // 100000ms = 100 seconds
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        // Абитуриенты
        public DbSet<ApplicantList> Applicants { get; set; } = null!;

        // Экзамены / Сводная ведомость
        public DbSet<AbitExamInfo> ExamInfos { get; set; } = null!;

        // Дисциплины
        public DbSet<Discipline> Disciplines { get; set; } = null!;

        // Виды испытаний
        public DbSet<ExamType> ExamTypes { get; set; } = null!;

        // Статусы студента
        public DbSet<StudentStatus> StudentStatuses { get; set; } = null!;

        // Документы (ЕГЭ / Внутренние)
        public DbSet<AbitDocument> AbitDocuments { get; set; } = null!;

        // Достижения абитуриента
        public DbSet<AbitAchievement> AbitAchievements { get; set; } = null!;

        // Виды достижений
        public DbSet<AchievementType> AchievementTypes { get; set; } = null!;

        // Виды достижений в группах
        public DbSet<AchievementTypeGroup> AchievementTypeGroups { get; set; } = null!;

        // Короткие записи всех заявлений
        public DbSet<ApplicationShort> ApplicationsShort { get; set; } = null!;

        // Справочник оплат
        public DbSet<PaymentEntry> Payments { get; set; } = null!;

        // Роли
        public DbSet<RoleInfo> Roles { get; set; } = null!;
        public DbSet<AllDocuments> AllDocuments { get; set; } = null!;

        // Файлы (dbo.Files)
        public DbSet<ApplicantApplications> ApplicantApplications { get; set; } = null!;
        public DbSet<FileRecord> Files { get; set; } = null!;
        public DbSet<AllApplications> AllApplications { get; set; } = null!;
        // Специальности ЦО
        public DbSet<SpecialtyCenter> SpecialtyCenters { get; set; } = null!;

        // Заказчики
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<UserInfo> Users { get; set; } = null!;

        // Все документы (коротко)
        public DbSet<DocumentShort> DocumentsShort { get; set; } = null!;

        // Типы документов
        public DbSet<DocumentType> DocumentTypes { get; set; } = null!;

        public DbSet<AbitMark> AbitMarks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AbitDocument>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Абит_Документы");

                entity.ToTable("Абит_Документы", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.DocumentCode).HasColumnName("Код_Документа");
                entity.Property(e => e.Discipline).HasColumnName("Дисциплина");
                entity.Property(e => e.Score).HasColumnName("Баллы");
                entity.Property(e => e.Status).HasColumnName("СтатусДок");
            });
        }
    }
}