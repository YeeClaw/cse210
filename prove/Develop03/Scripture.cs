public class Scripture
{
    // For the purpose of this exercise, I will NOT be using auto implemented properties as to make the measures
    // of encapsulation more explicit.

    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        foreach (var word in text.Split(" "))
        {
            _words.Add(new Word(word));
        }
    }

    /// <summary>
    /// Select random words from the text and change their state to hidden.
    /// </summary>
    /// <param name="count">The number of words to hide.</param>
    /// <returns>
    /// The words that were hidden.
    /// </returns>
    public void HideRandomWords(int count)
    {
        Random rand = new();
        for (int i = 0; i < count; i++)
        {
            int index = rand.Next(_words.Count);
            if (_words[index].IsHidden() && !IsCompletelyHidden())
            {
                i--; // I think that this is stupid.
                continue;
            }
            _words[index].Hide();
        }
    }

    /// <summary>
    /// Get the display text of the scripture with hidden (or not hidden) words.
    /// </summary>
    /// <returns>
    /// A string representing the scripture with hidden words.
    /// </returns>
    public string GetDisplayText()
    {
        var displayText = _reference.ToString() + " ";
        
        foreach (var word in _words)
        {
            displayText += word.ToString() + " ";
        }
        
        return displayText;
    }

    /// <summary>
    /// Used to determine if all the words in the scripture are hidden.
    /// </summary>
    /// <returns>
    /// True if all the words are hidden, false otherwise.
    /// </returns>
    public bool IsCompletelyHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}