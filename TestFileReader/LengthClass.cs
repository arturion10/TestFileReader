using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestFileReader
{
    [Serializable]
    public class LengthClass
    {
        public string Name { get; set; }
        public long Length { get; set; }

        public LengthClass(string name, long length)
        {
            Name = name;
            Length = length;
        }
    }
}
