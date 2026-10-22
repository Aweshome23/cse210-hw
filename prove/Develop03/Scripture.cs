using System;

class Scripture
{
    private Reference _referance;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference refernce, string text)
    {
        _referance = refernce;

        string[] wordArray = text.Split(' ');

        foreach (string wordText in wordArray)
        {
            Word newWord = new Word(wordText);
            _words.Add(newWord);

        }
    }

    public string GetDisplayText()
    {
        string text = _referance.GetDisplayText() + " ";

        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }

        return text;

    }
    public void HideRandomWords(int numberToHide)
    {
        List<int> availableIndexes = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                availableIndexes.Add(i);
            }
        }

        Random random = new Random();

        for (int i = 0; i < numberToHide && availableIndexes.Count > 0; i++)
        {
            int randomIndex = random.Next(availableIndexes.Count);
            int wordIndex = availableIndexes[randomIndex];

            _words[wordIndex].Hide();
            availableIndexes.RemoveAt(randomIndex);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}