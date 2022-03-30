using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileReader
{
    internal class FormatClass
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public FormatClass(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
}
