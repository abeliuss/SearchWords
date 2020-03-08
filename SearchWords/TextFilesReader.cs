using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;

namespace SearchWords
{
    internal class TextFilesReader
    {
        private readonly IFileSystem _fileSystem;

        internal TextFilesReader( IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        internal IEnumerable<TextFile> ReadFiles(string path)
        {
            var textFiles = new List<TextFile>();
            const string searchPattern = "*.txt";
            var files = _fileSystem.Directory.GetFiles(path, searchPattern);

            foreach (var file in files)
            {
                try
                {
                    var content = ReadFileContent(Path.Combine(path, file));
                    var textFile = new TextFile(file, content);
                    textFiles.Add(textFile);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return textFiles;
        }

        private string ReadFileContent(string path)
        {
           return  _fileSystem.File.ReadAllText(path);

        }
    }
}
