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
    }
}
