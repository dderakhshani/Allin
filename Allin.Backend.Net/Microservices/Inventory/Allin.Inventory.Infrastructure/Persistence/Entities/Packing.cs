
namespace Allin.Inventory.Infrastructure.Persistence;

public class Packing : InventoryBaseEntity 
{
  public int LevelCode { get; set; }
  public string Title { get; set; } = null!;
  public double ConversionFactor { get; set; }
  public long MeasureUnitBaseId { get; set; }
}
