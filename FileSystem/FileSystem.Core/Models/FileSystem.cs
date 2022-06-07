namespace FileSystem.Core.Models;

public sealed class FileSystem
{
    private static FileSystem? _instance;
    private ICollection<Disk> _disks = new List<Disk>();

    private FileSystem(IEnumerable<char> disksNames)
    {
        foreach (var disksName in disksNames)
        {   
            AddDisk(disksName);
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

    public void AddDisk(char diskName)
        => _disks.Add(new Disk(diskName.ToString()));

    public bool AddDirectory(Helpers.Path path, string dirName)
        => AddFsNode(path, new Directory(dirName));

    public bool AddFile(Helpers.Path path, string fileName, string content)
        => AddFsNode(path, new File(fileName, content));

    public bool CopyByValue(Helpers.Path targetPath, Helpers.Path destinationPath)
    {
        var targetNode = FindNode(targetPath);
        var destinationNode = FindNode(destinationPath);
        if (targetNode != null && destinationNode != null)
        {
            var nodeCopy = targetNode.CopyByValue();
            destinationNode.AddChild(nodeCopy);
            nodeCopy.ParentNode = destinationNode;
            return true;
        }

        return false;
    }
    
    private bool AddFsNode(Helpers.Path path, FsNode fsNode)
    {
        var parentNode = FindNode(path);
        if (parentNode != null)
            return parentNode.AddChild(fsNode);
        
        return false;
    }

    private FsNode? FindNode(Helpers.Path path)
    {
        var disk = _disks.SingleOrDefault(d => d.Name == path.DiskName.ToString());
        if (disk != null)
        {
            return disk.FindChild(path);
        }
        return null;
    }
}