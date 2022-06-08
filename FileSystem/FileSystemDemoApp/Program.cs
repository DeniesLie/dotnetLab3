using FileSystem.Api;

var controller = new FileSystemController(new []{'C', 'D'});

controller.AddDirectory("root/C", "dir1");
controller.AddFile("root/C/dir1", "hello.txt", "hello world");
controller.AddDirectory("root/C/dir1", "dir2");
controller.AddFile("root/C/dir1/dir2", "hello2.txt", "hello other world");

Console.WriteLine("Elements in root/C/dir1:");
foreach (var el in controller.ListFilesInDirectory("root/C/dir1"))
    Console.Write($"{el}, ");
Console.WriteLine();

Console.WriteLine("Elements in root/D:");
foreach (var el in controller.ListFilesInDirectory("root/D"))
    Console.Write($"{el}, ");
Console.WriteLine();

Console.WriteLine("Copying dir1 to 'D' drive...");
controller.CopyByValue("root/C/dir1", "root/D");

Console.WriteLine("Elements in root/D:");
foreach (var el in controller.ListFilesInDirectory("root/D"))
    Console.Write($"{el}, ");
Console.WriteLine();

Console.WriteLine("Elements in root/D/dir1:");
foreach (var el in controller.ListFilesInDirectory("root/D/dir1"))
    Console.Write($"{el}, ");

