using FileSystem.Core.Enums;
using FileSystem.Core.Helpers;

namespace FileSystem.Core.Models;

public abstract class FsNode
{
    public FsNode(string name)
    {
        Name = name;
    }
    
    public string Name { get; set; }
    public FsNodeType Type { get; protected set; }
    public virtual FsNode? ParentNode { get; set; }

    public virtual string Path
    {
        get => (ParentNode?.Path ?? string.Empty) + '/' + Name;
    }
    public abstract FsNode? CopyByValue();

    // public virtual IEnumerable<FsNode>? ChildNodes
    // {
    //     get => _childNodes.Select(node => node);
    // }

    // public virtual bool AddChild(FsNode fsNode)
    // {
    //     if (fsNode == null) throw new ArgumentNullException(nameof(fsNode));
    //     if (_childNodes.Contains(fsNode)) return false;
    //     
    //     _childNodes.Add(fsNode);
    //     fsNode.ParentNode = this;
    //     return true;
    // }

    /*public virtual FsNode? FindChild(FsPath path)
    {
        var current = path.Current;
        if (path.MoveNext() == false)
        {
            if (current == Name) 
                return this;
            
            return null;
        }

        var child = _childNodes.SingleOrDefault(n => n.Name == path.Current);
        if (child != null)
            return child.FindChild(path);
        
        return null;   
    }*/

    
}