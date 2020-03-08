using System.Text.RegularExpressions;

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
