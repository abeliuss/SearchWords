using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace SearchWords
{
    internal class SearchProgram
    {
        private readonly string _path;
        private readonly IFileSystem _fileSystem;

        private readonly IEnumerable<TextFile> _filesFound;

        internal SearchProgram(string path, IFileSystem fileSystem)
        {
            this._path = path;
            _fileSystem = fileSystem;

            var filesReader = new TextFilesReader(fileSystem);
            _filesFound = filesReader.ReadFiles(path);
        }

        internal int FilesFoundCount()
        {
            return _filesFound.Count();
        }

    }
}