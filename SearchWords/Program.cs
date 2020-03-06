using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];
            var search = new SearchProgram(path, new FileSystem());
            Console.WriteLine( $"{search.FilesFoundCount()} files read in directory {path}");
        }
    }
}
