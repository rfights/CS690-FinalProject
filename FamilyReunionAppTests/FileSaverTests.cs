using Xunit;
using System.IO;
using System;

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
        if (File.Exists(testFileName))
        {
            File.Delete(testFileName); // Ensure the file is clean before the test
        }

        // Act
        FileSaver.Append("Test data 1");
        var contentFromFile = File.ReadAllText(testFileName);

        // Assert
        Assert.Equal("Test data 1" + Environment.NewLine, contentFromFile);

        // Cleanup
        File.Delete(testFileName); // Clean up after the test
    }
}
