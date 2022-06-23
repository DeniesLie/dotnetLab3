using FileSystem.Api;

var controller = new FileSystemController(new []{'C', 'D'});

controller.AddDirectory("C", "dir1");
controller.AddFile("C/dir1", "hello.txt", "hello world");
controller.AddDirectory("C/dir1", "dir2");
controller.AddFile("C/dir1/dir2", "hello2.txt", "hello other world");

Console.WriteLine("Elements in C/dir1:");
foreach (var el in controller.ListItemsInDirectory("C/dir1"))
    Console.Write($"{el}, ");
Console.WriteLine();

Console.WriteLine("Elements in D:");
foreach (var el in controller.ListItemsInDirectory("D"))
    Console.Write($"{el}, ");
Console.WriteLine();

Console.WriteLine("Copying dir1 to 'D' drive...");
controller.CopyByValue("C/dir1", "D");

Console.WriteLine("Elements in D drive:");
foreach (var el in controller.ListItemsInDirectory("D"))
    Console.Write($"{el}, ");
Console.WriteLine();

Console.WriteLine("Elements in root/D/dir1:");
foreach (var el in controller.ListItemsInDirectory("D/dir1"))
    Console.Write($"{el}, ");

