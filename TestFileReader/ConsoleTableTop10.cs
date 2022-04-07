using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileReader
{
    internal class ConsoleTableTop10
    {

        internal string PrintFormatTable(List<FileInfo> Files)
        {
            var Files1 = from a in Files orderby a.Name.Substring(a.Name.LastIndexOf('.')) select a;
            Console.WriteLine("Топ-10 количеству форматов файлов");
            var FormatList = new List<ExtensionClass>();
            var format1 = Files1.ElementAt(0).Extension.ToString(); //Name.Substring(orderByFormatFiles.ElementAt(0).Name.LastIndexOf('.'));
            var format2 = format1;
            var formatCount = 1;
            foreach (var f in Files1)
            {
                format1 = f.Extension.ToString();
                if (format1 == format2)
                {
                    formatCount += 1;
                }
                else
                {
                    FormatList.Add(new ExtensionClass(format2, formatCount));
                    format2 = format1;
                    formatCount = 1;
                }
            }
            FormatList.Add(new ExtensionClass(format2, formatCount));

            var tableFormat = new ConsoleTable("Формат файлов", "Количество файлов");
            var FormatListSelect = FormatList.OrderByDescending(p => p.Count);
            for (int i = 0; i < 10; i++)
            {
                if (FormatListSelect.Count() <= i)
                {
                    break;
                }
                tableFormat.AddRow(FormatListSelect.ElementAt(i).Name,
                                    FormatListSelect.ElementAt(i).Count);
            }
            tableFormat.Write(Format.Default);
            return tableFormat.ToString();
        }

        internal string PrintLengthTable(List<FileInfo> Files)
        {
            var Files1 = from l in Files orderby l.Length descending select l;
            var tableLength = new ConsoleTable("Название файла", "Размер файла");
            Console.WriteLine("Топ-10 по объему файлов");
            for (int i = 0; i < 10; i++)
            {
                if (Files1.Count() <= i)
                {
                    break;
                }
                tableLength.AddRow(Files1.ElementAt(i).Name,
                                   Files1.ElementAt(i).Length);
            }
            tableLength.Write(Format.Default);
            return tableLength.ToString();
        }


        internal string PrintDateTable(List<FileInfo> Files)
        {
            var Files1 = from d in Files orderby d.CreationTime select d;
            var tableDate = new ConsoleTable("Название файла", "Дата появления файла");
            Console.WriteLine("Топ-10 по возрасту файла");
            for (int i = 0; i < 10; i++)
            {
                if (Files1.Count() <= i)
                {
                    break;
                }
                tableDate.AddRow(Files1.ElementAt(i).Name,
                                 Files1.ElementAt(i).CreationTime);
            }
            tableDate.Write(Format.Default);
            return tableDate.ToString();
        }

        internal List<FileInfo> GetAllDirectories(DirectoryInfo di)
        {
            return di.GetFiles("*.*", SearchOption.AllDirectories).ToList();
        }

        internal IEnumerable<FileInfo> EnumerateFilesDeepIgnoringAccessException(DirectoryInfo root)
        {
            var localResult = new List<FileInfo>();
            try
            {
                localResult = root.EnumerateFiles().ToList();
            }
            catch (UnauthorizedAccessException)
            {
                yield break;
            }

            foreach (var fi in localResult)
                yield return fi;

            foreach (var di in root.EnumerateDirectories())
            {
                foreach (var fi in EnumerateFilesDeepIgnoringAccessException(di))
                    yield return fi;
            }
        }
    }
}
