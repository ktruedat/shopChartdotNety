using System.ComponentModel;
using Microsoft.Build.Framework;

namespace shopChart.Models;

public class CategoryModel
{
    public int Id { get; set; }
    [Required]
    [DisplayName("Category")]
    public string? Name { get; set; }
}