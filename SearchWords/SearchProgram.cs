using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;

namespace SearchWords
{
    internal class SearchProgram
    {
        private readonly IEnumerable<TextFile> _filesFound;

        internal SearchProgram(string path, IFileSystem fileSystem)
        {
           var filesReader = new TextFilesReader(fileSystem);
            _filesFound = filesReader.ReadFiles(path);
        }

        internal int FilesFoundCount()
        {
            return _filesFound.Count();
        }

        internal IEnumerable<TextFile> SearchWord(string searchWord, int topFilesNumber)
        {
            return _filesFound.OrderByDescending(x => x.Occurrences(searchWord)).
                Take(topFilesNumber).TakeWhile(x => x.Occurrences(searchWord) > 0);
        }
    }
}