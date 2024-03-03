using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopChart.Data;

[Table("Promotions")]
public class Promotion
{
    [Key]
    [Column("PromotionID")]
    public int PromotionID { get; set; }

    [Column("PromotionName")]
    [StringLength(255)]
    public string PromotionName { get; set; }

    [Column("DiscountPercentage")]
    public double DiscountPercentage { get; set; }

    [Column("StartDate")]
    public DateTime StartDate { get; set; }

    [Column("EndDate")]
    public DateTime EndDate { get; set; }

    public Promotion(int PromotionID, string PromotionName, double DiscountPercentage, DateTime StartDate, DateTime EndDate)
    {
        this.PromotionID = PromotionID;
        this.PromotionName = PromotionName;
        this.DiscountPercentage = DiscountPercentage;
        this.StartDate = StartDate;
        this.EndDate = EndDate;
    }

    public override string ToString()
    {
        return $"Promotion(PromotionID={PromotionID}, PromotionName='{PromotionName}', DiscountPercentage={DiscountPercentage}, StartDate={StartDate}, EndDate={EndDate})";
    }
}