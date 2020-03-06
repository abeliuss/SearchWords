using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWords
{
   internal class TextFile
    {
        public TextFile(string file, string content)
        {
            Content = content;
            Name = file;
        }

        public string Name { get; }
        public string Content { get; }
    }
}
