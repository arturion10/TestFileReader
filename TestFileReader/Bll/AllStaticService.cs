using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestFileReader
{
    public class AllStaticService
    {
        public string Path { get; set; }
        public List<DateClass> Date { get; set; }
        public List<LengthClass> Length { get; set; }
        public List<ExtensionClass> Format { get; set; }

        public AllStaticService(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                throw new Exception("Не является путём");
            }
            Path = path;
            var di = new DirectoryInfo(path);
            var fi = di.GetFiles("*.*", SearchOption.AllDirectories).ToList();
            Date = GetListDate(fi);
            Length = GetListLenght(fi);
            Format = GetListExtension(fi);
        }
        public AllStaticService(string path, List<DateClass> date, List<LengthClass> length, List<ExtensionClass> format)
        {
            Path = path;
            Date = date;
            Length = length;
            Format = format;
        }

        internal List<DateClass> GetListDate(List<FileInfo> date)
        {
            var files = from d in date orderby d.CreationTime select d;
            var filesTop10Date = new List<DateClass>();            
            for (int i = 0; i < 10; i++)
            {
                if (files.Count() <= i)
                {
                    break;
                }
                filesTop10Date.Add(new DateClass(files.ElementAt(i).Name, files.ElementAt(i).CreationTime));
            }            
            return filesTop10Date;
        }

        internal List<LengthClass> GetListLenght(List<FileInfo> lenght)
        {
            var files = from l in lenght orderby l.Length descending select l;
            var filesTop10Length = new List<LengthClass>();
            for (int i = 0; i < 10; i++)
            {
                if (files.Count() <= i)
                {
                    break;
                }
                filesTop10Length.Add(new LengthClass(files.ElementAt(i).Name, files.ElementAt(i).Length));
            }            
            return filesTop10Length;
        }

        internal List<ExtensionClass> GetListExtension(List<FileInfo> extension)
        {
            var files = from a in extension orderby a.Extension select a;
            var filesSortByExtension = new List<ExtensionClass>();
            var format1 = files.ElementAt(0).Extension.ToString();
            var format2 = format1;
            var formatCount = 1;
            foreach (var f in files)
            {
                format1 = f.Extension.ToString();
                if (format1 == format2)
                {
                    formatCount += 1;
                }
                else
                {
                    filesSortByExtension.Add(new ExtensionClass(format2, formatCount));
                    format2 = format1;
                    formatCount = 1;
                }
            }
            filesSortByExtension.Add(new ExtensionClass(format2, formatCount));

            var filesSortByCount = filesSortByExtension.OrderByDescending(p => p.Count);
            var filesTop10Extension = new List<ExtensionClass>();
            for (int i = 0; i < 10; i++)
            {
                if (filesSortByCount.Count() <= i)
                {
                    break;
                }
                filesTop10Extension.Add(filesSortByCount.ElementAt(i));
            }
            return filesTop10Extension;
        }
    }
    

}
