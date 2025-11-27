using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Api.Modules.Applicants.Models
{
    [Table("Заказчики", Schema = "dbo")]
    public class Customer
    {
        [Key]
        [Column("Код")]
        public int Code { get; set; }
    }
}
