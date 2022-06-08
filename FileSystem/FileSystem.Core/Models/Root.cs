namespace FileSystem.Core.Models;

public class Root : FsContainer
{
    public Root(string name) : base(name)
    {
    }

    public override FsNode CopyByValue()
    {
        throw new NotImplementedException();
    }

    public override string Path
    {
        get => Name;
    }

    public override bool AddChild(FsNode childNode)
    {
        if (childNode is Drive && !ChildrenNodes.Select(c => c.Name).Contains(childNode.Name))
        {
            ChildrenNodes.Add(childNode);
            childNode.ParentNode = this;
            return true;
        }

        return false;
    }
}