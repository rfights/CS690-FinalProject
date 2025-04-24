using System;
using System.IO;

public class FileSaver
{
    private string fileName;

    public FileSaver(string fileName)
    {
        this.fileName = fileName;
    }

    public void Append(string data)
    {
        File.AppendAllText(fileName, data + Environment.NewLine);
    }

    public string ReadAll()
    {
        return File.ReadAllText(fileName);
    }

    public void Clear()
    {
        File.WriteAllText(fileName, string.Empty);
    }
}