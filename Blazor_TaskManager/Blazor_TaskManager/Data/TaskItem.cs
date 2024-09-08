using Blazor_TaskManager.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_TaskManager.Data;

public class TaskItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(150, MinimumLength = 3)]
    public string Title { get; set; }

    [Required]
    [EnumDataType(typeof(StatusOptionType))]
    public StatusOptionType Status { get; set; }

    [Required]
    [EnumDataType(typeof(PriorityOptionType))]
    public PriorityOptionType Priority { get; set; }

    [Required]
    public DateTime DueDate { get; set; }


    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
