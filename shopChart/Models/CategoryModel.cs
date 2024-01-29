using System.ComponentModel;
using Microsoft.Build.Framework;
using shopChart.Data;

namespace shopChart.Models;

public class CategoryModel
{
    public int Id { get; set; }
    [Required]
    [DisplayName("Category")]
    public string? Name { get; set; }

    public static CategoryModel FromCategory(Category category)
    {
        return new CategoryModel
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public Category ToCategory()
    {
        return new Category
        {
            Id = Id,
            Name = Name
        };
    }
}