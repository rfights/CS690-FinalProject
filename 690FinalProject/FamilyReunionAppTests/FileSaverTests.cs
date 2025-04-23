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
        FileSaver.Append("Test data 1");
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("Test data 1" + Environment.NewLine, contentFromFile);
    }
}
