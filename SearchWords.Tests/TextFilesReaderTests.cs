using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Net.Mime;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace SearchWords.Tests
{
    public class TextFilesReaderTests
    {
        [Fact]
        public void When_ReadFiles_Should_FoundTheFiles_Read()
        {
            //Arrange
            const string file1Name = "file1";
            const string file2Name = "file2";
            string[] files= { file1Name, file2Name };
            const string content ="content of file";
            var mockFilesystem = Substitute.For<IFileSystem>();
            mockFilesystem.Directory.GetFiles(Arg.Any<string>(), Arg.Any<string>()).Returns(files);
            mockFilesystem.File.ReadAllText(Arg.Any<string>()).Returns(content);
            
            var filesReader = new TextFilesReader(mockFilesystem);

            //Act
            var resultFiles = filesReader.ReadFiles("").ToList();

            //Assert
            resultFiles.Count().Should().Be(2);
            var file1 = resultFiles.Single(x => x.Name == file1Name);
            file1.Content.Should().Be(content);
            var file2 = resultFiles.Single(x => x.Name == file2Name);
            file2.Content.Should().Be(content);
        }

        [Fact]
        public void When_ReadFilesWithExceptions_Should_DiscardTheProblematicFiles_Read()
        {
            //Arrange
            const string file1Name = "file1";
            const string file2Name = "file2";
            string[] files = { file1Name, file2Name };
            const string content = "content of file";
            var mockFilesystem = Substitute.For<IFileSystem>();
            mockFilesystem.Directory.GetFiles(Arg.Any<string>(), Arg.Any<string>()).Returns(files);
            mockFilesystem.File.ReadAllText(file1Name).Returns(x=> throw new FileLoadException());
            mockFilesystem.File.ReadAllText(file2Name).Returns(content);

            var filesReader = new TextFilesReader(mockFilesystem);

            //Act
            var resultFiles = filesReader.ReadFiles("").ToList();

            //Assert
            resultFiles.Count().Should().Be(1);
            var file2 = resultFiles.Single(x => x.Name == file2Name);
            file2.Content.Should().Be(content);
        }

    }
}
