using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace shopChart.Data;

[Table("Customers")]
public class Customer
{
    [Key]
    [Column("CustomerID")]
    public int CustomerID { get; set; }

    [Column("Name")]
    [StringLength(255)]
    public string Name { get; set; }

    [Column("Email")]
    [StringLength(255)]
    public string Email { get; set; }

    [Column("Phone")]
    [StringLength(20)]
    public string Phone { get; set; }

    public Customer(int CustomerID, string Name, string Email, string Phone)
    {
        this.CustomerID = CustomerID;
        this.Name = Name;
        this.Email = Email;
        this.Phone = Phone;
    }

    public override string ToString()
    {
        return $"Customer(CustomerID={CustomerID}, Name='{Name}', Email={Email}, Phone={Phone})";
    }
}