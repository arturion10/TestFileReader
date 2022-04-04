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

        internal string PrintFormatTable(FileInfo[] Files)
        {
            var Files1 = from a in Files orderby a.Name.Substring(a.Name.LastIndexOf('.')) select a;
            Console.WriteLine("Топ-10 количеству форматов файлов");
            var FormatList = new List<FormatClass>();
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
                    FormatList.Add(new FormatClass(format2, formatCount));
                    format2 = format1;
                    formatCount = 1;
                }
            }
            FormatList.Add(new FormatClass(format2, formatCount));

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
            #region
            //топ 10 по одинаковому формату
            //Console.WriteLine("Топ-10 количеству форматов файлов");
            //var FormatList = new List<string[]>();
            //var format1 = orderByFormatFiles.ElementAt(0).Name.Substring(orderByFormatFiles.ElementAt(0).Name.LastIndexOf('.'));
            //var format2 = format1;
            //int formatCount = 1;
            //foreach (var f in orderByFormatFiles)
            //{
            //    format1 = f.Name.Substring(f.Name.LastIndexOf('.'));
            //    if (format1 == format2)
            //    {
            //        formatCount += 1;
            //    }
            //    else
            //    {
            //        FormatList.Add((string[])(new[] { format2, formatCount.ToString() }));
            //        format2 = format1;
            //        formatCount = 1;
            //    }
            //}
            //    FormatList.Add((string[])(new[] { format2, formatCount.ToString() }));

            //var tableFormat = new ConsoleTable("Формат файлов", "Количество файлов");
            //// TODO: не работает сортировщик по количеству файлов
            //var FormatListSelect = FormatList.OrderBy(p => int.TryParse(p[1], out int number));
            //for (int i = 0; i < 10; i++)
            //{
            //    if (FormatListSelect.Count() <= i)
            //    {
            //        break;
            //    }
            //    tableFormat.AddRow(FormatListSelect.ElementAt(i)[0],
            //                       FormatListSelect.ElementAt(i)[1]);
            //}
            //tableFormat.Write(Format.Default);
            #endregion
        }

        internal string PrintFormatTable(List<FileInfo> Files)
        {
            var Files1 = from a in Files orderby a.Name.Substring(a.Name.LastIndexOf('.')) select a;
            Console.WriteLine("Топ-10 количеству форматов файлов");
            var FormatList = new List<FormatClass>();
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
                    FormatList.Add(new FormatClass(format2, formatCount));
                    format2 = format1;
                    formatCount = 1;
                }
            }
            FormatList.Add(new FormatClass(format2, formatCount));

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

        internal string PrintLengthTable(FileInfo[] Files)
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

        internal string PrintDateTable(FileInfo[] Files)
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
            var Directories = new List<DirectoryInfo>();
            Directories.Add(di);
            var SubDirectories = di.GetDirectories();
            foreach (var directory in SubDirectories)
            {
                Directories.Add(directory);
            }
            var FilesWithChildDirectories = new List<FileInfo>();
            foreach (var directory in Directories)
            {
                FilesWithChildDirectories.AddRange(directory.GetFiles());
            }
            return FilesWithChildDirectories;
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
