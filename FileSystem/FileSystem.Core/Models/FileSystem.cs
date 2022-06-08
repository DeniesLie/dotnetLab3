using FileSystem.Core.Enums;
using FileSystem.Core.Helpers;

namespace FileSystem.Core.Models;

public sealed class FileSystem
{
    private static FileSystem? _instance;
    private ICollection<FsNode> _disks = new List<FsNode>();
    private FsContainer _root;
    
    private FileSystem(IEnumerable<char> drivesNames)
    {
        _root = new Root("root");
        
        foreach (var driveName in drivesNames)
        {
            _root.AddChild(new Drive(driveName.ToString()));
        }
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
        var nodeCopyTo = _root.FindChild(fsPath);
        if (nodeCopyTo != null)
        {
            if (nodeCopyTo is FsContainer containerNode)
            {
                return containerNode.AddChild(fsNode);
            }
        }

        return false;
    }

    public bool CopyByValue(FsPath targetPath, FsPath destinationPath)
    {
        var targetNode = _root.FindChild(targetPath);
        var destinationNode = _root.FindChild(destinationPath);
        if (targetNode != null 
            && destinationNode != null 
            && destinationNode is FsContainer destinationContainer)
        {
            var nodeCopy = targetNode.CopyByValue();
            destinationContainer.AddChild(nodeCopy);
            nodeCopy.ParentNode = destinationNode;
            return true;
        }

        return false;
    }

    public IEnumerable<FsNode> ListNodesInDirectory(FsPath path)
    {
        IEnumerable<FsNode> result = new List<FsNode>();
        var fsNode = _root.FindChild(path);
        if (fsNode is FsContainer containerNode)
        {
            result = containerNode.GetChildren();
        }
        return result;
    }
}