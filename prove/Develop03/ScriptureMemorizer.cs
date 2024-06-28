using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(string book, int chapter, int verse, string text)
    {
        _reference = new Reference(book, chapter, verse);
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public Scripture(string book, int chapter, int startVerse, int endVerse, string text)
    {
        _reference = new Reference(book, chapter, startVerse, endVerse);
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        List<Word> wordsToHide = _words.Where(w => !w.IsHidden()).OrderBy(w => rand.Next()).Take(numberToHide).ToList();
        
        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string wordsText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{referenceText} {wordsText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }


public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}


public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

 
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

  
    public string GetDisplayText()
    {
        if (_verse == _endVerse)
            return $"{_book} {_chapter}:{_verse}";
        else
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}
}