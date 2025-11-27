using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("Пользователи", Schema = "dbo")]
    public class UserInfo
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Логин")]
        public string? Login { get; set; }

        [Column("ФИО")]
        public string? FullName { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("Телефон")]
        public string? Phone { get; set; }
    }
}
