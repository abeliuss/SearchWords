using System;
using System.IO;
using System.IO.Abstractions;

namespace SearchWords
{
    internal class SearchProgram
    {
        private readonly string _path;
        private readonly IFileSystem _fileSystem;

        internal SearchProgram(string path, IFileSystem fileSystem)
        {
            this._path = path;
            _fileSystem = fileSystem;
            var files = fileSystem.Directory.GetFiles(path);




        }

    }
}