using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("АбитДисциплины", Schema = "dbo")]
public class AbitDiscipline
{
    [Key]
    [Column("Код")]
    public int Code { get; set; }

    [Column("Дисциплина")]
    public string? Name { get; set; }

    [Column("ДисСокращ")]
    public string? ShortName { get; set; }
}
