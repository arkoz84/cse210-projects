using System;

public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        foreach (string word in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            _words.Add(new Word(word));
        }
    }
    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = Random.Shared.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {text}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}

