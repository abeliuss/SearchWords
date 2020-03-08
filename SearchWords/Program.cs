using System;
using System.IO.Abstractions;
using System.Linq;

namespace SearchWords
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length>0)
            {
                var path = args[0];
                var search = new SearchProgram(path, new FileSystem());
                Console.WriteLine( $"{search.FilesFoundCount()} files read in directory {path}");
                while (true)
                {
                    var searchWord = GetSearchWord();
                    if (!string.IsNullOrEmpty(searchWord))
                    {
                        DisplayResults(search, searchWord);
                    }
                }
            }

            Console.WriteLine("Path argument need to be supplied");
            Console.ReadKey();
        }

        private static void DisplayResults(SearchProgram search, string searchWord)
        {
            const int topFiles = 10;
            var filesFound = search.SearchWord(searchWord, topFiles).ToList();
            if (filesFound.Any())
            {
                foreach (var file in filesFound)
                {
                    Console.WriteLine($"{file.Name}:{file.Occurrences(searchWord)} occurrences");
                }
            }
            else
            {
                Console.WriteLine("no matches found");
            }
        }

        private static string GetSearchWord()
        {
            Console.WriteLine();
            Console.Write("search> ");
            var searchWord = Console.ReadLine();
            return searchWord;
        }
    }
}
