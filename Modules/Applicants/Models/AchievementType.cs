using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("ДостиженияВиды", Schema = "dbo")]
    public class AchievementType
    {
        [Key]
        [Column("КодДостижения")]
        public int AchievementCode { get; set; }
    }
}
