using FileSystem.Core.Helpers;

namespace FileSystem.Core.Models;

public class File : FsNode
{
    public Guid Descriptor { get; private set; }
    public string Content { get; set; } = string.Empty;
    public File(string name, string content) : base(name)
    {
        Descriptor = new Guid();
        Content = content;
    }

    public override FsNode CopyByValue()
    {
        var newFile = new File(this.Name, this.Content);
        return newFile;
    }
    
}