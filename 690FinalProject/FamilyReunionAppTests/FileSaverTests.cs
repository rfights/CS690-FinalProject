using Xunit;

namespace FamilyReunionAppTests;

using FamilyReunionApp;

public class FileSaverTests
{
    FileSaver FileSaver;
    string testFileName;

    public FileSaverTests()
    {
        testFileName = "test.txt";
        FileSaver = new FileSaver(testFileName);
    }


    [Fact]
    public void Test_FileSaver_Append()
    {
        // Arrange
        var fileSaver = new FileSaver("testfile.txt");
        fileSaver.Clear(); // Ensure the file is empty before appending
        fileSaver.Append("Test data 1");

        // Act
        fileSaver.Append("Test data 1");

        // Assert
        string result = fileSaver.ReadAll();
        Assert.Equal("Test data 1\r\nTest data 1\r\n", result); // Adjusted expected output
    }
}

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
