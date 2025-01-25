using System;
using System.Collections.Generic;
using System.Linq;

class ScriptureMemorizer
{
    private List<string> _scriptureWords;
    private int _totalWordsRemoved = 0;

    public ScriptureMemorizer(Scripture scripture)
    {
        _scriptureWords = scripture.GetText().Split(' ').ToList();
    }

    public void RemoveWordsFromText()
    {
        int numWordsToRemove = 3;
        int wordsRemoved = 0;
        Random random = new Random();

        while (wordsRemoved < numWordsToRemove && HasWordsLeft())
        {
            int randomIndex = random.Next(_scriptureWords.Count);
            if (!_scriptureWords[randomIndex].Contains("_"))
            {
                _scriptureWords[randomIndex] = new string('_', _scriptureWords[randomIndex].Length);
                wordsRemoved++;
                _totalWordsRemoved++;
            }
        }
    }

    public bool HasWordsLeft()
    {
        return _scriptureWords.Any(word => !word.Contains("_"));
    }

    public override string ToString()
    {
        return string.Join(" ", _scriptureWords);
    }
}