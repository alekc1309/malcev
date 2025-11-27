using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("ДостиженияВидыВГруппах", Schema = "dbo")]
    public class AchievementGroup
    {
        [Key]
        [Column("Код")]
        public int Code { get; set; }

        [Column("КодГруппы")]
        public int GroupCode { get; set; }

        [Column("КодВидаДостижения")]
        public int TypeCode { get; set; }
    }
}
