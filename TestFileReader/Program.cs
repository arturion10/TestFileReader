using ConsoleTables;
using TestFileReader;
using System.Linq;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Newtonsoft.Json;

//@"C:\Users\1\OneDrive\Изображения"
var path = @"C:\Users\1\OneDrive\Изображения";

var mixStat = new MixStatic(path);

var mixStatJson = JsonConvert.SerializeObject(mixStat, Formatting.Indented);
Console.WriteLine(mixStatJson);

//var jsonDoc = JsonDocument.Parse(mixStatJson);

//var elements = from o in jsonDoc.RootElement.EnumerateArray()
//               let name = o.GetProperty("Name").GetString()
//               let extension = o.GetProperty("Extension").GetString()
//               let dateCreate = o.GetProperty("DateCreate").GetString()
//               let length = o.GetProperty("Length").GetString()
//               let str = $"{name} {extension} {dateCreate} {length}"
//               select str;

//var result = string.Join("\n", elements);

//var jsonDoc = JsonConvert.DeserializeObject<MixStatic>(mixStatJson);

//foreach(var item in jsonDoc.FileInformations)
//{
//    Console.WriteLine($"{item.Name.ToString()} {item.Extension} {item.DateCreate.ToShortDateString()} {item.Length} ");
//}
