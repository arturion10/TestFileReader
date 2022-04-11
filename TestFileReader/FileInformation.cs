using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileReader
{
    public class FileInformation
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime DateCreate { get; set; }
        public long Length { get; set; }

        public FileInformation(FileInfo file)
        {
            Name = file.Name;
            Extension = file.Extension;
            DateCreate = file.CreationTime;
            Length = file.Length;
        }
    }
}
