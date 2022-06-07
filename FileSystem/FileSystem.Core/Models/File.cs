namespace FileSystem.Core.Models;

public class File : FsNode
{
    public string Content { get; set; } = string.Empty;

    public File(string name, string content) : base(name)
    {
        Content = content;
    }

    public override FsNode CopyByValue()
    {
        var newFile = new File(this.Name, this.Content)
        {
            _childNodes = this._childNodes.Select(n => n.CopyByValue()).ToList(),
        };
        return newFile;
    }
}