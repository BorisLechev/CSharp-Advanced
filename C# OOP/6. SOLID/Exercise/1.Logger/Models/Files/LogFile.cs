using _1.Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _1.Logger.Models.Files
{
    public class LogFile : IFile
    {
        private const string CURRENT_DIRECTORY = "\\logs\\";

        private const string CURRENT_FILE = "logs.txt";

        private string currentPath;

        private IIOManager iOManager;

        public LogFile()
        {
            this.iOManager = new IOManagement(CURRENT_DIRECTORY, CURRENT_FILE);
            this.currentPath = this.iOManager.CurrentFilePath();
            this.iOManager.EnsureDirectoryAndFileExist();
        }

        public string Path => this.currentPath

        public ulong Size => GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            throw new NotImplementedException();
        }

        private ulong GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            ulong size = (ulong)text
                .ToCharArray()
                .Where(c => char.IsLetter(c))
                .Sum(c => (int)c);

            return size;
        }
    }
}
