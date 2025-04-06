using System;
using System.Collections.Generic;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Inventory.Infrastructure.Persistence;

public class InventoryCategoryProperty : InventoryBaseEntity , IHierarchyEntity
{
  public long? ParentId { get; set; }
  public HierarchyId? Hierarchy { get; set; }
  public long? CategoryId { get; set; }
  public string UniqueName { get; set; } = null!;
  public string Title { get; set; } = null!;
  public long? MeasureUnitId { get; set; }
    /// <summary>
    /// 1=Text 2=Integer(long) 3=Float 4=Boolean. 5=Items, 6 = date
    /// </summary>
  public PropertyTypeEnums PropertyTypeEnum { get; set; }
    /// <summary>
    /// 1=Text,2=Number, 3=Dropdown 4=MultiSelectDropDown, 5=RadioList, 6=CheckboxList, 7=Checkbox, 8=ToggleSwitch, 9=ToggleButton, 10= datepicker
    /// </summary>
  public UicontrolEnums UicontrolEnum { get; set; }
  public bool IsAssetSpecific { get; set; }
  public bool HasRange { get; set; }
  public int OrderIndex { get; set; }
    public virtual InventoryCategory? Category { get; set; }
    public virtual ICollection<InventoryCategoryPropertyItem> InventoryCategoryPropertyItems { get; set; } = new List<InventoryCategoryPropertyItem>();
    public virtual ICollection<InventoryCategoryPropertyRange> InventoryCategoryPropertyRanges { get; set; } = new List<InventoryCategoryPropertyRange>();
    public virtual ICollection<InventoryPropertyValue> InventoryPropertyValues { get; set; } = new List<InventoryPropertyValue>();
    public virtual MeasureUnit? MeasureUnit { get; set; }
}
