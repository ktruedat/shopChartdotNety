using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace shopChart.Data;


[Table("Sales")]
public class Sale
{
    [Key]
    [Column("SaleID")]
    public int SaleID { get; set; }

    [Column("ProductID")]
    [ForeignKey("Products")]
    public int ProductID { get; set; }

    [Column("CustomerID")]
    [ForeignKey("Customers")]
    public int CustomerID { get; set; }

    [Column("Quantity")]
    public int Quantity { get; set; }

    [Column("Amount")]
    public double Amount { get; set; }

    [Column("PromotionID")]
    [ForeignKey("Promotions")]
    public int PromotionID { get; set; }

    [Column("Date")]
    public DateTime Date { get; set; }

    public Sale(int SaleID, int ProductID, int CustomerID, int Quantity, double Amount, int PromotionID, DateTime Date)
    {
        this.SaleID = SaleID;
        this.ProductID = ProductID;
        this.CustomerID = CustomerID;
        this.Quantity = Quantity;
        this.Amount = Amount;
        this.PromotionID = PromotionID;
        this.Date = Date;
    }

    public override string ToString()
    {
        return $"Sale(SaleID={SaleID}, ProductID='{ProductID}', CustomerID={CustomerID}, Quantity={Quantity}, Amount={Amount}, PromotionID={PromotionID}, Date={Date})";
    }
}