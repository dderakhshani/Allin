namespace Allin.Admin.Infrastructure.Persistence;

public class TableExtendedField : AdminBaseEntity
{
    public long? ParentId { get; set; }
    public string UniqueName { get; set; }
    public string TableName { get; set; }
    public string FieldName { get; set; }
    public string Description { get; set; }
    /// <summary>
    /// 1=Text 2=Integer(long) 3=Float 4=Boolean. 5=Items
    /// </summary>
    public FieldTypeEnums FieldTypeEnum { get; set; }
    /// <summary>
    /// 1=Text,2=Number, 3=Dropdown 4=MultiSelectDropDown, 5=RadioList, 6=CheckboxList, 7=Checkbox, 8=ToggleSwitch, 9=ToggleButton
    /// </summary>
    public UicontrolEnums UicontrolEnum { get; set; }
    public int OrderIndex { get; set; }
    public virtual ICollection<TableExtendedFieldItem> TableExtendedFieldItems { get; set; } = new List<TableExtendedFieldItem>();
    public virtual ICollection<TableExtendedFieldValue> TableExtendedFieldValues { get; set; } = new List<TableExtendedFieldValue>();
}
