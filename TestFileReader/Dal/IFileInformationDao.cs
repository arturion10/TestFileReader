namespace TestFileReader.Bll
{
    public interface IFileInformationDao
    {
        void Add(FileInformation[] files);
        FileInformation[] GetAll();
    }
}