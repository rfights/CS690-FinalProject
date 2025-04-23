using System;
using System.IO;

namespace FamilyReunionApp
{
    public class FileSaver
    {
        private readonly string _fileName;

        public FileSaver(string fileName)
        {
            _fileName = fileName;
        }

        public void Append(string data)
        {
            File.AppendAllText(_fileName, data + Environment.NewLine);
        }
    }
}