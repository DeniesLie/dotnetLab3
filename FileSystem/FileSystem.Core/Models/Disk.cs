namespace FileSystem.Core.Models;

public class Disk : FsNode
{
    public Disk(string name) : base(name)
    { }

    public override FsNode? ParentNode 
    { 
        get => null;
        set => throw new InvalidOperationException("Can't add parent node to the disk");
    }

    public override FsNode CopyByValue()
    {
        throw new NotImplementedException();
    }
}