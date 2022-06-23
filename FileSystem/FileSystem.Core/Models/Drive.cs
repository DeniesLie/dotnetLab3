namespace FileSystem.Core.Models;

public class Drive : FsContainer
{
    public Drive(string name) : base(name)
    { }

    public override FsNode? CopyByValue()
    {
        var newDrive = new Drive(this.Name)
        {
            ChildrenNodes = ChildrenNodes.Select(n => n.CopyByValue()).ToList(),
        };
        return newDrive;
    }
}