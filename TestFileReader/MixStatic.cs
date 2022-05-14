using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileReader
{
    public class MixStatic
    {
        public List<FileInformation>? FileInformations { get; set; } = new List<FileInformation>();

        public MixStatic(string path)
        {
            var di = new DirectoryInfo(path);
            foreach (var file in di.GetFiles("*.*", SearchOption.AllDirectories).ToList())
            {
                var fi = new FileInformation(file);
                FileInformations.Add(fi);
            }
        }
        public MixStatic()
        {
        }
    }
}
