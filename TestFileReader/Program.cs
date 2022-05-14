using ConsoleTables;
using TestFileReader;
using System.Linq;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Newtonsoft.Json;


PrintAllFiles();
ReadFileInformation();

//@"C:\Users\1\OneDrive\Изображения"
//@"C:\Users\1\OneDrive\Документы"
var path = @"C:\Users\1\OneDrive\Документы";
var outPath = "data.json";
var mixStat = new MixStatic(path);
var dataSer = JsonConvert.SerializeObject(mixStat, Formatting.Indented);
File.WriteAllText(outPath, dataSer);
var dataDeser = JsonConvert.DeserializeObject<MixStatic>(File.ReadAllText(outPath));

void PrintAllFiles()
{
    var outPath = "data.json";
    var dataDeser = JsonConvert.DeserializeObject<MixStatic>(File.ReadAllText(outPath));
    var tableData = new ConsoleTable("Название файла", /*"Путь файла",*/ "Дата создания", "Длина файла", "Расширение файла"); // Путь файла занимает слишком много места и таблица комкается.
    Console.WriteLine("Все данные по файлам");
    foreach (var f in dataDeser.FileInformations)
    {
        tableData.AddRow(f.Name,
                         //f.Directory,
                         f.DateCreate,
                         f.Length,
                         f.Extension);
    }
    tableData.Write(Format.Default);
}


void ReadFileInformation()
{
    var outPath = "data.json";
    var dataDeser = JsonConvert.DeserializeObject<MixStatic>(File.ReadAllText(outPath));
    var path = Console.ReadLine();
    var pathData = dataDeser.FileInformations
                   .Where(x => x.Directory.StartsWith(path))
                   .ToList();
    var newData = new MixStatic(path);
    if (pathData.Count == 0)
    {
        dataDeser.FileInformations.AddRange(newData.FileInformations);

        var MixStatJson = JsonConvert.SerializeObject(dataDeser, Formatting.Indented);
        File.WriteAllText(outPath, MixStatJson);
        ReaderToTable(newData);
    }
    else
    {
        ReaderToTable(newData);
    }
}

void ReaderToTable(MixStatic Data)
{
    {
        var tableData = new ConsoleTable("Название файла", "Путь файла", "Дата создания", "Длина файла", "Расширение файла");
        Console.WriteLine("Все данные по файлам");
        foreach (var f in Data.FileInformations)
        {
            tableData.AddRow(f.Name,
                             f.Directory,
                             f.DateCreate,
                             f.Length,
                             f.Extension);
        }
        tableData.Write(Format.Default);
    }
}
