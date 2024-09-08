using System.ComponentModel.DataAnnotations;

namespace Blazor_TaskManager.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(150, MinimumLength =3)]
    public string Name { get; set; }
}
