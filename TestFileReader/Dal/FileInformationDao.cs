using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileReader.Bll
{
    public class FileInformationDao : IFileInformationDao
    {
        private readonly string _outPath;

        public FileInformationDao(string outPath)
        {
            _outPath = outPath;
        }

        public FileInformation[] GetAll()
        {
            var result = Array.Empty<FileInformation>();
            if (File.Exists(_outPath))
                result = JsonConvert.DeserializeObject<FileInformation[]>(File.ReadAllText(_outPath));

            return result ?? Array.Empty<FileInformation>();
        }

        public void Add(FileInformation[] files)
        {
            var data = GetAll().Concat(files).ToArray();
            var dataSer = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_outPath, dataSer);
        }
    }
}
