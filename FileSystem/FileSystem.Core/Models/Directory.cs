
namespace FileSystem.Core.Models;

public class Directory : FsNode
{
    public Directory(string name) : base(name)
    {
    }

    public override FsNode CopyByValue()
    {
        var newFile = new Directory(this.Name)
        {
            _childNodes = this._childNodes.Select(n => n.CopyByValue()).ToList(),
        };
        return newFile;
    }
}