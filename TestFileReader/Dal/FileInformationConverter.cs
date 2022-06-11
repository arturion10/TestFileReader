using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileReader.Dal
{
    public class FileInformationConverter
    {
        public FileInformation[] files;

        public string ConvertToString(FileInformation[] files)
        {
            var stringsInfo = new StringBuilder();
            if (files != null)
            {
                foreach(FileInformation file in files)
                {
                    stringsInfo.Append($"{file.Name}|{file.Extension}|{file.Length}|{file.Directory}|{file.DateCreate.ToString("G")}\n");
                }
            }
            return stringsInfo.ToString();
        }

        public FileInformation[] ConvertStringToArray(string filesStrings)
        {

            string[] mixArr = filesStrings.Split('|');
            var result = new FileInformation[mixArr.Length/5];

            for(int i = 0; i < mixArr.Length / 5; i++)
            {
                result[i] = new FileInformation(mixArr[i * 5], 
                                                mixArr[i * 5 + 1], 
                                                mixArr[i * 5 + 2], 
                                                DateTime.ParseExact(mixArr[i * 5 + 3], "G", CultureInfo.GetCultureInfo("ru-RU")),
                                                long.Parse(mixArr[i * 5 + 4]));
            }
            return result;
        }
    }
}
