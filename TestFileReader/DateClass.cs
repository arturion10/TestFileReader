using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileReader
{
    [Serializable]
    public class DateClass
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public DateClass(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }
    }
}

