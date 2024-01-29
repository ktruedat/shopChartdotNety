using System.ComponentModel.DataAnnotations;

namespace shopChart.Data;

public class Category
{
    public int Id { get; set; }
    [Required] public string Name { get; set; } = null!;
}