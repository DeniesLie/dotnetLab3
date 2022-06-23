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
    public virtual FsNode? ParentNode { get; set; }

    public string Path
    {
        get => (ParentNode?.Path ?? string.Empty) + '/' + Name;
    }

    public abstract FsNode? CopyByValue();

}