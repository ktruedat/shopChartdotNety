using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopChart.Data;


[Table("Products")]
public class Product
{
    [Key]
    [Column("ProductID")]
    public int ProductID { get; set; }

    [Column("Name")]
    [StringLength(255)]
    public string Name { get; set; }

    [Column("CategoryID")]
    [ForeignKey("Categories")]
    public int CategoryID { get; set; }

    [Column("Price")]
    public double Price { get; set; }

    [Column("ProducerID")]
    [ForeignKey("Producers")]
    public int ProducerID { get; set; }

    public Product(int ProductID, string Name, int CategoryID, double Price, int ProducerID)
    {
        this.ProductID = ProductID;
        this.Name = Name;
        this.CategoryID = CategoryID;
        this.Price = Price;
        this.ProducerID = ProducerID;
    }

    public override string ToString()
    {
        return $"Product(ProductID={ProductID}, Name='{Name}', CategoryID={CategoryID}, Price={Price}, ProducerID={ProducerID})";
    }
}