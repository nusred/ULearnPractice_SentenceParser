using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();

            int sentenceCount = 0;

            var sentences = text.Split(new char[] { '.', '!', '?', ';', ':', '(', ')' });

            foreach (var sentence in sentences)
            {
                if (sentence.Length != 0)
                {
                    foreach (var list in TextSplit(sentence))
                    {
                        if (!string.IsNullOrEmpty(list.ToString()))
                            sentenceCount++;

                        else continue;
                    }

                    if (sentenceCount != 0)
                    {
                        sentencesList.Add(TextSplit(sentence));
                        sentenceCount = 0;
                    }

                    else continue;
                }

                else continue;
            }

            return sentencesList;
        }

        public static List<string> TextSplit(string sentence)
        {
            var words = new List<string>();
            var word = new StringBuilder();
            sentence += ' ';

            for (int i = 0; i < sentence.Length; i++)
            {
                if (char.IsLetter(sentence[i]) || sentence[i] == '\'')
                {
                    word.Append(sentence[i]);
                }

                else if (!char.IsLetter(sentence[i]) && sentence[i] != '\'' && !string.IsNullOrEmpty(word.ToString()))
                {
                    words.Add(word.ToString().ToLower());
                    word.Remove(0, word.Length);
                    word.Clear();
                }


                else
                    continue;
            }

            return words;
        }
    }
}