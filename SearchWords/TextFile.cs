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

        private string _lastWord;
        private int _lastOccurrences;

        public string Name { get; }
        public string Content { get; }

        internal int Occurrences(string word)
        {
            if (word == _lastWord)
            {
                return _lastOccurrences;
            }
            _lastOccurrences = Regex.Matches(Content, word).Count;
            _lastWord = word;

            return _lastOccurrences;
        }
    }
}
