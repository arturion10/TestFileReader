using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileReader
{
    public class FileInformation
    {
        public int Id { get; set; }
        public string Directory { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime DateCreate { get; set; }
        public long Lenght { get; }
        public long Length { get; set; }

        public FileInformation(FileInfo file)
        {
            Directory = file.DirectoryName;
            Name = file.Name;
            Extension = file.Extension;
            DateCreate = file.CreationTime;
            Length = file.Length;
        }
        public FileInformation(string directory, string name, string extension, DateTime dateCreate, long lenght)
        {
            Directory = directory;
            Name = name;
            Extension = extension;
            DateCreate = dateCreate;
            Lenght = lenght;
        }
        public FileInformation()
        {
        }
    }
}
