using Allin.Common.Data;
using Allin.Common.Models;

namespace Allin.Common.Utilities;

public class TreeNode<T>
{
    public required T Data { get; set; }
    public string? Label { get; set; }
    public string? Key { get; set; }
    public bool Expanded { get; set; } = true;
    public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
}



public static class TreeDataBuilder
{
    public static List<TreeNode<T>> ToTreeData<T>(this List<T> items) where T : BaseHierarchyEntity
    {
        var lookup = items.ToDictionary(item => item.Id, item => new TreeNode<T> { Data = item });
        var rootNodes = new List<TreeNode<T>>();

        foreach (var item in items)
        {
            var node = lookup[item.Id];
            if (item.ParentId.HasValue && lookup.ContainsKey(item.ParentId.Value))
            {
                // Add as child to its parent
                lookup[item.ParentId.Value].Children.Add(node);
            }
            else
            {
                // If no parent, it's a root node
                rootNodes.Add(node);
            }
        }

        return rootNodes;
    }

    public static IEnumerable<TreeNode<T>> ToTreeModel<T>(this IEnumerable<T> items, string? LabelFieldName, string? KeyFieldName) where T : BaseHierarchyModel
    {
        var lookup = items.ToDictionary(item => item.Id,
        item => new TreeNode<T>
        {
            Data = item,
            Label = LabelFieldName != null ? GetPropertyValue(item, LabelFieldName).ToString() : null,
            Key = KeyFieldName != null ? GetPropertyValue(item, KeyFieldName).ToString() : null
        });
        var rootNodes = new List<TreeNode<T>>();

        foreach (var item in items)
        {
            var node = lookup[item.Id];
            if (item.ParentId.HasValue && lookup.ContainsKey(item.ParentId.Value))
            {
                // Add as child to its parent
                lookup[item.ParentId.Value].Children.Add(node);
            }
            else
            {
                // If no parent, it's a root node
                rootNodes.Add(node);
            }
        }

        return rootNodes;
    }

    private static object GetPropertyValue(object src, string propertyName)
    {
        return src.GetType().GetProperty(propertyName).GetValue(src, null);
    }

}
