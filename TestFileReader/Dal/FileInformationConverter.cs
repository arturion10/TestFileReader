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
                    stringsInfo.Append($"{file.Name} | {file.Extension} | {file.Length} | {file.Directory} | {file.DateCreate.ToString("G")}\n");
                }
            }
            return stringsInfo.ToString();
        }

        public FileInformation[] ConvertStringToArray(string filesStrings)
        {

            string[] mixArr = filesStrings.Split('|');
            var result = new FileInformation[mixArr.Length/4];

            for(int i = 0; i < mixArr.Length / 4; i++)
            {
                result[i] = new FileInformation(mixArr[i*4], 
                                                mixArr[i*4+1], 
                                                mixArr[i * 4 + 2], 
                                                DateTime.ParseExact(mixArr[i * 4 + 3], "G", CultureInfo.GetCultureInfo("ru-RU")),
                                                long.Parse(mixArr[i*4 + 4]));
            }
            return result;
        }
    }
}
