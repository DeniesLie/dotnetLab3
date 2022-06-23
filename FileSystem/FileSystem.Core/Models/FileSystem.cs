using FileSystem.Core.Enums;
using FileSystem.Core.Helpers;

namespace FileSystem.Core.Models;

public sealed class FileSystem
{
    private static FileSystem? _instance;
    private readonly List<Drive> _drives;
    
    private FileSystem(IEnumerable<char> drivesNames)
    {
        _drives = drivesNames.Select(d => new Drive(d.ToString())).ToList();
    }
    
    public static FileSystem GetInstance(IEnumerable<char> disksNames)
    {
        if (_instance == null)
        {
            _instance = new FileSystem(disksNames);
        }
        return _instance;
    }
    
    public bool AddFsNode(FsPath fsPath, FsNode fsNode)
    {
        var nodeToAddInto = FindNode(fsPath);
        if (nodeToAddInto != null)
        {
            if (nodeToAddInto is FsContainer containerNode)
            {
                return containerNode.AddChild(fsNode);
            }
        }
        return false;
    }

    public bool CopyByValue(FsPath targetPath, FsPath destinationPath)
    {
        var targetNode = FindNode(targetPath);
        var destinationNode = FindNode(destinationPath);
        
        if (targetNode != null && destinationNode != null)
        {
            if (destinationNode is FsContainer destinationContainer)
            {
                var nodeCopy = targetNode.CopyByValue();
                destinationContainer.AddChild(nodeCopy);
                nodeCopy.ParentNode = destinationNode;
                return true;
            }
        }
        return false;
    }

    public IEnumerable<FsNode> GetNodesInDirectory(FsPath path)
    {
        IEnumerable<FsNode> result = new List<FsNode>();
        var targetNode = FindNode(path);
        
        if (targetNode is FsContainer targetContainer)
            result = targetContainer.GetChildren();
        
        return result;
    }

    public FsNode? FindNode(FsPath path)
    {
        var targetDrive = _drives.SingleOrDefault(d => d.Name == path.Current);
        FsNode result;
        if (targetDrive != null)
        {
            return targetDrive.FindChild(path);
        }
        return null;
    }
}