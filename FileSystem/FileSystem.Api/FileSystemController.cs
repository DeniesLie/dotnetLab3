using FileSystem.Core.Models;
using FileSystem.Core.Helpers;

using Directory = FileSystem.Core.Models.Directory;
using File = FileSystem.Core.Models.File;

namespace FileSystem.Api;

public class FileSystemController
{
    private readonly Core.Models.FileSystem _fileSystem;

    public FileSystemController(IEnumerable<char> drives)
    {
        _fileSystem = Core.Models.FileSystem.GetInstance(drives);
    }

    public bool AddDirectory(string path, string dirName)
    {
        return _fileSystem.AddFsNode(FsPath.Build(path),new Directory(dirName));
    }

    public bool AddDrive(string path, string driveName)
    {
        return _fileSystem.AddFsNode(FsPath.Build(path),new Drive(driveName));
    }

    public bool AddFile(string path, string fileName, string content)
    {
        return _fileSystem.AddFsNode(FsPath.Build(path),new File(fileName, content));
    }

    public IEnumerable<string> ListFilesInDirectory(string path)
    {
        return _fileSystem.ListNodesInDirectory(FsPath.Build(path))
            .Select(node => node.Name);
    }

    public bool CopyByValue(string targetPath, string destinationPath)
    {
        return _fileSystem.CopyByValue(FsPath.Build(targetPath), FsPath.Build(destinationPath));
    }
}