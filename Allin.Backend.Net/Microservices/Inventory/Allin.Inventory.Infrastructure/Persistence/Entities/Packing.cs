using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Inventory.Infrastructure.Persistence;

public class Packing : InventoryBaseEntity 
{
  public int LevelCode { get; set; }
  public string Title { get; set; } = null!;
  public double ConversionFactor { get; set; }
  public long MeasureUnitBaseId { get; set; }
    public virtual ICollection<PackingArrangement> PackingArrangementContainerPackings { get; set; } = new List<PackingArrangement>();
    public virtual ICollection<PackingArrangement> PackingArrangementPackings { get; set; } = new List<PackingArrangement>();
}
