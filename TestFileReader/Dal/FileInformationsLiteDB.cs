using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileReader.Dal
{
    public class FileInformationsLiteDB
    {
        public void AddFileDB(FileInformation fi)
        {
            using(var db = new LiteDatabase(@"C:\Users\1\OneDrive\Документы\LiteDB\FileInfo.db"))
            {
                var col = db.GetCollection<FileInformation>("fileInformation");

                col.Insert(fi);
            }
        }

        public FileInformation[] GetAllFiles()
        {
            using (var db = new LiteDatabase(@"C:\Users\1\OneDrive\Документы\LiteDB\FileInfo.db"))
            {
                var col = db.GetCollection<FileInformation>("fileInformation");

                return col.FindAll().ToArray();
            }
        }
    }
}
