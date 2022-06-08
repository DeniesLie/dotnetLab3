using System.Collections;

namespace FileSystem.Core.Helpers;

public class FsPath : IEnumerator<string>
{
    private List<string> _pathCollection = new List<string>();
    private int _pathCount = 0;

    public FsPath(string basePath)
    {
        Value = basePath;
    }

    public static FsPath Build(string basePath)
    {
        return new FsPath(basePath);
    } 
    
    public string Value
    {
        get => '/' + string.Join('/', _pathCollection);
        set
        {
            _pathCollection = value.Split('/').ToList();
        }
    }

    public char DriveName
    {
        get => char.Parse(_pathCollection[0]);
        set => _pathCollection[0] = value.ToString();
    }

    public FsPath Add(string nodeName)
    {
        _pathCollection.Add(nodeName);
        return this;
    }

    public bool MoveNext()
    {
        if (_pathCount == _pathCollection.Count - 1)
            return false;
        _pathCount++;
        return true;
    }

    public void Reset()
    {
        _pathCount = 0;
    }

    public string Current
    {
        get => _pathCollection[_pathCount];
    }

    object IEnumerator.Current => Current;

    public void Dispose()
    { }
}