
namespace Allin.Inventory.Infrastructure.Persistence;

public class PackingArrangement : InventoryBaseEntity 
{
  public long PackingId { get; set; }
  public double ConversionFactor { get; set; }
  public long ContainerPackingId { get; set; }
}
