using ConsoleTables;
using TestFileReader;
using System.Linq;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

//@"C:\Users\1\OneDrive\Изображения"

var statistick = new AllStatic(@"C:\Users\1\OneDrive\Изображения");
using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
{
    await JsonSerializer.SerializeAsync<AllStatic>(fs, statistick);
}

using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
{
    var statisticGet = await JsonSerializer.DeserializeAsync<AllStatic>(fs);
    foreach(var s in statisticGet.Length)
    {
        Console.WriteLine($"{s.Name} - {s.Length}");
    }
}

