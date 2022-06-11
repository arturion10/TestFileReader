using TestFileReader;
using TestFileReader.Dal;

namespace TestProject1
{
    public class FileInformationConverterTest
    {
        [Fact]
        public void ConvertToString_IsConvert()
        {
            //Arrange
            var path1 = @"C:\Users\1\source\repos\CSharp\Ментор\TestFileReader\TestFileReader\TestFiles";
            var path2 = @"C:\Users\1\source\repos\CSharp\Ментор\TestFileReader\TestFileReader\TestFiles";
            FileInformation[] files = {new FileInformation(new FileInfo(@"C:\Users\1\source\repos\CSharp\Ментор\TestFileReader\TestFileReader\TestFiles\1.png")),
                                       new FileInformation(new FileInfo(@"C:\Users\1\source\repos\CSharp\Ментор\TestFileReader\TestFileReader\TestFiles\2.png"))};
            var fileToConvert = new FileInformationConverter();

            //Act
            var filesTest = fileToConvert.ConvertToString(files);

            //Assert
            Assert.Equal(filesTest, $"1.png|.png|171268|{path1}|09.06.2022 16:15:53\n" +
                                    $"2.png|.png|249231|{path1}|09.06.2022 16:15:53\n");
        }

        [Fact]
        public void ConvertStringToArray_IsConvert()
        {
            var path1 = @"C:\Users\1\source\repos\CSharp\Ментор\TestFileReader\TestFileReader\TestFiles";
            var SerString = $"1.png|.png|171268|{path1}|09.06.2022 16:15:53\n" +
                            $"2.png|.png|249231|{path1}|09.06.2022 16:15:53\n";
            var fileToConvert = new FileInformationConverter();

            FileInformation[] files = {new FileInformation(new FileInfo(@"C:\Users\1\source\repos\CSharp\Ментор\TestFileReader\TestFileReader\TestFiles\1.png")),
                                       new FileInformation(new FileInfo(@"C:\Users\1\source\repos\CSharp\Ментор\TestFileReader\TestFileReader\TestFiles\2.png"))};
            var DesFiles = fileToConvert.ConvertStringToArray(SerString);

            Assert.Equal(DesFiles[0].Name, files[0].Name);
        }
    }
}