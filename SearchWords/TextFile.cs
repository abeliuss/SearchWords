using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchWords
{
   internal class TextFile
    {
        public TextFile(string fileName, string content)
        {
            Content = content;
            Name = fileName;
        }

        public string Name { get; }
        public string Content { get; }

        internal int Occurrences(string word)
        {
            return Regex.Matches(Content, word).Count;
        }
    }
}
