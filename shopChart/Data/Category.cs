using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopChart.Data;



[Table("Categories")]
public class Category
{
    [Key]
    [Column("CategoryID")]
    public int CategoryID { get; set; }

    [Column("CategoryName")]
    [StringLength(255)]
    public string CategoryName { get; set; }

    public Category(int CategoryID, string Name)
    {
        this.CategoryID = CategoryID;
        this.CategoryName = Name;
    }

    public Category()
    {

    }

    public override string ToString()
    {
        return $"Category(CategoryID={CategoryID}, CategoryName='{CategoryName}')";
    }
}