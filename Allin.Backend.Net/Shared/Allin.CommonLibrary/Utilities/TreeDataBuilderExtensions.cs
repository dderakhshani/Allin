using Allin.Common.Entities;

public class TreeNode<T>
{
    public T Data { get; set; }
    public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
}

public static class TreeDataBuilder
{
    public static List<TreeNode<T>> BuildTree<T>(this List<T> items) where T : BaseHierarchyEntity
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
}
