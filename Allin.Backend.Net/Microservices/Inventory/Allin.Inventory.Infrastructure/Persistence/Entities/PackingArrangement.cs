using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Allin.Common.Data;
namespace Allin.Inventory.Infrastructure.Persistence;

public class PackingArrangement : InventoryBaseEntity
{
    [ForeignKey("Packing")]
    public long PackingId { get; set; }
    public double ConversionFactor { get; set; }
    [ForeignKey("ContainerPacking")]
    public long ContainerPackingId { get; set; }
    public virtual Packing ContainerPacking { get; set; } = null!;
    public virtual Packing Packing { get; set; } = null!;
}
