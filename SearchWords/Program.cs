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
            var searcher = new SearchProgram(path, new FileSystem());
        }
    }
}
