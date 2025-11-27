using Project.Api.Modules.Applicants.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("Files", Schema = "dbo")]
    public class FileRecord
    {
        [Key]
        [Column("FileID")]
        public int Id { get; set; }

        [Column("FileName")]
        public string? FileName { get; set; }

        [Column("FileExt")]
        public string? FileExt { get; set; }

        [Column("documentID")]
        public int? DocumentId { get; set; }

        [Column("achievementID")]
        public int? AchievementId { get; set; }

        [Column("createdByUserID")]
        public int? CreatedBy { get; set; }

        [Column("createdOnDate")]
        public DateTime? CreatedOn { get; set; }

        [Column("length")]
        public int? Length { get; set; }

        [Column("fileContent")]
        public byte[]? Content { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }

        [Column("IsUnloaded")]
        public bool? IsUnloaded { get; set; }

        [Column("FileCaption")]
        public string? Caption { get; set; }

        [Column("FileGuid")]
        public Guid? Guid { get; set; }
    }
}
