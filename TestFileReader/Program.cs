using ConsoleTables;
using TestFileReader;
using System.Linq;

var path = Path.GetFullPath(Console.ReadLine());
var di = new DirectoryInfo(path); //@"C:\Users\1\OneDrive\Изображения"
var Files = di.GetFiles();
string FileSave = "DirectoryInfo.txt";

var consoleTableTop10 = new ConsoleTableTop10();
var FilesWithChildDirectories = consoleTableTop10.GetAllDirectories(di);
var FilesWithException = consoleTableTop10.EnumerateFilesDeepIgnoringAccessException(di).ToList();
var IndifityAfterInform = "8cbee587-4890-446c-8611-2b3b983b02f3";


using (StreamWriter writter = new StreamWriter(FileSave, true))
{
    if (FileSave.Contains(path))
    {
        GetInfoTxt(path, FileSave, IndifityAfterInform);
    }
    else
    {
        writter.WriteLine(path);
        writter.WriteLine(consoleTableTop10.PrintDateTable(FilesWithException));
        writter.WriteLine(consoleTableTop10.PrintFormatTable(FilesWithException));
        writter.WriteLine(consoleTableTop10.PrintLengthTable(FilesWithException));
        writter.WriteLine(IndifityAfterInform);
    }
}

void GetInfoTxt(string path, string fileName, string IndifityAfterInform)
{
    using (StreamReader sr = new StreamReader(fileName))
    {
        var line = sr.ReadLine();
        while(path != line)
        {
            
        }
        while (IndifityAfterInform != sr.ReadLine())
        {
            Console.WriteLine(sr.ReadLine());
        }
    }
}

//consoleTableTop10.PrintDateTable(Files);
//consoleTableTop10.PrintDateTable(FilesWithChildDirectories);
//consoleTableTop10.PrintDateTable(FilesWithException);
//consoleTableTop10.PrintFormatTable(Files);
//consoleTableTop10.PrintFormatTable(FilesWithChildDirectories);
//consoleTableTop10.PrintFormatTable(FilesWithException);
//consoleTableTop10.PrintLengthTable(Files);
//consoleTableTop10.PrintLengthTable(FilesWithChildDirectories);
//consoleTableTop10.PrintLengthTable(FilesWithException);


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
