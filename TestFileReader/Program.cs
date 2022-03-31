using ConsoleTables;
using TestFileReader;
using System.Linq;

var di = new DirectoryInfo(@"C:\Users\1\OneDrive\Изображения");
var Files = di.GetFiles();


var consoleTableTop10 = new ConsoleTableTop10();
var FilesWithChildDirectories = consoleTableTop10.GetAllDirectories(di);
var FilesWithException = consoleTableTop10.EnumerateFilesDeepIgnoringAccessException(di).ToList();

consoleTableTop10.PrintDateTable(Files);
consoleTableTop10.PrintDateTable(FilesWithChildDirectories);
consoleTableTop10.PrintDateTable(FilesWithException);
consoleTableTop10.PrintFormatTable(Files);
consoleTableTop10.PrintFormatTable(FilesWithChildDirectories);
consoleTableTop10.PrintFormatTable(FilesWithException);
consoleTableTop10.PrintLengthTable(Files);
consoleTableTop10.PrintLengthTable(FilesWithChildDirectories);
consoleTableTop10.PrintLengthTable(FilesWithException);


//static void GetFilesException(string path)
//{
//    try
//    {
//        DirectoryInfo dir = new DirectoryInfo(path);
//    }
//    catch (FileLoadException e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}
