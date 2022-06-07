using FileSystem.Core.Helpers;
using FileSystem.Core.Models;
using Path = FileSystem.Core.Helpers.Path;

char[] disks = new[] {'C', 'D', 'F'};
var fs = FileSystem.Core.Models.FileSystem.GetInstance(disks);

fs.AddDirectory(new Path("D"), "rootDir");
fs.AddDirectory(new Path("D").Add("rootDir"), "TestDir");
fs.AddFile(new Path("D/rootDir/TestDir"), "hello.txt", "Hello world");
fs.CopyByValue(new Path("D/rootDir/TestDir/hello.txt"), new Path("D/rootDir"));
