namespace FileSystem.Core.Models;

public class Drive : FsContainer
{
    public Drive(string name) : base(name)
    { }

    public override FsNode? CopyByValue() => null;
}