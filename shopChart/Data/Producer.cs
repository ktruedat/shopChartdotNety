using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopChart.Data;

[Table("Producers")]
public class Producer
{
    [Key]
    [Column("ProducerID")]
    public int ProducerID { get; set; }

    [Column("ProducerName")]
    [StringLength(255)]
    public string ProducerName { get; set; }

    [Column("ProducerLocation")]
    [StringLength(255)]
    public string ProducerLocation { get; set; }

    public Producer(int ProducerID, string ProducerName, string ProducerLocation)
    {
        this.ProducerID = ProducerID;
        this.ProducerName = ProducerName;
        this.ProducerLocation = ProducerLocation;
    }

    public override string ToString()
    {
        return $"Producer(ProducerID={ProducerID}, ProducerName='{ProducerName}', ProducerLocation={ProducerLocation})";
    }
}