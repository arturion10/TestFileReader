using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileReader
{
    public class ExtensionClass
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public ExtensionClass(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
}