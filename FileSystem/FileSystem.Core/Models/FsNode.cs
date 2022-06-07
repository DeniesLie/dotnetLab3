namespace FileSystem.Core.Models;

public abstract class FsNode
{
    protected ICollection<FsNode> _childNodes;
    
    public FsNode(string name)
    {
        _childNodes = new LinkedList<FsNode>();
        Id = new Guid();
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; set; }
    public virtual FsNode? ParentNode { get; set; }

    public string Path
    {
        get => ParentNode.Path + '/' + Name;
    }

    public IEnumerable<FsNode> FsNodes
    {
        get => _childNodes.Select(node => node);
    }

    public abstract FsNode CopyByValue();
    
    public bool AddChild(FsNode fsNode)
    {
        if (fsNode == null) throw new ArgumentNullException(nameof(fsNode));
        if (_childNodes.Contains(fsNode)) return false;
        
        _childNodes.Add(fsNode);
        fsNode.ParentNode = this;
        return true;
    }

    public FsNode? FindChild(Helpers.Path path)
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
    }

    
}