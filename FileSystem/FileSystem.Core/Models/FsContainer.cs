using FileSystem.Core.Helpers;

namespace FileSystem.Core.Models;

public abstract class FsContainer : FsNode
{
    protected ICollection<FsNode> ChildrenNodes = new List<FsNode>();
    
    protected FsContainer(string name) : base(name)
    {
    }

    public virtual FsNode? FindChild(FsPath fsPath)
    {
        var isLast = !fsPath.MoveNext();
        var childName = fsPath.Current;
        
        if (isLast && childName == this.Name)
            return this;
        
        var child = ChildrenNodes.SingleOrDefault(c => c.Name == childName);
        
        if (child == null)
            return null;

        if (child is FsContainer childContainer)
            return childContainer.FindChild(fsPath);
        
        return child;
    }

    public virtual bool AddChild(FsNode childNode)
    {
        if (!ChildrenNodes.Select(c => c.Name).Contains(childNode.Name))
        {
            ChildrenNodes.Add(childNode);
            childNode.ParentNode = this;
            return true;
        }
        return false;
    }

    public IEnumerable<FsNode> GetChildren()
    {
        return ChildrenNodes.Select(n => n);
    }
}