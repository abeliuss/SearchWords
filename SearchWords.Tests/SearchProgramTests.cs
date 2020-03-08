using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace SearchWords.Tests
{
    public class SearchProgramTests
    {
        [Fact]
        public void When_Read_WithFiles_Should_Count_Files_Read()
        {
            //Arrange
            string[] files = { "file1", "file2" };
            var mockFilesystem = Substitute.For<IFileSystem>();
            mockFilesystem.Directory.GetFiles(Arg.Any<string>(), Arg.Any<string>()).Returns(files);

            //Act
            var search = new SearchProgram("", mockFilesystem);

            //Assert
            search.FilesFoundCount().Should().Be(2);
        }

        [Fact]
        public void When_Read_WithoutFiles_Should_Count_NoFiles_Read()
        {
            //Arrange
            string[] files = { };
            var mockFilesystem = Substitute.For<IFileSystem>();
            mockFilesystem.Directory.GetFiles(Arg.Any<string>(), Arg.Any<string>()).Returns(files);

            //Act
            var search = new SearchProgram("", mockFilesystem);

            //Assert
            search.FilesFoundCount().Should().Be(0);
        }

        [Fact]
        public void When_SearchWords_Should_Found_Words()
        {
            //Arrange
            var mockFilesystem = Substitute.For<IFileSystem>();
            const string file1Name = "file1";
            const string content1 = "word1 word2 word1";
            mockFilesystem.File.ReadAllText(file1Name).Returns(content1);

            const string file2Name = "file2";
            const string content2 = "word2 word2 word2";
            mockFilesystem.File.ReadAllText(file2Name).Returns(content2);

            const string file3Name = "file3";
            const string content3 = "word1 word2 word2";
            mockFilesystem.File.ReadAllText(file3Name).Returns(content3);

            string[] files = { file1Name, file2Name, file3Name };
           
            mockFilesystem.Directory.GetFiles(Arg.Any<string>(), Arg.Any<string>()).Returns(files);
         
            var search = new SearchProgram("", mockFilesystem);
            
            //Act
            var filesFound = search.SearchWord("word2", 10).ToList();

            //Assert
            filesFound.Count.Should().Be(3);

            filesFound[0].Name.Should().Be(file2Name);
            filesFound[0].Occurrences("word2").Should().Be(3);

            filesFound[1].Name.Should().Be(file3Name);
            filesFound[1].Occurrences("word2").Should().Be(2);

            filesFound[2].Name.Should().Be(file1Name);
            filesFound[2].Occurrences("word2").Should().Be(1);
        }

        [Fact]
        public void When_SearchWordsToFiles_Should_Found_WordsOnTopFiles()
        {
            //Arrange
            var mockFilesystem = Substitute.For<IFileSystem>();
            const string file1Name = "file1";
            const string content1 = "word1 word2 word1";
            mockFilesystem.File.ReadAllText(file1Name).Returns(content1);

            const string file2Name = "file2";
            const string content2 = "word2 word2 word2";
            mockFilesystem.File.ReadAllText(file2Name).Returns(content2);

            const string file3Name = "file3";
            const string content3 = "word1 word2 word2";
            mockFilesystem.File.ReadAllText(file3Name).Returns(content3);

            string[] files = { file1Name, file2Name, file3Name };

            mockFilesystem.Directory.GetFiles(Arg.Any<string>(), Arg.Any<string>()).Returns(files);

            var search = new SearchProgram("", mockFilesystem);

            //Act
            var filesFound = search.SearchWord("word2", 2).ToList();

            //Assert
            filesFound.Count.Should().Be(2);

            filesFound[0].Name.Should().Be(file2Name);
            filesFound[0].Occurrences("word2").Should().Be(3);

            filesFound[1].Name.Should().Be(file3Name);
            filesFound[1].Occurrences("word2").Should().Be(2);
        }
    }
}
