using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Вид_Испытания", Schema = "dbo")]
public class ExamType
{
    [Key]
    [Column("Код")]
    public int Code { get; set; }

    [Column("Название")]
    public string? Name { get; set; }

    [Column("Комментарий")]
    public string? Comment { get; set; }

    [Column("Сокращение")]
    public string? ShortName { get; set; }
}
