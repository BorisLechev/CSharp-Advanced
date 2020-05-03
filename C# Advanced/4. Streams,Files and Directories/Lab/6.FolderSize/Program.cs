using System.IO;

namespace _6.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
        //https://github.com/Dantte169/C-Advanced-Course/blob/master/09.%20Streams%20Files%20And%20Directories%20-%20Lab/Lab/06.%20FolderSize/FolderSize.cs
            string[] filesInDirectory = Directory.GetFiles("../../../TestFolder");

            double sum = 0;

            foreach (var file in filesInDirectory)
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;

            File.WriteAllText("output.txt", sum.ToString());
        }
    }
}
