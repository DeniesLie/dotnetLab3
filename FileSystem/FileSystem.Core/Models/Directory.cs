
namespace FileSystem.Core.Models;

public class Directory : FsContainer
{
    public Directory(string name) : base(name)
    {
    }

    public override FsNode CopyByValue()
    {
        var newFile = new Directory(this.Name)
        {
            ChildrenNodes = ChildrenNodes.Select(n => n.CopyByValue()).ToList(),
        };
        return newFile;
    }
}